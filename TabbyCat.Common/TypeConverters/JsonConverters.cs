namespace TabbyCat.Common.Converters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenTK;
    using System;
    using System.Linq;

    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = JToken.Load(reader);
            if (obj.Type == JTokenType.Array)
            {
                var arr = (JArray)obj;
                if (arr.Count == 4 && arr.All(token => token.Type == JTokenType.Float))
                    return new Vector3(
                        arr[0].Value<float>(),
                        arr[1].Value<float>(),
                        arr[2].Value<float>());
            }
            return Vector3.Zero;
        }

        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteEndArray();
        }
    }

    public class Vector3dConverter : JsonConverter<Vector3d>
    {
        public override Vector3d ReadJson(JsonReader reader, Type objectType, Vector3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = JToken.Load(reader);
            if (obj.Type == JTokenType.Array)
            {
                var arr = (JArray)obj;
                if (arr.Count == 4 && arr.All(token => token.Type == JTokenType.Float))
                    return new Vector3d(
                        arr[0].Value<double>(),
                        arr[1].Value<double>(),
                        arr[2].Value<double>());
            }
            return Vector3d.Zero;
        }

        public override void WriteJson(JsonWriter writer, Vector3d value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteEndArray();
        }
    }
}
