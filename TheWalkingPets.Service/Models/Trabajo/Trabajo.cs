using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models.Trabajo
{
    public class Trabajo : BaseEntity
    {
        public string Descripcion { get; set; }
        public DateTime fechaPublicación { get; set; }
        public Boolean Estado { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdMascota { get; set; }

    }
}
