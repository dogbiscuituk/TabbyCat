namespace TabbyCat.Controllers
{
    using Controls;
    using System;

    internal partial class SliderCon
    {
        internal SliderCon()
        {
            Slider = new Slider();
        }

        internal Slider Slider;
    }

    partial class SliderCon : IDisposable
    {
        private bool Disposed;

        public void Dispose()
        {
            if (!Disposed)
            {
                DisposeManagedState();
                Disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeManagedState()
        {
            Slider.Dispose();
        }
    }
}
