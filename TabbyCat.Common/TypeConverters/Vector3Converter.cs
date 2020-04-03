namespace TabbyCat.Common.TypeConverters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenTK;
    using System;
    using System.Linq;

    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type t, Vector3 v, bool b, JsonSerializer s)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var array = (JArray)token;
                if (array.Count == 3 && array.All(p => p.Type == JTokenType.Float))
                    return new Vector3(
                        array[0].Value<float>(),
                        array[1].Value<float>(),
                        array[2].Value<float>());
            }
            return Vector3.Zero;
        }

        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer s)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteEndArray();
        }
    }
}
