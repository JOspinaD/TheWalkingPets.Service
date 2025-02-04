using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Usuario;

namespace TheWalkingPets.Service.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class UsuarioController(IUsuarioService _service): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("/usuario{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> Post(UsuarioWriteDto usuarioWriteDto)
        {
            var result = await _service.CreateAsync(usuarioWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPut("/Usuario{id}")]
        public async Task<ActionResult<UsuarioReadDto>> Put(Guid id, UsuarioWriteDto usuarioWriteDto)
        {
            var result = await _service.UpdateAsync(id, usuarioWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("/usuario{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok() : result.ToProblemDetails();
        }
    }
}
