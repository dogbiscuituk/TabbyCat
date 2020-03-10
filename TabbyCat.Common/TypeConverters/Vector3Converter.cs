namespace TabbyCat.Common.Converters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenTK;
    using System;
    using System.Linq;

    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(
            JsonReader reader,
            Type objectType,
            Vector3 existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer,
            Vector3 value,
            JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.X);
            writer.WriteValue(value.Y);
            writer.WriteValue(value.Z);
            writer.WriteEndArray();
        }
    }
}
