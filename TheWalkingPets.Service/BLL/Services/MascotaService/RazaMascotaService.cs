using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheWalkingPets.Service.BLL.Errors.MascotaErrors;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DAL.Contract;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.BLL.Services.MascotaService
{
    public class RazaMascotaService : IRazaMascotaService
    {
        private readonly IGenericRepository<RazaMascota> _repository;
        private readonly IGenericRepository<TipoMascota> _tipoMascotaRepository;
        private readonly IMapper _mapper;

        public RazaMascotaService(IGenericRepository<RazaMascota> repository, IGenericRepository<TipoMascota> tipoMascotaRepository, IMapper mapper)
        {
            _repository = repository;
            _tipoMascotaRepository = tipoMascotaRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RazaMascotaReadDto>>> GetAllAsync(Expression<Func<RazaMascota, bool>> filter)
        {
            try
            {
                var result = await _repository.GetAll(filter);
                return Result.Success(
                    _mapper.Map<IEnumerable<RazaMascotaReadDto>>(result.Include(r => r.IdTipoMascota)));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<IEnumerable<RazaMascotaReadDto>>(RazaMascotaErrors.Unhandled);
            }
        }

        public async Task<Result<RazaMascotaReadDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _repository.GetBy(r => r.Id == id);
                if (result == null)
                {
                    return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.NotExists);
                }
                return Result.Success(_mapper.Map<RazaMascotaReadDto>(result));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.Unhandled);
            }
        }

        public async Task<int> CountAsync(Expression<Func<RazaMascota, bool>> filter)
        {
            try
            {
                return await _repository.Count(filter);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return 0;
            }
        }

        public async Task<Result<RazaMascotaReadDto>> CreateAsync(RazaMascotaWriteDto razaMascotaWriteDto)
        {
            try
            {
                if (razaMascotaWriteDto.IdTipoMascota.HasValue &&
                    await _tipoMascotaRepository.Count(c => c.Id == razaMascotaWriteDto.IdTipoMascota) == 0)
                {
                    return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.TipoMascotaNotFound);
                }
                var razaMascota = _mapper.Map<RazaMascota>(razaMascotaWriteDto);
                var result = await _repository.Add(razaMascota);
                return Result.Success(_mapper.Map<RazaMascotaReadDto>(result));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.Unhandled);
            }
        }

        public async Task<Result<RazaMascotaReadDto>> UpdateAsync(Guid id, RazaMascotaWriteDto razaMascotaReadDto)
        {
            try
            {
                if (razaMascotaReadDto.IdTipoMascota.HasValue &&
                    await _tipoMascotaRepository.Count(c => c.Id == razaMascotaReadDto.IdTipoMascota) == 0)
                {
                    return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.TipoMascotaNotFound);
                }

                var model = await _repository.GetBy(r => r.Id == id);
                if (model == null)
                {
                    return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.NotExists);
                }

                _mapper.Map(razaMascotaReadDto, model);
                var result = await _repository.Update(model);
                return Result.Success(_mapper.Map<RazaMascotaReadDto>(result));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<RazaMascotaReadDto>(RazaMascotaErrors.Unhandled);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var model = await _repository.GetBy(r => r.Id == id);
                if (model == null)
                {
                    return Result.Failure(RazaMascotaErrors.NotExists);
                }

                await _repository.Delete(model);
                return Result.Success();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure(RazaMascotaErrors.Unhandled);
            }
        }
    }
}
