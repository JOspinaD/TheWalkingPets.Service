using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.MascotaErrors
{
    public class MascotaErrors
    {
        public static readonly Error NotExists = new(
            "Mascota.AlreadyExists",
            "Mascota No encontrada");

        public static readonly Error AlreadyExists = new(
            "Mascota.AlreadyExists",
            "La Mascota ya existe");

        public static readonly Error TipoMascotaNotFound = new(
            "Mascota.TipoMascotaNotFound",
             "Tipo de Mascota no encontrado");

        public static readonly Error RazaMascotaNotFound = new(
          "Mascota.RazaMascotaNotFound",
           "Raza de Mascota no encontrado");

        public static readonly Error UsuarioNotFound = new(
          "Mascota.UsuarioNotFound",
            "Usuario no encontrado");

        public static readonly Error Unhandled = new(
            "Mascota.Unhandled",
            "Error no controlado");
    }
}
