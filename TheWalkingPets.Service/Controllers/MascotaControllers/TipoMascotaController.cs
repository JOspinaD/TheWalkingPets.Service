using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.Controllers.MascotaControllers.MascotaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMascotaController(
        ITipoMascotaService _tipoMascotaService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMascotaReadDto>>> GetAllAsync()
        {
            var result = await _tipoMascotaService.GetAllTipoMascotaAsync();
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("TipoMascota/{id}")]
        public async Task<ActionResult<TipoMascotaReadDto>> GetByIdAsync(Guid id)
        {
            var result = await _tipoMascotaService.GetByIdTipoAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost]
        public async Task<ActionResult<TipoMascotaReadDto>> CreateAsync(TipoMascotaWriteDto tipoMascotaWriteDto)
        {
            var result = await _tipoMascotaService.CreateTipoMascotaAsync(tipoMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails(); 
        }

        [HttpDelete]
        public async Task<ActionResult<TipoMascotaReadDto>> DeleteAsync(Guid id)
        {
            var result = await _tipoMascotaService.DeleteTipoMascotaAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }
    }
}
