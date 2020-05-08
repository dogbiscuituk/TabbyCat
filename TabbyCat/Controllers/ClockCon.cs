namespace TabbyCat.Controllers
{
    using System;
    using Types;
    using Views;

    public class ClockCon : LocalizationCon
    {
        public ClockCon(WorldCon worldCon) : base(worldCon) => UpdateTimeControls();

        private Clock _Clock;

        protected override Clock Clock => _Clock ?? (_Clock = new Clock());
        public bool ClockRunning => Clock.Running;
        public float VirtualSecondsElapsed => Clock.VirtualSecondsElapsed;

        public float VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

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

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            Clock?.Dispose();
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

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => !Clock.Running || VirtualTimeFactor > 0;
        private bool CanStart => !Clock.Running || VirtualTimeFactor < 0;
        private bool CanStop => Clock.Running;

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
