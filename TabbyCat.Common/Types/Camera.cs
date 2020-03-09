namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.Converters;

    public class Camera
    {
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Focus { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Position { get; set; }
    }
}
