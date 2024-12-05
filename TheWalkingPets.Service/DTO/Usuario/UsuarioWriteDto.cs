namespace TheWalkingPets.Service.DTO.Usuario
{
    public class UsuarioWriteDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string HashContraseña { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
