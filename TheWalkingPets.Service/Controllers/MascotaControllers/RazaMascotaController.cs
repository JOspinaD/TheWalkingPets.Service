using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.BLL.Services.MascotaService;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.Controllers.MascotaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaMascotaController(
        IRazaMascotaService _service): ControllerBase
    {
        [HttpGet("RazaMascota")]
        public async Task<ActionResult<IEnumerable<RazaMascotaReadDto>>> GetAllAsync(Guid? idTipoMascota)
        {
            var result = await _service.GetAllAsync(r => !idTipoMascota.HasValue || r.IdTipoMascota == idTipoMascota);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("RazaMascota/{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost("RazaMascota")]
        public async Task<ActionResult<RazaMascotaReadDto>> CreateAsync(RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _service.CreateAsync(razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPut("RazaMascota/{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> UpdateAsync(Guid id, RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _service.UpdateAsync(id, razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("RazaMascota/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }

    }
}
