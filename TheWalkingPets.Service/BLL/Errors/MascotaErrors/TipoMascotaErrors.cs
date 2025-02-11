using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.MascotaErrors
{
    public class TipoMascotaErrors
    {
        public static readonly Error NotExists = new(
            "TipoMascota.AlreadyExists",
            "Tipo de Mascota no encontrada");

        public static readonly Error AlreadyExists = new(
            "TipoMascota.AlreadyExists",
            "El tipo de Mascota ya existe");

        public static readonly Error Unhandled = new(
            "TipoMascota.Unhandled",
             "Error no controlado");
    }
}
