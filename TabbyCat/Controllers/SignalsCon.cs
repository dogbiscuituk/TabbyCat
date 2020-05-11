namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using Properties;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public class SignalsCon : DockingCon
    {
        // Constructors

        public SignalsCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private SignalsForm _signalsForm;

        // Protected properties

        protected override IEnumerable<Property> AllProperties => new List<Property> { Property.Signals };

        protected override DockContent Form => SignalsForm;

        protected override SignalsForm SignalsForm => _signalsForm ?? NewSignalsForm();

        // Private properties

        private List<SignalCon> SignalCons { get; } = new List<SignalCon>();

        private int SignalsCount => SignalCons.Count;

        private ToolStrip Toolbar => SignalsForm.Toolbar;

        // Public methods

        public void Clear()
        {
            for (var index = SignalCons.Count - 1; index >= 0; index--)
                RemoveAt(index);
        }

        public void Load()
        {
            Clear();
            for (var index = 0; index < Scene.Signals.Count; index++)
                InsertAt(index);
        }

        // Protected public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SignalsForm.AddButton.ButtonClick += AddButton_ButtonClick;
                SignalsForm.DeleteAllButton.Click += DeleteAllButton_Click;
                WorldCon.CollectionEdit += WorldCon_CollectionEdit;
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
                WorldForm.ViewSignals.Click += ViewSignals_Click;
            }
            else
            {
                SignalsForm.AddButton.ButtonClick -= AddButton_ButtonClick;
                SignalsForm.DeleteAllButton.Click -= DeleteAllButton_Click;
                WorldCon.CollectionEdit -= WorldCon_CollectionEdit;
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
                WorldForm.ViewSignals.Click -= ViewSignals_Click;
            }
            foreach (var item in SignalsForm.AddButton.DropDownItems.OfType<ToolStripMenuItem>())
                if (connect)
                    item.Click += AddButton_ButtonClick;
                else
                    item.Click -= AddButton_ButtonClick;
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.SignalsForm, SignalsForm);
            Localize(Resources.SignalsForm_NameLabel, SignalsForm.NameLabel);
            Localize(Resources.SignalsForm_AmplitudeLabel, SignalsForm.AmplitudeLabel);
            Localize(Resources.SignalsForm_FrequencyLabel, SignalsForm.FrequencyLabel);
            Localize(Resources.SignalsForm_AddButton, SignalsForm.AddButton);
            Localize(Resources.SignalsForm_DeleteAllButton, SignalsForm.DeleteAllButton);
            Localize(Resources.SignalsForm_WaveTypeSlider, SignalsForm.WaveTypeSlider);
            Localize(Resources.SignalsForm_WaveTypeSine, SignalsForm.WaveTypeSine);
            Localize(Resources.SignalsForm_WaveTypeSquare, SignalsForm.WaveTypeSquare);
            Localize(Resources.SignalsForm_WaveTypeTriangle, SignalsForm.WaveTypeTriangle);
            Localize(Resources.SignalsForm_WaveTypeRampUp, SignalsForm.WaveTypeRampUp);
            Localize(Resources.SignalsForm_WaveTypeRampDown, SignalsForm.WaveTypeRampDown);
            Localize(Resources.WorldForm_ViewSignals, WorldForm.ViewSignals);
        }

        protected override void UpdateProperties(IEnumerable<Property> properties)
        {
            if (properties == null)
                return;
            foreach (var property in properties)
                switch (property)
                {
                    case Property.Signals:
                        break;
                }
        }

        // Private methods

        private void AddButton_ButtonClick(object sender, System.EventArgs e) => AddSignal((WaveType)((ToolStripItem)sender).Tag);

        private void AddSignal(WaveType waveType) => CommandCon.AppendSignal(new Signal
        {
            Name = NameSource.Names.First(
                name => Scene.Signals.FirstOrDefault(
                    signal => signal.Name == name) == null),
            WaveType = waveType
        });

        private void AdjustIndices(int index, int delta)
        {
            foreach (var signalCon in SignalCons.Where(p => p.Index >= index).ToList())
                signalCon.Index += delta;
        }

        private void AdjustOrder()
        {
            SignalsForm.SuspendLayout();
            for (var index = 0; index < Scene.Signals.Count; index++)
                FindSignalCon(index)?.SignalEdit?.BringToFront();
            SignalsForm.ResumeLayout();
        }

        private void DeleteAllButton_Click(object sender, System.EventArgs e)
        {
            for (var index = SignalsCount - 1; index >= 0; index--)
                Run(new SignalDeleteCommand(index));
        }

        private SignalCon FindSignalCon(int index) => SignalCons.FirstOrDefault(p => p.Index == index);

        private void InsertAt(int index)
        {
            var signal = Scene.Signals[index];
            AdjustIndices(index, +1);
            var newSignalCon = new SignalCon(WorldCon, signal);
            var signalEdit = newSignalCon.SignalEdit;
            signalEdit.Dock = DockStyle.Top;
            SignalCons.Add(newSignalCon);
            SignalsForm.Controls.Add(signalEdit);
            newSignalCon.Connect(true);
            AdjustOrder();
        }

        private SignalsForm NewSignalsForm()
        {
            _signalsForm = new SignalsForm
            {
                TabText = Resources.SignalsForm_TabText,
                Text = Resources.SignalsForm_Text,
                ToolTipText = Resources.SignalsForm_Text
            };
            Init(_signalsForm.AddButton, WaveType.Constant);
            Init(_signalsForm.WaveTypeSlider, WaveType.Constant);
            Init(_signalsForm.WaveTypeSine, WaveType.Sine);
            Init(_signalsForm.WaveTypeSquare, WaveType.Square);
            Init(_signalsForm.WaveTypeTriangle, WaveType.Triangle);
            Init(_signalsForm.WaveTypeRampUp, WaveType.RampUp);
            Init(_signalsForm.WaveTypeRampDown, WaveType.RampDown);
            AppCon.InitControlTheme(Toolbar);
            return _signalsForm;
        }

        private void RemoveAt(int index)
        {
            var oldSignalCon = FindSignalCon(index);
            oldSignalCon.Connect(false);
            SignalsForm.Controls.Remove(oldSignalCon.SignalEdit);
            SignalCons.Remove(oldSignalCon);
            AdjustIndices(index + 1, -1);
        }

        private void ViewSignals_Click(object sender, System.EventArgs e) => ToggleVisibility();

        private void WorldCon_CollectionEdit(object sender, CollectionEditEventArgs e)
        {
            switch (e.Property)
            {
                case Property.Signals:
                    if (e.Adding)
                        InsertAt(e.Index);
                    else
                        RemoveAt(e.Index);
                    break;
            }
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e)
        {
            switch (e.Property)
            {
                case Property.Signals:
                    break;
            }
        }

        // Private static methods

        private static void Init(ToolStripItem item, WaveType waveType) => item.Tag = waveType;
    }
}
