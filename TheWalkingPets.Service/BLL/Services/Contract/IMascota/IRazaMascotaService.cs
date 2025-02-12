using System.Linq.Expressions;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.BLL.Services.Contract.IMascota
{
    public interface IRazaMascotaService
    {
        Task<Result<IEnumerable<RazaMascotaReadDto>>> GetAllAsync(Expression<Func<RazaMascota, bool>> filter);
        Task<Result<RazaMascotaReadDto>> GetByIdAsync(Guid id);
        Task<int> CountAsync(Expression<Func<RazaMascota, bool>> filter);
        Task<Result<RazaMascotaReadDto>> CreateAsync(RazaMascotaWriteDto razaMascotaWriteDto);
        Task<Result<RazaMascotaReadDto>> UpdateAsync(Guid id, RazaMascotaWriteDto razaMascotaWriteDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
