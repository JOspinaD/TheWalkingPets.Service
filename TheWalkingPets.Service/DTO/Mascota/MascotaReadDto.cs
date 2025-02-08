using TheWalkingPets.Service.DTO.Base;
using TheWalkingPets.Service.DTO.Usuario;
using TheWalkingPets.Service.Models;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.DTO.Mascota
{
    public class MascotaReadDto : BaseReadDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImgMascota { get; set; }

        public Guid IdTipoRaza { get; set; }
        public Guid IdRazaMascota { get; set; }
        public Guid IdUsuario { get; set; }

        public  TipoMascotaReadDto? TipoMascota { get; set; }
        public  RazaMascotaReadDto? RazaMascota { get; set; }
        public  UsuarioReadDto? Usuario { get; set; }
    }
}
