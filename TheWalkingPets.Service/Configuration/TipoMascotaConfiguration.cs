using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.Configuration
{
    public class TipoMascotaConfiguration : IEntityTypeConfiguration<TipoMascota>
    {
        public void Configure(EntityTypeBuilder<TipoMascota> builder)
        {
            builder.ToTable(nameof(TipoMascota));

            builder.Property(fd => fd.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(fd => fd.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnUpdate();
        }
    }
}
