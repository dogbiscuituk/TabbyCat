namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Controls;
    using Models;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
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
            var rowIndex = SignalsCount + 1;
            var nameEditor = NewNameEditor(signal.Name);
            var amplitudeSlider = NewSlider(AmpLeft, AmpRight);
            var frequencySlider = NewSlider(FreqLeft, FreqRight);
            var signalToolbar = NewSignalToolbar();
            SignalsLayoutPanel.RowCount++;
            SignalsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
            SignalsLayoutControls.Add(nameEditor, 0, rowIndex);
            SignalsLayoutControls.Add(amplitudeSlider, 1, rowIndex);
            SignalsLayoutControls.Add(frequencySlider, 2, rowIndex);
            SignalsLayoutControls.Add(signalToolbar, 3, rowIndex);
            AppCon.InitControlTheme(signalToolbar.ToolStrip);
            var signalCon = new SignalCon(WorldCon)
            {
                NameEditor = nameEditor,
                AmplitudeSlider = amplitudeSlider,
                FrequencySlider = frequencySlider,
                SignalToolbar = signalToolbar
            };
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

        private static TextBox NewNameEditor(string name) => new TextBox
        {
            AutoSize = true,
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill,
            Margin = new Padding(3, 0, 3, 0),
            Padding = new Padding(0),
            Size = new Size(30, 25),
            Text = name,
            TextAlign = HorizontalAlignment.Center
        };

        private static SignalToolbar NewSignalToolbar() => new SignalToolbar
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0)
        };

        private static TrackBar NewSlider(int minimum, int maximum) => new TrackBar
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Maximum = maximum,
            Minimum = minimum,
            TickStyle = TickStyle.None,
            Value = 0
        };

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

        private const float AmpMin = -1, AmpMax = +1, FreqMin = 0, FreqMax = 100;
        private const int AmpLeft = -1000000, AmpRight = +1000000, FreqLeft = 0, FreqRight = 2000000;
}
}
