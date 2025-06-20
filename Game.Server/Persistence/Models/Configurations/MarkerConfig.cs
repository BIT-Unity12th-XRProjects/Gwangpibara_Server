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


            var vector3Converter = new ValueConverter<Vector3Value, string>(
            // options를 명시적으로 null로 전달
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            s => JsonSerializer.Deserialize<Vector3Value>(s, (JsonSerializerOptions?)null)!
            );

            var quaternionConverter = new ValueConverter<QuaternionValue, string>(
            q => JsonSerializer.Serialize(q, (JsonSerializerOptions?)null),
            s => JsonSerializer.Deserialize<QuaternionValue>(s, (JsonSerializerOptions?)null)!
            );


            builder.Property(p => p.position)
                .HasConversion(vector3Converter)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.rotation)
                .HasConversion(quaternionConverter)
                .HasColumnType("nvarchar(100)");
        }
    }
}
