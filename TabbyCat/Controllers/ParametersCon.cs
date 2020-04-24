namespace TabbyCat.Controllers
{
    using Properties;
    using System.Collections.Generic;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class ParametersCon : DockingCon
    {
        internal ParametersCon(WorldCon worldCon) : base(worldCon) { }

        private ParametersForm _ParametersForm;

        private readonly List<SignalCon> SignalCons = new List<SignalCon>();

        protected internal override DockContent Form => ParametersForm;

        protected override ParametersForm ParametersForm => _ParametersForm ?? (_ParametersForm = new ParametersForm
        {
            TabText = Resources.ParametersForm_TabText,
            Text = Resources.ParametersForm_Text,
            ToolTipText = Resources.ParametersForm_Text
        });

        internal void AddSignalCon(string name) => SignalCons.Add(new SignalCon(WorldCon, name));

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewParameters.Click += ViewParameters_Click;

                AddSignalCon("Foo");
                AddSignalCon("Bar");
                AddSignalCon("Baz");

            }
            else
            {
                WorldForm.ViewParameters.Click += ViewParameters_Click;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Menu_View_Parameters, WorldForm.ViewParameters);
        }

        private void ViewParameters_Click(object sender, System.EventArgs e) => ToggleVisibility();
    }
}
