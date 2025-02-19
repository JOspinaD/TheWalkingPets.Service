using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.TrabajoErrors
{
    public class TrabajoErrors
    {
        public static readonly Error NotExists = new(
            "Trabajo.AlreadyExists",
            "Trabajo No encontrado");

        public static readonly Error AlreadyExists = new(
            "Trabajo.AlreadyExists",
            "La Mascota ya existe");

        public static readonly Error Unhandled = new(
            "Trabajo.Unhandled",
            "Error no controlado");
    }
}
