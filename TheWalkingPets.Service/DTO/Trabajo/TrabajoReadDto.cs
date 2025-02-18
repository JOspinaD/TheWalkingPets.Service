using TheWalkingPets.Service.DTO.Base;

namespace TheWalkingPets.Service.DTO.Trabajo
{
    public class TrabajoReadDto : BaseReadDto
    {
        public string Descripcion { get; set; }
        public DateTime fechaPublicación { get; set; }
        public Boolean Estado { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdMascota { get; set; }
    }
}
