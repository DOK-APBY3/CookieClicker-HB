using CookieClicker_HB.EnemyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class EnemyTemplateConverter : JsonConverter<EnemyTemplate>
    {

        public override EnemyTemplate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDoc = JsonDocument.ParseValue(ref reader);
            try
            {
                string type = jsonDoc.RootElement.GetProperty("$type").GetString();
                switch (type)
                {
                    case "ArmoredEnemyTemplaye":
                        return
                       JsonSerializer.Deserialize<ArmoredEnemyTemplaye>(jsonDoc.RootElement.GetRawText(), options);
                    case "CasualEnemeTemplate":
                        return
                       JsonSerializer.Deserialize<CasualEnemeTemplate>(jsonDoc.RootElement.GetRawText(), options);
                    case "HealingEnemyTemplate":
                        return
                       JsonSerializer.Deserialize<HealingEnemyTemplate>(jsonDoc.RootElement.GetRawText(), options);
                    case "NinjaEnemyTemplate":
                        return
                       JsonSerializer.Deserialize<NinjaEnemyTemplate>(jsonDoc.RootElement.GetRawText(), options);
                    case "UcorachEnemyTemplate":
                        return
                       JsonSerializer.Deserialize<UcorachEnemyTemplate>(jsonDoc.RootElement.GetRawText(), options);
                    default:
                        throw new NotSupportedException($"Unknown type: {type}");
                }
            }
            finally
            {
                // Освобождаем ресурс
                jsonDoc.Dispose();
            }
        }

        public override void Write(Utf8JsonWriter writer, EnemyTemplate value, JsonSerializerOptions options)
        {
            string type = value.GetType().Name; 

            string json = JsonSerializer.Serialize(value, value.GetType(), options);
            var jsonDoc = JsonDocument.Parse(json);
            try
            {
                writer.WriteStartObject();
                writer.WriteString("$type", type); 
                                                   
                foreach (var property in jsonDoc.RootElement.EnumerateObject())
                {
                    property.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            finally
            {
                jsonDoc.Dispose(); 
            }
        }

    }

    public class BigNumberJsonConverter : JsonConverter<BigNumber>
    {
        public override BigNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            

            string value = reader.GetString();

            if (string.IsNullOrEmpty(value))
            {
                return new BigNumber("0");
            }

            
            
            return new BigNumber(value);
            
        }

        public override void Write(Utf8JsonWriter writer, BigNumber value, JsonSerializerOptions options)
        {
            
            writer.WriteStringValue(value.ToString());
        }
    }
}
