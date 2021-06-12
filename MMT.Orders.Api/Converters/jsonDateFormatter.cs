using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MMT.Orders.Api.Convertors
{
    public class JsonDateFormatter : JsonConverter<DateTime>
    {
        public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            return DateTime.Parse( reader.GetString() );
        }

        public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options )
        {
            // format 03-May-2021 09:15
            if ( value.TimeOfDay == TimeSpan.Zero )
            {
                writer.WriteStringValue( value.ToLocalTime().ToString( "dd-MM-yyyy" ) );
            }
            else
            {
                writer.WriteStringValue( value.ToLocalTime().ToString( "dd-MM-yyyy HH:mm" ) );
            }

        }
    }
}
