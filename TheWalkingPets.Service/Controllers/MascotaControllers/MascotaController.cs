using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.Controllers.MascotaControllers.MascotaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController(
        IMascotaService _service,
        IRazaMascotaService _razaMascotaService,
        ITipoMascotaService _tipoMascotaService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MascotaReadDto>>> GetAll(Guid? idUsario)
        {
            var result = await _service.GetAllAsync(r => !idUsario.HasValue || r.IdUsuario == idUsario);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("Mascota/{id}", Name = "GetMascotaById")]
        public async Task<ActionResult<MascotaReadDto>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost]
        public async Task<ActionResult<MascotaReadDto>> Post( MascotaWriteDto mascotaWriteDto)
        {
            var result = await _service.CreateAsync(mascotaWriteDto);
            return result.IsSuccess
                ? CreatedAtRoute("GetMascotaById", new { id = result.Value.Id }, result.Value)
                : result.ToProblemDetails();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MascotaReadDto>> Put(Guid id,  MascotaWriteDto mascotaWriteDto)
        {
            var result = await _service.UpdateAsync(id, mascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }

        

    }
}
