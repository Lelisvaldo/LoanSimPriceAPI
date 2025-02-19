using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoanSimPriceAPI.Converters;

public class DecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (decimal.TryParse(value, NumberStyles.Any, new CultureInfo("pt-BR"), out var result))
        {
            return result;
        }

        throw new JsonException("Invalid decimal format.");
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }
}