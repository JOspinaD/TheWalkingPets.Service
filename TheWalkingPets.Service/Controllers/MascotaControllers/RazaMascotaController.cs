using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.BLL.Services.MascotaService;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.Controllers.MascotaControllers
{
    [Route("api/raza-mascotas")]
    [ApiController]
    public class RazaMascotaController(
        IRazaMascotaService _service): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RazaMascotaReadDto>>> GetAllAsync(Guid? idTipoMascota)
        {
            var result = await _service.GetAllAsync(r => !idTipoMascota.HasValue || r.IdTipoMascota == idTipoMascota);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost]
        public async Task<ActionResult<RazaMascotaReadDto>> CreateAsync(RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _service.CreateAsync(razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> UpdateAsync(Guid id, RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _service.UpdateAsync(id, razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }

    }
}
