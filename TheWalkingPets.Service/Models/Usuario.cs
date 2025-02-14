using TheWalkingPets.Service.Models.Base;
using TheWalkingPets.Service.Models.Mascotas;

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

        public virtual ICollection<Mascota>? Mascotas { get; set; }
    }
}
