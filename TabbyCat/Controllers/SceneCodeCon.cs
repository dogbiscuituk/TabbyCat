namespace TabbyCat.Controllers
{
    using Commands;
    using Properties;
    using System;
    using Types;
    using Utils;

    public class SceneCodeCon : CodeCon
    {
        // Constructors

        public SceneCodeCon(WorldCon worldCon) : base(worldCon) { }

        // Protected properties

        protected override Property Shader => ShaderType.SceneShader();

        protected override IScript ShaderSet => Scene;

        protected override string GetRegion() => Resources.ShaderRegion_Scene;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldForm.ViewSceneCode.Click += ViewSceneCode_Click;
            else
                WorldForm.ViewSceneCode.Click -= ViewSceneCode_Click;
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewSceneCode, WorldForm.ViewSceneCode);
        }

        protected override void RunShaderCommand(string text) => Run(new SceneShaderCommand(ShaderType, text));

        // Private methods

        private void ViewSceneCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
