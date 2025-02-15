using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models.Trabajo
{
    public class UsuarioTrabajo : BaseEntity
    {
        public Guid? IdUsuario {  get; set; }
        public Guid? IdTrabajo { get; set; }
        public string Rol {  get; set; }
    }
}
