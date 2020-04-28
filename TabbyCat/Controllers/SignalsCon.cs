namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Models;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SignalsCon : DockingCon
    {
        // Constructors

        internal SignalsCon(WorldCon worldCon) : base(worldCon) { }

        // Fields

        internal readonly List<SignalCon> SignalCons = new List<SignalCon>();

        private SignalsForm _SignalsForm;

        // Internal properties

        internal int SignalsCount => SignalCons.Count;

        // Protected internal roperties

        protected internal override DockContent Form => SignalsForm;

        // Protected properties

        protected override string[] AllProperties => new[] { PropertyNames.Signals };

        protected override SignalsForm SignalsForm => _SignalsForm ?? (_SignalsForm = NewSignalsForm());

        private SignalsForm NewSignalsForm()
        {
            var signalsForm = new SignalsForm
            {
                TabText = Resources.SignalsForm_TabText,
                Text = Resources.SignalsForm_Text,
                ToolTipText = Resources.SignalsForm_Text
            };
            AppCon.InitControlTheme(signalsForm.Toolbar);
            signalsForm.WaveTypeSlider.Tag = WaveType.Constant;
            signalsForm.WaveTypeSine.Tag = WaveType.Sine;
            signalsForm.WaveTypeSquare.Tag = WaveType.Square;
            signalsForm.WaveTypeTriangle.Tag = WaveType.Triangle;
            signalsForm.WaveTypeSawtooth.Tag = WaveType.Sawtooth;
            signalsForm.WaveTypeReverseSawtooth.Tag = WaveType.ReverseSawtooth;
            signalsForm.WaveTypeCustom.Tag = WaveType.Custom;
            signalsForm.WaveTypeNoise.Tag = WaveType.Noise;
            return signalsForm;
        }

        // Internal methods

        internal void Add(Signal signal)
        {
            var signalCon = new SignalCon(WorldCon, signal);
            SignalCons.Add(signalCon);

            var rowStyle = SignalsPanel.RowStyles[SignalsPanel.RowCount - 1];
            SignalsPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
            SignalsPanel.RowCount++;
            var row = SignalsCount - 2;

            SignalsControls.Add(signalCon.NameEditor, 1, row);
            SignalsControls.Add(signalCon.AmplitudeSlider, 2, row);
            SignalsControls.Add(signalCon.FrequencySlider, 3, row);
            SignalsControls.Add(signalCon.SignalToolbar, 4, row);

            // SignalsForm.AddButton.CloneTo(signalCon.SignalToolbar.WaveTypeButton, onClick: false);
            /* TODO
            foreach (var menuItem in signalCon.SignalToolbar.WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>())
                menuItem.Click += MenuItem_Click;
                */
            //signalCon.SetWaveType(WaveType.Constant);

            signalCon.Connect(true);
        }

        /* TODO
        private void MenuItem_Click(object sender, System.EventArgs e)
        {

        }*/

        internal void BeginUpdate() => SignalsPanel.SuspendLayout();

        internal void Clear()
        {
            for (var index = SignalsCount - 1; index >= 0; index--)
                RemoveAt(index);
        }

        internal void EndUpdate() => SignalsPanel.ResumeLayout();

        internal void RemoveAt(int index)
        {
            var signalCon = SignalCons[index];
            signalCon.Connect(false);
            SignalCons.RemoveAt(index);
            signalCon.DisposeControls();
            var row = index + 1;
            SignalsPanel.RowCount--;
            SignalsPanel.RowStyles.RemoveAt(row);
        }

        // Protected internal methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SignalsForm.AddButton.Click += AddButton_Click;
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldForm.ViewSignals.Click += ViewSignals_Click;
            }
            else
            {
                SignalsForm.AddButton.Click -= AddButton_Click;
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
                WorldForm.ViewSignals.Click -= ViewSignals_Click;
            }
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.SignalsForm_WaveTypeSlider, SignalsForm.WaveTypeSlider);
            Localize(Resources.SignalsForm_WaveTypeSine, SignalsForm.WaveTypeSine);
            Localize(Resources.SignalsForm_WaveTypeSquare, SignalsForm.WaveTypeSquare);
            Localize(Resources.SignalsForm_WaveTypeTriangle, SignalsForm.WaveTypeTriangle);
            Localize(Resources.SignalsForm_WaveTypeSawtooth, SignalsForm.WaveTypeSawtooth);
            Localize(Resources.SignalsForm_WaveTypeReverseSawtooth, SignalsForm.WaveTypeReverseSawtooth);
            Localize(Resources.SignalsForm_WaveTypeCustom, SignalsForm.WaveTypeCustom);
            Localize(Resources.SignalsForm_WaveTypeNoise, SignalsForm.WaveTypeNoise);
            Localize(Resources.WorldForm_ViewSignals, WorldForm.ViewSignals);
        }

        protected override void UpdateProperties(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Signals:
                        Reload();
                        break;
                }
        }

        // Private methods

        private void AddButton_Click(object sender, System.EventArgs e) => AddSignal();

        private void AddSignal() => CommandProcessor.AppendSignal();

        private void Reload()
        {
            BeginUpdate();
            Clear();
            foreach (var signal in Scene.Signals)
                Add(signal);
            EndUpdate();
        }

        private void ViewSignals_Click(object sender, System.EventArgs e) => ToggleVisibility();

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.Signals:
                    Reload();
                    break;
            }
        }
    }
}
