using System.Linq.Expressions;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.BLL.Services.Contract.IMascota
{
    public interface IMascotaService
    {
        Task<Result<IEnumerable<MascotaReadDto>>> GetAllAsync(Expression<Func<Mascota, bool>> filter);
        Task<Result<MascotaReadDto>> GetByIdAsync(Guid id);
        Task<int> CountAsync(Expression<Func<Mascota, bool>> filter);
        Task<Result<MascotaReadDto>> CreateAsync(MascotaWriteDto mascotaWriteDto);
        Task<Result<MascotaReadDto>> UpdateAsync(Guid id, MascotaWriteDto mascotaWriteDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
