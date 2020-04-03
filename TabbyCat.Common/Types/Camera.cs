namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.TypeConverters;

    public class Camera
    {
        public Camera(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        [JsonConverter(typeof(Vector3Converter))] public Vector3 Position { get; set; }
        [JsonConverter(typeof(QuaternionConverter))] public Quaternion Rotation { get; set; }



        public static bool operator ==(Camera a, Camera b) => a?.Position == b?.Position && a?.Rotation == b?.Rotation;
        public static bool operator !=(Camera a, Camera b) => !(a == b);

        public override bool Equals(object obj) => obj is Camera camera && camera == this;
        public override int GetHashCode() => Position.GetHashCode() ^ Rotation.GetHashCode();
        public override string ToString() => $"{Position},{Rotation}";
    }
}
