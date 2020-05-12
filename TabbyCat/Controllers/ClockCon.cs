namespace TabbyCat.Controllers
{
    using System;
    using Types;

    public class ClockCon : LocalCon
    {
        // Constructors

        public ClockCon(WorldCon worldCon) : base(worldCon) => UpdateTimeControls();

        // Private fields

        private Clock _clock;

        // Protected properties

        protected override Clock Clock => _clock ?? (_clock = new Clock());

        // Private properties

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => !Clock.Running || VirtualTimeFactor > 0;
        private bool CanStart => !Clock.Running || VirtualTimeFactor < 0;
        private bool CanStop => Clock.Running;

        private float VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.TimeDecelerate.Click += Decelerate_Click;
                WorldForm.TimeReverse.Click += Reverse_Click;
                WorldForm.TimeStop.Click += Stop_Click;
                WorldForm.TimePause.Click += Pause_Click;
                WorldForm.TimeForward.Click += Forward_Click;
                WorldForm.TimeAccelerate.Click += Accelerate_Click;
            }
            else
            {
                WorldForm.TimeDecelerate.Click -= Decelerate_Click;
                WorldForm.TimeReverse.Click -= Reverse_Click;
                WorldForm.TimeStop.Click -= Stop_Click;
                WorldForm.TimePause.Click -= Pause_Click;
                WorldForm.TimeForward.Click -= Forward_Click;
                WorldForm.TimeAccelerate.Click -= Accelerate_Click;
            }
        }

        public void UpdateTimeControls()
        {
            WorldForm.TimeAccelerate.Enabled = CanAccelerate;
            WorldForm.TimeDecelerate.Enabled = CanDecelerate;
            WorldForm.TimeForward.Enabled = CanStart;
            WorldForm.TimePause.Enabled = CanPause;
            WorldForm.TimeReverse.Enabled = CanReverse;
            WorldForm.TimeStop.Enabled = CanStop;
        }

        // Protected methods

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            Clock?.Dispose();
        }

        // Private methods

        private void Accelerate_Click(object sender, EventArgs e)
        {
            Clock.Accelerate();
            UpdateTimeControls();
        }

        private void Decelerate_Click(object sender, EventArgs e)
        {
            Clock.Decelerate();
            UpdateTimeControls();
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            VirtualTimeFactor = Math.Abs(VirtualTimeFactor);
            Clock.Start();
            UpdateTimeControls();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            Clock.Stop();
            UpdateTimeControls();
        }

        private void Reverse_Click(object sender, EventArgs e)
        {
            VirtualTimeFactor = -Math.Abs(VirtualTimeFactor);
            Clock.Start();
            UpdateTimeControls();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Clock.Reset();
            UpdateTimeControls();
        }
    }
}
