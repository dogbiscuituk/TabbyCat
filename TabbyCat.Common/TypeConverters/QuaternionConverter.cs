namespace TabbyCat.Common.TypeConverters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenTK;
    using System;
    using System.Linq;

    public class QuaternionConverter : JsonConverter<Quaternion>
    {
        public override Quaternion ReadJson(JsonReader reader, Type t, Quaternion v, bool b, JsonSerializer s)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var array = (JArray)token;
                if (array.Count == 4 && array.All(p => p.Type == JTokenType.Float))
                    return new Quaternion(
                        x: array[0].Value<float>(),
                        y: array[1].Value<float>(),
                        z: array[2].Value<float>(),
                        w: array[3].Value<float>());
            }
            return Quaternion.Identity;
        }

        public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer s)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteValue(value.W);
            writer.WriteEndArray();
        }
    }
}
