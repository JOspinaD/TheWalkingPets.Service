using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models.Mascotas
{
    public class TipoMascota : BaseEntity
    {
        public string NombreTipoMascta { get; set; }

        public virtual ICollection<RazaMascota>? RazaMascotas { get; set; }
        public virtual ICollection<Mascota>? Mascotas { get; set; }
    }
}
