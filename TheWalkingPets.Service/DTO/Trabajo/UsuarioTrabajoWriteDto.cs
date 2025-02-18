namespace TheWalkingPets.Service.DTO.Trabajo
{
    public class UsuarioTrabajoWriteDto
    {
        public Guid? IdUsuario { get; set; }
        public Guid? IdTrabajo { get; set; }
        public string Rol { get; set; }
    }
}
