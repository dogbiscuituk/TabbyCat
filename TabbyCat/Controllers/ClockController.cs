namespace TabbyCat.Controllers
{
    using System;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class ClockController
    {
        #region Constructors

        internal ClockController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneForm.TimeDecelerate.Click += TimeDecelerate_Click;
            SceneForm.tbDecelerate.Click += TimeDecelerate_Click;
            SceneForm.TimeReverse.Click += TimeReverse_Click;
            SceneForm.tbReverse.Click += TimeReverse_Click;
            SceneForm.TimeStop.Click += TimeStop_Click;
            SceneForm.tbStop.Click += TimeStop_Click;
            SceneForm.TimePause.Click += TimePause_Click;
            SceneForm.tbPause.Click += TimePause_Click;
            SceneForm.TimeForward.Click += TimeForward_Click;
            SceneForm.tbForward.Click += TimeForward_Click;
            SceneForm.TimeAccelerate.Click += TimeAccelerate_Click;
            SceneForm.tbAccelerate.Click += TimeAccelerate_Click;
            Clock = new Clock();
            Clock.Tick += Clock_Tick;
            UpdateTimeControls();
        }

        #endregion

        #region Internal Properties

        internal Clock Clock;
        internal bool ClockRunning => Clock.Running;
        internal double VirtualSecondsElapsed => Clock.VirtualSecondsElapsed;

        internal double VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

        #endregion

        #region Internal Methods

        internal void UpdateTimeControls()
        {
            SceneForm.TimeAccelerate.Enabled = SceneForm.tbAccelerate.Enabled = CanAccelerate;
            SceneForm.TimeDecelerate.Enabled = SceneForm.tbDecelerate.Enabled = CanDecelerate;
            SceneForm.TimeForward.Enabled = SceneForm.tbForward.Enabled = CanStart;
            SceneForm.TimePause.Enabled = SceneForm.tbPause.Enabled = CanPause;
            SceneForm.TimeReverse.Enabled = SceneForm.tbReverse.Enabled = CanReverse;
            SceneForm.TimeStop.Enabled = SceneForm.tbStop.Enabled = CanStop;
            UpdateTimeFactor();
        }

        #endregion

        #region Private Properties

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => !Clock.Running || VirtualTimeFactor > 0;
        private bool CanStart => !Clock.Running || VirtualTimeFactor < 0;
        private bool CanStop => Clock.Running;

        private string
            LastTime,
            LastSpeed;

        private readonly SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;

        #endregion

        #region Private Event Handlers

        private void Clock_Tick(object sender, EventArgs e) => UpdateTimeDisplay();
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
            UpdateTimeDisplay();
            UpdateTimeControls();
        }

        private void UpdateTimeDisplay()
        {
            var time = string.Format("t={0:f1}", VirtualSecondsElapsed);
            if (LastTime != time)
                LastTime = SceneForm.Tlabel.Text = time;
        }

        private void UpdateTimeFactor()
        {
            string speed;
            var factor = VirtualTimeFactor;
            if (factor == 0)
                speed = "time × 0";
            else
            {
                var divide = Math.Abs(factor) < 1;
                if (divide)
                    factor = 1 / factor;
                speed = divide ? $"time ÷ {factor}" : $"time × {factor}";
            }
            if (LastSpeed != speed)
                LastSpeed = SceneForm.SpeedLabel.Text = speed;
        }

        #endregion
    }
}
