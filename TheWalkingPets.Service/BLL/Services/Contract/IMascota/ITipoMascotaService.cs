using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.BLL.Services.Contract.IMascota
{
    public interface ITipoMascotaService
    {
        Task<Result<IEnumerable<TipoMascotaReadDto>>> GetAllTipoMascotaAsync();
        Task<Result<TipoMascotaReadDto>> GetByIdTipoAsync(Guid id);
        Task<Result<TipoMascotaReadDto>> CreateTipoMascotaAsync(TipoMascotaWriteDto tipoMascotaWriteDto);
        Task<Result<TipoMascotaReadDto>> UpdateTipoMascotaAsync(Guid id, TipoMascotaWriteDto tipoMascotaWriteDto);
        Task<Result> DeleteTipoMascotaAsync(Guid id);
    }
}
