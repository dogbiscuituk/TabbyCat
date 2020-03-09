namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.Converters;

    public class Camera
    {
        [JsonConverter(typeof(Vector3dConverter))] public Vector3d Focus { get; set; }
        [JsonConverter(typeof(Vector3dConverter))] public Vector3d Position { get; set; }
    }
}
