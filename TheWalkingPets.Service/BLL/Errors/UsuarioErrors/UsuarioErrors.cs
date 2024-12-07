using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.BLL.Errors.UsuarioErrors
{
    public class UsuarioErrors
    {
        public static readonly Error NotExists = new(
            "Usuario.NotExists",
            "Usuario no encontrado"
            );

        public static readonly Error AlreadyExists = new(
            "Usuario.AlreadyExists",
            "El usuario ya existe"
            );

        public static readonly Error Unhandled = new(
            "Usuario.Unhandled",
            "Error no controlado"
            );
    }
}
