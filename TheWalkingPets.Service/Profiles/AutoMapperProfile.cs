using AutoMapper;
using TheWalkingPets.Service.DTO.Usuario;
using TheWalkingPets.Service.Models;

namespace TheWalkingPets.Service.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioWriteDto, Usuario>();
        }
    }
}
