namespace TabbyCat.Converters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using Types;

    public class Vector3iConverter : JsonConverter<Vector3i>
    {
        public override Vector3i ReadJson(JsonReader reader, Type t, Vector3i v, bool b, JsonSerializer s)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var array = (JArray)token;
                if (array.Count == 3 && array.All(p => p.Type == JTokenType.Integer))
                    return new Vector3i(
                        array[0].Value<int>(),
                        array[1].Value<int>(),
                        array[2].Value<int>());
            }
            return Vector3i.Zero;
        }

        public override void WriteJson(JsonWriter writer, Vector3i value, JsonSerializer s)
        {
            if (writer == null || value == null)
                return;
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteEndArray();
        }
    }
}
