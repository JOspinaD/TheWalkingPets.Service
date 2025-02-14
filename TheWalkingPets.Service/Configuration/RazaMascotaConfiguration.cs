using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.Configuration
{
    public class RazaMascotaConfiguration : IEntityTypeConfiguration<RazaMascota>
    {
        public void Configure(EntityTypeBuilder<RazaMascota> builder)
        {
            builder.ToTable(nameof(RazaMascota));

            builder.Property(fd => fd.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(fd => fd.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnUpdate();

            builder.HasOne(fd => fd.TipoMascota)
                .WithMany(fo => fo.RazaMascotas)
                .HasForeignKey(fd => fd.IdTipoMascota)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
