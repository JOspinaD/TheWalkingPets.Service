using TheWalkingPets.Service.Models.Base;

namespace TheWalkingPets.Service.Models
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string HashContraseña { get; set; }
        public string? Salt {  get; set; }
        public int? Edad {  get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
