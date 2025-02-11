namespace TheWalkingPets.Service.DTO.Mascota
{
    public class MascotaWriteDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImgMascota { get; set; }

        public Guid? IdTipoMascota { get; set; }
        public Guid? IdRazaMascota { get; set; }
        public Guid? IdUsuario { get; set; }
    }
}
