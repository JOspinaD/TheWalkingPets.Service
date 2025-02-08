using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models.Mascotas
{
    public class Mascota : BaseEntity
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImgMascota { get; set; }

        public Guid IdTipoRaza { get; set; }
        public Guid IdRazaMascota { get; set; }
        public Guid IdUsuario { get; set; }

        public virtual TipoMascota? TipoMascota { get; set; }
        public virtual RazaMascota? RazaMascota {get; set;}
        public virtual Usuario? Usuario { get; set; }
    }
}
