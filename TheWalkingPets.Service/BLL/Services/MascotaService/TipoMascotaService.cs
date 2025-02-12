
using AutoMapper;
using TheWalkingPets.Service.BLL.Errors.MascotaErrors;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DAL.Contract;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.BLL.Services.MascotaService
{
    public class TipoMascotaService(IGenericRepository<TipoMascota> repository, IMapper mapper) : ITipoMascotaService
    {
        private readonly IGenericRepository<TipoMascota> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IEnumerable<TipoMascotaReadDto>>> GetAllTipoMascotaAsync()
        {
            try
            {
                var result = await _repository.GetAll();
                return Result.Success(_mapper.Map<IEnumerable<TipoMascotaReadDto>>(result));
            }
            catch
            {
                return Result.Failure<IEnumerable<TipoMascotaReadDto>>(TipoMascotaErrors.Unhandled);
            }
        }

        public async Task<Result<TipoMascotaReadDto>> GetByIdTipoAsync(Guid id)
        {
            try
            {
                var result = await _repository.GetBy(t => t.Id == id);
                if (result == null)
                {
                    return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.NotExists);
                }
                return Result.Success(_mapper.Map<TipoMascotaReadDto>(result));
            }
            catch
            {
                return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.Unhandled);
            }
        }

        public async Task<Result<TipoMascotaReadDto>> CreateTipoMascotaAsync(TipoMascotaWriteDto tipoMascotaWriteDto)
        {
            try
            {
                if (await _repository.Count(t => t.NombreTipoMascota == tipoMascotaWriteDto.NombreTipoMascota) > 0)
                {
                    return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.AlreadyExists);
                }

                var model = mapper.Map<TipoMascota>(tipoMascotaWriteDto);
                var result = await _repository.Add(model);
                return Result.Success(_mapper.Map<TipoMascotaReadDto>(result));
            }
            catch
            {
                return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.Unhandled);
            }
        }

        public async Task<Result<TipoMascotaReadDto>> UpdateTipoMascotaAsync(Guid id, TipoMascotaWriteDto tipoMascotaWriteDto)
        {
            try
            {
                var model = await _repository.GetBy(t => t.Id == id);
                if (model == null)
                {
                    return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.NotExists);
                }

                _mapper.Map(tipoMascotaWriteDto, model);
                var result = await _repository.Update(model);
                return Result.Success(_mapper.Map<TipoMascotaReadDto>(result));
            }
            catch
            {
                return Result.Failure<TipoMascotaReadDto>(TipoMascotaErrors.Unhandled);
            }
        }

        public async Task<Result> DeleteTipoMascotaAsync(Guid id)
        {
            try
            {
                var model = await _repository.GetBy(t => t.Id == id);
                if (model == null)
                {
                    return TipoMascotaErrors.NotExists;
                }
                var response = await _repository.Delete(model);

                return Result.Success(response);
            }
            catch
            {
                return TipoMascotaErrors.Unhandled;
            }
        }
    }
}
