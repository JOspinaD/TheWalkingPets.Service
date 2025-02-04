using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DTO.Usuario;

namespace TheWalkingPets.Service.BLL.Services.Contract
{
    public interface IUsuarioService
    {
        Task<Result<IEnumerable<UsuarioReadDto>>> GetAllAsync();
        Task<Result<UsuarioReadDto>> GetByIdAsync(Guid id);
        Task<Result<UsuarioReadDto>> CreateAsync(UsuarioWriteDto usuarioCreateDto);
        Task<Result<UsuarioReadDto>> UpdateAsync(Guid id, UsuarioWriteDto usuarioUpdateDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
