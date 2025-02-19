using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.TrabajoErrors
{
    public class UsuarioTrabajoErrors
    {
        public static readonly Error NotExists = new(
            "UsuarioTrabajo.AlreadyExists",
            "Trabajo No encontrado");

        public static readonly Error AlreadyExists = new(
            "UsuarioTrabajo.AlreadyExists",
            "La Mascota ya existe");

        public static readonly Error Unhandled = new(
            "UsuarioTrabajo.Unhandled",
            "Error no controlado");
    }
}
