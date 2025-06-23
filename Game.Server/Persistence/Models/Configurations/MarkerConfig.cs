using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;


namespace Persistence.Models.Configurations
{
    class MarkerConfig : IEntityTypeConfiguration<Marker>
    {
        public void Configure(EntityTypeBuilder<Marker> builder)
        {
            builder.HasKey(p => p.ID);

            /*var jsonOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
            };


            var positionV3Converter = new ValueConverter<Vector3Value, string>(
            // options를 명시적으로 null로 전달
            v => JsonSerializer.Serialize(v, jsonOptions),
            s => string.IsNullOrWhiteSpace(s)
                ? new Vector3Value()    // 빈 값일 땐 기본값
                : JsonSerializer.Deserialize<Vector3Value>(s, jsonOptions)!
            );

            var quaternionConverter = new ValueConverter<QuaternionValue, string>(
            q => JsonSerializer.Serialize(q, jsonOptions),
            s => string.IsNullOrWhiteSpace(s)
                 ? new QuaternionValue() // 빈 값일 땐 기본값
                 : JsonSerializer.Deserialize<QuaternionValue>(s, jsonOptions)!
            );

            var sclaeV3Converter = new ValueConverter<Vector3Value, string>(
            // options를 명시적으로 null로 전달
            v => JsonSerializer.Serialize(v, jsonOptions),
            s => string.IsNullOrWhiteSpace(s)
                 ? new Vector3Value()    // 빈 값일 땐 기본값
                 : JsonSerializer.Deserialize<Vector3Value>(s, jsonOptions)!
            );

            builder
                .Property(p => p.Position)
                .HasConversion(positionV3Converter)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Rotation)
                .HasConversion(quaternionConverter)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Scale)
                .HasConversion(sclaeV3Converter)
                .HasColumnType("nvarchar(100)");*/
        }
    }
}
