namespace TabbyCat.Types
{
    using System;
    using System.Windows.Forms;

    public class Clock : IDisposable
    {
        public Clock()
        {
            Timer = new Timer { Enabled = false };
            Timer.Tick += Timer_Tick;
        }

        private const int LimitFactor = 32;
        private bool _Running;
        private DateTime _StartedAt;
        private TimeSpan _RealTimeElapsed, _VirtualTimeElapsed;
        private int _SuspendCount;
        private readonly Timer Timer;
        private float _VirtualTimeFactor = 1;

        public bool Running
        {
            get => _Running;
            set
            {
                if (Running != value)
                {
                    DateTime now = DateTime.Now;
                    if (Running)
                    {
                        Timer.Enabled = false;
                        TimeSpan elapsed = now - _StartedAt;
                        _RealTimeElapsed += elapsed;
                        _VirtualTimeElapsed += GetVirtualIncrement(now);
                    }
                    _Running = value;
                    if (Running)
                    {
                        _StartedAt = now;
                        Timer.Enabled = true;
                    }
                }
            }
        }

        public float RealSecondsElapsed => (float)RealTimeElapsed.TotalSeconds;
        public float VirtualSecondsElapsed => (float)VirtualTimeElapsed.TotalSeconds;

        public int IntervalMilliseconds
        {
            get => Timer.Interval;
            set => Timer.Interval = value;
        }

        public TimeSpan RealTimeElapsed => Running
            ? _RealTimeElapsed + (DateTime.Now - _StartedAt)
            : _RealTimeElapsed;

        public TimeSpan VirtualTimeElapsed => Running
            ? _VirtualTimeElapsed + GetVirtualIncrement(DateTime.Now)
            : _VirtualTimeElapsed;

        public float VirtualTimeFactor
        {
            get => _VirtualTimeFactor;
            set
            {
                if (VirtualTimeFactor != value)
                {
                    bool running = Running;
                    Stop();
                    _VirtualTimeFactor = value;
                    if (running)
                    {
                        Start();
                    }
                }
            }
        }

        public event EventHandler<EventArgs> Tick;

        public void Accelerate()
        {
            VirtualTimeFactor = +Scale(+VirtualTimeFactor);
        }

        public void Decelerate()
        {
            VirtualTimeFactor = -Scale(-VirtualTimeFactor);
        }

        public void Reset()
        {
            Running = false;
            _RealTimeElapsed = TimeSpan.Zero;
            _VirtualTimeElapsed = TimeSpan.Zero;
            _VirtualTimeFactor = 1;
        }

        public void Resume()
        {
            if (_SuspendCount > 0 && --_SuspendCount == 0)
            {
                Running = true;
            }
        }

        public void Start()
        {
            _SuspendCount = 0;
            Running = true;
        }

        public void Stop()
        {
            _SuspendCount = 0;
            Running = false;
        }

        public void Suspend()
        {
            _SuspendCount++;
            Running = false;
        }

        private TimeSpan GetVirtualIncrement(DateTime now)
        {
            return TimeSpan.FromSeconds((now - _StartedAt).TotalSeconds * VirtualTimeFactor);
        }

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        #region IDisposable

        private bool Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Timer?.Dispose();
                }
                Disposed = true;
            }
        }

        #endregion
    }
}
