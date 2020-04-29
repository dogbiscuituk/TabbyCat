﻿namespace TabbyCat.Controllers
{
    using Common.Utils;
    using Jmk.Common;
    using Models;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Common.Types;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SignalsCon : DockingCon
    {
        // Constructors

        internal SignalsCon(WorldCon worldCon) : base(worldCon) { }

        // Internal fields

        internal readonly List<SignalCon> SignalCons = new List<SignalCon>();

        // Private fields

        private SignalsForm _SignalsForm;

        // Internal properties

        internal int SignalsCount => SignalCons.Count;

        // Protected internal properties

        protected internal override DockContent Form => SignalsForm;

        // Protected properties

        protected override string[] AllProperties => new[] { PropertyNames.Signals };

        protected override SignalsForm SignalsForm => _SignalsForm ?? NewSignalsForm();

        // Private properties

        private ToolStrip Toolbar => SignalsForm.Toolbar;

        // Internal methods

        internal void InsertAt(int index)
        {
            var signal = Scene.Signals[index];
            AdjustIndices(index, +1);
            SignalCon newSignalCon = new SignalCon(WorldCon, signal);
            var signalEdit = newSignalCon.SignalEdit;
            signalEdit.Dock = DockStyle.Top;
            SignalCons.Add(newSignalCon);
            SignalsForm.Controls.Add(signalEdit);
            signalEdit.BringToFront();
            newSignalCon.Connect(true);
        }

        internal void RemoveAt(int index)
        {
            var oldSignalCon = SignalCons[index];
            oldSignalCon.Connect(false);
            SignalsForm.Controls.Remove(oldSignalCon.SignalEdit);
            SignalCons.RemoveAt(index);
            AdjustIndices(index, -1);
        }

        // Protected internal methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SignalsForm.AddButton.ButtonClick += AddButton_ButtonClick;
                WorldCon.CollectionChanged += WorldCon_CollectionChanged;
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldForm.ViewSignals.Click += ViewSignals_Click;
            }
            else
            {
                SignalsForm.AddButton.ButtonClick -= AddButton_ButtonClick;
                WorldCon.CollectionChanged += WorldCon_CollectionChanged;
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
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

        private SignalsForm NewSignalsForm()
        {
            _SignalsForm = new SignalsForm
            {
                TabText = Resources.SignalsForm_TabText,
                Text = Resources.SignalsForm_Text,
                ToolTipText = Resources.SignalsForm_Text
            };
            Init(_SignalsForm.AddButton, WaveType.Constant);
            Init(_SignalsForm.WaveTypeSlider, WaveType.Constant);
            Init(_SignalsForm.WaveTypeSine, WaveType.Sine);
            Init(_SignalsForm.WaveTypeSquare, WaveType.Square);
            Init(_SignalsForm.WaveTypeTriangle, WaveType.Triangle);
            Init(_SignalsForm.WaveTypeSawtooth, WaveType.Sawtooth);
            Init(_SignalsForm.WaveTypeReverseSawtooth, WaveType.ReverseSawtooth);
            Init(_SignalsForm.WaveTypeCustom, WaveType.Custom);
            Init(_SignalsForm.WaveTypeNoise, WaveType.Noise);
            AppCon.InitControlTheme(Toolbar);
            return _SignalsForm;
        }

        private void ViewSignals_Click(object sender, System.EventArgs e) => ToggleVisibility();

        private void WorldCon_CollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            switch (e.CollectionName)
            {
                case PropertyNames.Signals:
                    var index = e.Index;
                    if (e.Adding)
                        InsertAt(e.Index);
                    else
                        RemoveAt(index);
                    break;
            }
        }


        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.Signals:
                    break;
            }
        }

        // Private static methods

        private static void Init(ToolStripItem item, WaveType waveType) => item.Tag = waveType;
    }
}
