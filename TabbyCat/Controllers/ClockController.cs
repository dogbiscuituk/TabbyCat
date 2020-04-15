namespace TabbyCat.Controllers
{
    using System;
    using TabbyCat.Common.Types;
    using TabbyCat.Views;

    internal class ClockController : LocalizationController
    {
        internal ClockController(WorldController worldController) : base(worldController)
        {
            Clock = new Clock();
            UpdateTimeControls();
        }

        protected override Clock Clock { get; }
        internal bool ClockRunning => Clock.Running;
        internal float VirtualSecondsElapsed => Clock.VirtualSecondsElapsed;

        internal float VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

        protected internal override void Connect(bool connect)
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

        internal void UpdateTimeControls()
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
