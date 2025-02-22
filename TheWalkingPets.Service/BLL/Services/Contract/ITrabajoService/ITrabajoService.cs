using System.Linq.Expressions;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Trabajo;
using TheWalkingPets.Service.Models.Trabajo;

namespace TheWalkingPets.Service.BLL.Services.Contract.ITrabajoService
{
    public interface ITrabajoService
    {
        Task<Result<IEnumerable<TrabajoReadDto>>> GetAllAsync(Expression<Func<Trabajo, bool>> filter);
        Task<Result<TrabajoReadDto>> GetByIdAsync(Guid id);
        Task<int> CountAsync(Expression<Func<Trabajo, bool>> filter);
        Task<Result<TrabajoReadDto>> CreateAsync(TrabajoWriteDto trabajoWriteDto);
        Task<Result<TrabajoReadDto>> UpdateAsync(Guid id, TrabajoWriteDto trabajoWriteDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
