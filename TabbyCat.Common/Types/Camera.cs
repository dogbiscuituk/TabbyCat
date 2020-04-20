namespace TabbyCat.Common.Types
{
    using Common.Converters;
    using Newtonsoft.Json;
    using OpenTK;

    public class Camera
    {
        public Camera(Vector3 position, Vector3 focus)
        {
            Position = position;
            Focus = focus;
        }

        public Camera(Camera camera)
        {
            if (camera == null)
                return;
            Position = camera.Position;
            Focus = camera.Focus;
        }

        [JsonConverter(typeof(Vector3Converter))] public Vector3 Focus { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Position { get; set; }

        [JsonIgnore] public Vector3 Ufront => (Focus - Position).Normalized();
        [JsonIgnore] public Vector3 Uright => Vector3.Cross(Ufront, Uup).Normalized();
        [JsonIgnore] public Vector3 Uup { get; set; } = new Vector3(0, 1, 0);

        public static bool operator ==(Camera a, Camera b) => a?.Position == b?.Position && a?.Focus == b?.Focus;
        public static bool operator !=(Camera a, Camera b) => !(a == b);

        public override bool Equals(object obj) => obj is Camera camera && camera == this;
        public override int GetHashCode() => Position.GetHashCode() ^ Focus.GetHashCode();
        public override string ToString() => $"{Position},{Focus}";
    }
}
