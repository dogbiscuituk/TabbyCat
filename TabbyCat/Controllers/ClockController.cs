namespace TabbyCat.Controllers
{
    using System;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class ClockController
    {
        #region Constructors

        internal ClockController(WorldController worldController)
        {
            WorldController = worldController;
            WorldForm.TimeDecelerate.Click += TimeDecelerate_Click;
            WorldForm.tbDecelerate.Click += TimeDecelerate_Click;
            WorldForm.TimeReverse.Click += TimeReverse_Click;
            WorldForm.tbReverse.Click += TimeReverse_Click;
            WorldForm.TimeStop.Click += TimeStop_Click;
            WorldForm.tbStop.Click += TimeStop_Click;
            WorldForm.TimePause.Click += TimePause_Click;
            WorldForm.tbPause.Click += TimePause_Click;
            WorldForm.TimeForward.Click += TimeForward_Click;
            WorldForm.tbForward.Click += TimeForward_Click;
            WorldForm.TimeAccelerate.Click += TimeAccelerate_Click;
            WorldForm.tbAccelerate.Click += TimeAccelerate_Click;
            Clock = new Clock();
            UpdateTimeControls();
        }

        #endregion

        #region Internal Properties

        internal Clock Clock;
        internal bool ClockRunning => Clock.Running;
        internal float VirtualSecondsElapsed => Clock.VirtualSecondsElapsed;

        internal float VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

        #endregion

        #region Internal Methods

        internal void UpdateTimeControls()
        {
            WorldForm.TimeAccelerate.Enabled = WorldForm.tbAccelerate.Enabled = CanAccelerate;
            WorldForm.TimeDecelerate.Enabled = WorldForm.tbDecelerate.Enabled = CanDecelerate;
            WorldForm.TimeForward.Enabled = WorldForm.tbForward.Enabled = CanStart;
            WorldForm.TimePause.Enabled = WorldForm.tbPause.Enabled = CanPause;
            WorldForm.TimeReverse.Enabled = WorldForm.tbReverse.Enabled = CanReverse;
            WorldForm.TimeStop.Enabled = WorldForm.tbStop.Enabled = CanStop;
        }

        #endregion

        #region Private Properties

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => !Clock.Running || VirtualTimeFactor > 0;
        private bool CanStart => !Clock.Running || VirtualTimeFactor < 0;
        private bool CanStop => Clock.Running;

        private readonly WorldController WorldController;
        private WorldForm WorldForm => WorldController.WorldForm;

        #endregion

        #region Private Event Handlers

        private void TimeDecelerate_Click(object sender, EventArgs e) => Decelerate();
        private void TimeReverse_Click(object sender, EventArgs e) => Reverse();
        private void TimeStop_Click(object sender, EventArgs e) => Stop();
        private void TimePause_Click(object sender, EventArgs e) => Pause();
        private void TimeForward_Click(object sender, EventArgs e) => Forward();
        private void TimeAccelerate_Click(object sender, EventArgs e) => Accelerate();

        #endregion

        #region Private Methods

        private void Accelerate()
        {
            Clock.Accelerate();
            UpdateTimeControls();
        }

        private void Decelerate()
        {
            Clock.Decelerate();
            UpdateTimeControls();
        }

        private void Forward()
        {
            VirtualTimeFactor = Math.Abs(VirtualTimeFactor);
            Start();
            UpdateTimeControls();
        }

        private void Pause()
        {
            Clock.Stop();
            UpdateTimeControls();
        }

        private void Reverse()
        {
            VirtualTimeFactor = -Math.Abs(VirtualTimeFactor);
            Start();
            UpdateTimeControls();
        }

        private void Start() => Clock.Start();

        private void Stop()
        {
            Clock.Reset();
            UpdateTimeControls();
        }

        #endregion
    }
}
