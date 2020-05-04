namespace TabbyCat.Converters
{
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using Types;

    public class SignalConverter : JsonConverter<Signal>
    {
        public override Signal ReadJson(JsonReader reader, Type t, Signal v, bool b, JsonSerializer s)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var array = (JArray)token;
                if (array.Count == 4 &&
                    array[0].Type == JTokenType.String &&
                    array[1].Type == JTokenType.Integer &&
                    array[2].Type == JTokenType.Float &&
                    array[3].Type == JTokenType.Float)
                {
                    return new Signal
                    {
                        Name = array[0].Value<string>(),
                        WaveType = (WaveType)array[1].Value<int>(),
                        Amplitude = array[2].Value<float>(),
                        Frequency = array[3].Value<float>()
                    };
                }
            }
            return new Signal();
        }

        public override void WriteJson(JsonWriter writer, Signal value, JsonSerializer s)
        {
            if (writer == null || value == null)
                return;
            writer.WriteStartArray();
            writer.WriteValue(value.Name);
            writer.WriteValue((int)value.WaveType);
            writer.WriteValue(value.Amplitude);
            writer.WriteValue(value.Frequency);
            writer.WriteEndArray();
        }
    }
}
