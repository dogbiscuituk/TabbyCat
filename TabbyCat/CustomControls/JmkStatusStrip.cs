﻿namespace TabbyCat.CustomControls
{
    using System.Windows.Forms;

    public class JmkStatusStrip : StatusStrip
    {
        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }
    }
}
