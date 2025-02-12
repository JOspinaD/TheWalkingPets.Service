using TheWalkingPets.Service.DTO.Base;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.DTO.Mascota
{
    public class RazaMascotaReadDto : BaseReadDto
    {
        public string NombreRaza { get; set; }
        public Guid? IdTipoMascota { get; set; }

        public virtual TipoMascota? TipoMascota { get; set; }
    }
}
