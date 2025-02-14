using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.Configuration
{
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable(nameof(Mascota));

            builder.Property(fd => fd.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(fd => fd.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnUpdate();

            builder.HasOne(fd => fd.RazaMascota)
                .WithMany(fo => fo.Mascotas)
                .HasForeignKey(fd => fd.IdRazaMascota)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fd => fd.TipoMascota)
                .WithMany(fo => fo.Mascotas)
                .HasForeignKey(fd => fd.IdTipoMascota)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fd => fd.Usuario)
                .WithMany(fo => fo.Mascotas)
                .HasForeignKey(fd => fd.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
