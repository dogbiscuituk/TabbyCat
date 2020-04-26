namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Models;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SignalsCon : DockingCon
    {
        internal SignalsCon(WorldCon worldCon) : base(worldCon) { }

        private SignalsForm _SignalsForm;

        private readonly List<SignalCon> SignalCons = new List<SignalCon>();

        protected internal override DockContent Form => SignalsForm;

        internal int SignalsCount => SignalCons.Count;

        protected override SignalsForm SignalsForm => _SignalsForm ?? (_SignalsForm = new SignalsForm
        {
            TabText = Resources.SignalsForm_TabText,
            Text = Resources.SignalsForm_Text,
            ToolTipText = Resources.SignalsForm_Text
        });

        internal void Add(Signal signal)
        {
            var signalCon = new SignalCon(WorldCon, signal);

            SignalsLayoutPanel.RowCount++;
            SignalsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
            var rowIndex = SignalsCount + 1;
            SignalsLayoutControls.Add(signalCon.NameEditor, 0, rowIndex);
            SignalsLayoutControls.Add(signalCon.AmplitudeSlider, 1, rowIndex);
            SignalsLayoutControls.Add(signalCon.FrequencySlider, 2, rowIndex);
            SignalsLayoutControls.Add(signalCon.SignalToolbar, 3, rowIndex);

            SignalCons.Add(signalCon);
            signalCon.SetWaveType(WaveType.Constant);
            signalCon.Connect(true);
        }

        internal void Clear()
        {
            for (var index = SignalsCount - 1; index >= 0; index--)
                RemoveAt(index);
        }

        internal void RemoveAt(int index)
        {
            var signalCon = SignalCons[index];
            signalCon.Connect(false);
            SignalCons.RemoveAt(index);
            signalCon.DisposeControls();
            SignalsLayoutPanel.RowStyles.RemoveAt(index + 1);
            SignalsLayoutPanel.RowCount--;
        }

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldForm.ViewSignals.Click += ViewSignals_Click;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
                WorldForm.ViewSignals.Click -= ViewSignals_Click;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Menu_View_Signals, WorldForm.ViewSignals);
        }

        internal void BeginUpdate() => SignalsLayoutPanel.SuspendLayout();

        internal void EndUpdate() => SignalsLayoutPanel.ResumeLayout();

        private void ViewSignals_Click(object sender, System.EventArgs e) => ToggleVisibility();

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.Signals:
                    BeginUpdate();
                    Clear();
                    foreach (var signal in Scene.Signals)
                        Add(signal);
                    EndUpdate();
                    break;
            }
        }
    }
}
