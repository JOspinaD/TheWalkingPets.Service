using System.Linq.Expressions;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Trabajo;
using TheWalkingPets.Service.Models.Trabajo;

namespace TheWalkingPets.Service.BLL.Services.Contract.ITrabajoService
{
    public interface IUsuarioTrabajoService
    {
        Task<Result<IEnumerable<UsuarioTrabajoReadDto>>> GetAllAsync(Expression<Func<UsuarioTrabajo, bool>> filter);
        Task<Result<UsuarioTrabajoReadDto>> GetByIdAsync(Guid id);
        Task<int> CountAsync(Expression<Func<UsuarioTrabajo, bool>> filter);
        Task<Result<UsuarioTrabajoReadDto>> CreateAsync(UsuarioTrabajoWriteDto usuarioTrabajoWriteDto);
        Task<Result<UsuarioTrabajoReadDto>> UpdateAsync(Guid id, UsuarioTrabajoWriteDto usuarioTrabajoWriteDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
