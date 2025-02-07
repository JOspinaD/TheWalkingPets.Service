using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models.Mascotas
{
    public class RazaMascota : BaseEntity
    {
        public string NombreRaza { get; set; }
        public Guid IdTipoMascota { get; set; }

        public virtual TipoMascota TipoMascota { get; set; }
        public virtual ICollection<Mascota?> Mascotas { get; set; }
    }
}
