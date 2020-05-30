namespace TabbyCat.Types
{
    using System;
    using System.Windows.Forms;

    public sealed class Clock : IDisposable
    {
        public Clock()
        {
            _timer = new Timer { Enabled = false };
            _timer.Tick += Timer_Tick;
        }

        private const int LimitFactor = 32;
        private bool _running;
        private DateTime _startedAt;
        private TimeSpan _virtualTimeElapsed;
        private readonly Timer _timer;
        private float _virtualTimeFactor = 1;

        public bool Running
        {
            get => _running;
            private set
            {
                if (Running != value)
                {
                    var now = DateTime.Now;
                    if (Running)
                    {
                        _timer.Enabled = false;
                        _virtualTimeElapsed += GetVirtualIncrement(now);
                    }
                    _running = value;
                    if (Running)
                    {
                        _startedAt = now;
                        _timer.Enabled = true;
                    }
                }
            }
        }

        public float VirtualSecondsElapsed => (float)VirtualTimeElapsed.TotalSeconds;

        public int IntervalMilliseconds
        {
            get => _timer.Interval;
            set => _timer.Interval = value;
        }

        private TimeSpan VirtualTimeElapsed => Running
            ? _virtualTimeElapsed + GetVirtualIncrement(DateTime.Now)
            : _virtualTimeElapsed;

        public float VirtualTimeFactor
        {
            get => _virtualTimeFactor;
            set
            {
                if (VirtualTimeFactor == value)
                    return;
                var running = Running;
                Stop();
                _virtualTimeFactor = value;
                if (running)
                    Start();
            }
        }

        public event EventHandler<EventArgs> Tick;

        public void Accelerate() => VirtualTimeFactor = +Scale(+VirtualTimeFactor);

        public void Decelerate() => VirtualTimeFactor = -Scale(-VirtualTimeFactor);

        public void Reset()
        {
            Running = false;
            _virtualTimeElapsed = TimeSpan.Zero;
            _virtualTimeFactor = 1;
        }

        public void Start() => Running = true;

        public void Stop() => Running = false;

        private TimeSpan GetVirtualIncrement(DateTime now) => TimeSpan.FromSeconds((now - _startedAt).TotalSeconds * VirtualTimeFactor);

        private static float Scale(float factor)
        {
            switch (factor)
            {
                case float f when f < -1.0 / LimitFactor:
                    return factor / 2;
                case -1f / LimitFactor:
                    return 0;
                case 0:
                    return 1f / LimitFactor;
                case float f when f < LimitFactor:
                    return factor * 2;
                default:
                    return LimitFactor;
            }
        }

        bool foo;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!foo)
            {
                foo = true;
                Tick?.Invoke(this, EventArgs.Empty);
                foo = false;
            }
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
