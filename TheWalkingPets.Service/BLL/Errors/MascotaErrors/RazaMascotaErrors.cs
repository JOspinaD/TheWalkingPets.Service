using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.MascotaErrors
{
    public class RazaMascotaErrors
    {
        public static readonly Error NotExists = new(
            "RazaMascota.AlreadyExists",
            "Raza de Mascota no encontrada");

        public static readonly Error AlreadyExists = new(
            "RazaMascota.AlreadyExists",
            "La Raza de Mascota ya existe");

        public static readonly Error TipoMascotaNotFound = new(
            "RazaMascota.TipoMascotaNotFound",
             "Tipo de Mascota no encontrado");

        public static readonly Error Unhandled = new(
            "RazaMascota.Unhandled",
             "Error no controlado");

    }
}
