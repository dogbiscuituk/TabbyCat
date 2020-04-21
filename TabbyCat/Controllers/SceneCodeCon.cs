namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Common.Utils;
    using Properties;

    internal class SceneCodeCon : CodeCon
    {
        internal SceneCodeCon(WorldCon worldCon) : base(worldCon) { }

        protected override string ShaderName => ShaderType.SceneShaderName();

        protected override IScript ShaderSet => Scene;

        protected override string GetRegion() => Resources.ShaderRegion_Scene;

        protected override void RunShaderCommand(string text) => Run(new SceneShaderCommand(ShaderType, text));
    }
}
