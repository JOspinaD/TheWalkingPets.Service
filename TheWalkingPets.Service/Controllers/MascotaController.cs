using Microsoft.AspNetCore.Mvc;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.Controllers.Extensions;
using TheWalkingPets.Service.DTO.Mascota;

namespace TheWalkingPets.Service.Controllers
{
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

        [HttpGet("{id}", Name = "GetMascotaById")]
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

        [HttpGet("RazaMascota")]
        public async Task<ActionResult<IEnumerable<RazaMascotaReadDto>>> GetAllAsync(Guid? idTipoMascota)
        {
            var result = await _razaMascotaService.GetAllAsync(r => !idTipoMascota.HasValue || r.IdTipoMascota == idTipoMascota);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("RazaMascota/{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> GetByIdAsync(Guid id)
        {
            var result = await _razaMascotaService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost("RazaMascota")]
        public async Task<ActionResult<RazaMascotaReadDto>> CreateAsync( RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _razaMascotaService.CreateAsync(razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPut("RazaMascota/{id}")]
        public async Task<ActionResult<RazaMascotaReadDto>> UpdateAsync(Guid id,  RazaMascotaWriteDto razaMascotaWriteDto)
        {
            var result = await _razaMascotaService.UpdateAsync(id, razaMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("RazaMascota/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _razaMascotaService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }

        [HttpGet("TipoMascota")]
        public async Task<ActionResult<IEnumerable<TipoMascotaReadDto>>> GetAllTipoMascotaAsync()
        {
            var result = await _tipoMascotaService.GetAllTipoMascotaAsync();
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpGet("TipoMascota/{id}")]
        public async Task<ActionResult<TipoMascotaReadDto>> GetByIdTipoAsync(Guid id)
        {
            var result = await _tipoMascotaService.GetByIdTipoAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost("TipoMascota")]
        public async Task<ActionResult<TipoMascotaReadDto>> CreateTipoMascotaAsync( TipoMascotaWriteDto tipoMascotaWriteDto)
        {
            var result = await _tipoMascotaService.CreateTipoMascotaAsync(tipoMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPut("TipoMascota/{id}")]
        public async Task<ActionResult<TipoMascotaReadDto>> UpdateTipoMascotaAsync(Guid id,  TipoMascotaWriteDto tipoMascotaWriteDto)
        {
            var result = await _tipoMascotaService.UpdateTipoMascotaAsync(id, tipoMascotaWriteDto);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpDelete("TipoMascota/{id}")]
        public async Task<ActionResult> DeleteTipoMascotaAsync(Guid id)
        {
            var result = await _tipoMascotaService.DeleteTipoMascotaAsync(id);
            return result.IsSuccess ? Ok(result.IsSuccess) : result.ToProblemDetails();
        }
    }
}
