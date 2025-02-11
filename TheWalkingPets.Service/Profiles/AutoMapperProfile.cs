using AutoMapper;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.DTO.Usuario;
using TheWalkingPets.Service.Models;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioWriteDto, Usuario>();

            CreateMap<Mascota, MascotaReadDto>();
            CreateMap<MascotaWriteDto, Mascota>();

            CreateMap<RazaMascota, RazaMascotaReadDto>();
            CreateMap<RazaMascotaWriteDto, RazaMascota>();

            CreateMap<TipoMascota, TipoMascotaReadDto>();
            CreateMap<TipoMascotaWriteDto, TipoMascota>();
        }
    }
}
