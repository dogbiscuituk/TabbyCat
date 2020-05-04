namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Properties;
    using System;
    using Utils;

    internal class SceneCodeCon : CodeCon
    {
        internal SceneCodeCon(WorldCon worldCon) : base(worldCon) { }

        protected override string ShaderName => ShaderType.SceneShaderName();

        protected override IScript ShaderSet => Scene;

        protected override string GetRegion() => Resources.ShaderRegion_Scene;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewSceneCode.Click += ViewSceneCode_Click;
            }
            else
            {
                WorldForm.ViewSceneCode.Click -= ViewSceneCode_Click;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewSceneCode, WorldForm.ViewSceneCode);
        }

        protected override void RunShaderCommand(string text) => Run(new SceneShaderCommand(ShaderType, text));

        private void ViewSceneCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
