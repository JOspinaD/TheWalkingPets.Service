using TheWalkingPets.Service.DTO.Base;

namespace TheWalkingPets.Service.DTO.Trabajo
{
    public class UsuarioTrabajoReadDto : BaseReadDto
    {
        public Guid? IdUsuario { get; set; }
        public Guid? IdTrabajo { get; set; }
        public string Rol { get; set; }
    }
}
