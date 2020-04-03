namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.TypeConverters;

    public class SimpleCamera
    {
        public SimpleCamera(Vector3 position, Vector3 focus)
        {
            Position = position;
            Focus = focus;
        }

        [JsonConverter(typeof(Vector3Converter))] public Vector3 Focus { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Position { get; set; }

        public Vector3 Ufront => (Focus - Position).Normalized();
        public Vector3 Uright => Vector3.Cross(Ufront, Uup).Normalized();
        public Vector3 Uup => Vector3.UnitY;

        public static bool operator ==(SimpleCamera a, SimpleCamera b) => a?.Position == b?.Position && a?.Focus == b?.Focus;
        public static bool operator !=(SimpleCamera a, SimpleCamera b) => !(a == b);

        public override bool Equals(object obj) => obj is SimpleCamera camera && camera == this;
        public override int GetHashCode() => Position.GetHashCode() ^ Focus.GetHashCode();
        public override string ToString() => $"{Position},{Focus}";
    }
}
