using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheWalkingPets.Service.BLL.Errors.MascotaErrors;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.common;
using TheWalkingPets.Service.DAL.Contract;
using TheWalkingPets.Service.DTO.Mascota;
using TheWalkingPets.Service.Models;
using TheWalkingPets.Service.Models.Mascotas;

namespace TheWalkingPets.Service.BLL.Services.MascotaService
{
    public class MascotaService : IMascotaService
    {
        private readonly IGenericRepository<Mascota> _repository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<TipoMascota> _tipoMascotaRepository;
        private readonly IGenericRepository<RazaMascota> _razaMascotaRepository;
        private readonly IMapper _mapper;

        public MascotaService(
            IGenericRepository<Mascota> repository,
            IGenericRepository<Usuario> usuarioRepository,
            IGenericRepository<TipoMascota> tipoMascota,
            IGenericRepository<RazaMascota> razaMascota,
            IMapper mapper)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _tipoMascotaRepository = tipoMascota;
            _razaMascotaRepository= razaMascota;
            _mapper = mapper;

        }

        public async Task<Result<IEnumerable<MascotaReadDto>>> GetAllAsync(Expression<Func<Mascota, bool>> filter)
        {
            try
            {
                var result = await _repository.GetAll(filter);
                return Result.Success(
                    _mapper.Map<IEnumerable<MascotaReadDto>>(result.Include(r => r.Usuario).Include(r => r.RazaMascota).Include(r => r.TipoMascota)));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<IEnumerable<MascotaReadDto>>(MascotaErrors.Unhandled);
            }
        }

        public async Task<Result<MascotaReadDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _repository.GetAll(r => r.Id == id);
                if (result == null || !result.Any())
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.NotExists);
                }
                return Result.Success(
                    _mapper.Map<MascotaReadDto>(result.Include(r => r.Usuario).Include(r => r.RazaMascota).Include(r => r.TipoMascota).FirstOrDefault()));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<MascotaReadDto>(MascotaErrors.Unhandled);
            }
        }

        public async Task<int> CountAsync(Expression<Func<Mascota, bool>> filter)
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

        public async Task<Result<MascotaReadDto>> CreateAsync(MascotaWriteDto mascotaWriteDto)
        {
            try
            {
                if (mascotaWriteDto.IdTipoMascota.HasValue &&
                    await _tipoMascotaRepository.Count(c => c.Id == mascotaWriteDto.IdTipoMascota) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.TipoMascotaNotFound);
                }

                if (mascotaWriteDto.IdRazaMascota.HasValue &&
                    await _razaMascotaRepository.Count(c => c.Id == mascotaWriteDto.IdRazaMascota) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.RazaMascotaNotFound);
                }

                if (mascotaWriteDto.IdUsuario.HasValue &&
                    await _usuarioRepository.Count(c => c.Id == mascotaWriteDto.IdUsuario) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.UsuarioNotFound);
                }

                var mascota = _mapper.Map<Mascota>(mascotaWriteDto);
                var result = await _repository.Add(mascota);
                return Result.Success(_mapper.Map<MascotaReadDto>(result));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<MascotaReadDto>(MascotaErrors.Unhandled);
            }
        }

        public async Task<Result<MascotaReadDto>> UpdateAsync(Guid id, MascotaWriteDto mascotaWriteDto)
        {
            try
            {
                var model = await _repository.GetBy(r => r.Id == id);
                if (model == null)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.NotExists);
                }

                if (mascotaWriteDto.IdTipoMascota.HasValue &&
                    await _tipoMascotaRepository.Count(c => c.Id == mascotaWriteDto.IdTipoMascota) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.TipoMascotaNotFound);
                }

                if (mascotaWriteDto.IdRazaMascota.HasValue &&
                    await _razaMascotaRepository.Count(c => c.Id == mascotaWriteDto.IdRazaMascota) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.RazaMascotaNotFound);
                }

                if (mascotaWriteDto.IdUsuario.HasValue &&
                    await _usuarioRepository.Count(c => c.Id == mascotaWriteDto.IdUsuario) == 0)
                {
                    return Result.Failure<MascotaReadDto>(MascotaErrors.UsuarioNotFound);
                }

                _mapper.Map(mascotaWriteDto, model);
                var result = await _repository.Update(model);
                return Result.Success(_mapper.Map<MascotaReadDto>(result));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure<MascotaReadDto>(MascotaErrors.Unhandled);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var mascota = await _repository.GetBy(r => r.Id == id);
                if (mascota == null)
                {
                    return Result.Failure(MascotaErrors.NotExists);
                }

                await _repository.Delete(mascota);
                return Result.Success();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("---> ERROR: " + ex.Message);
                return Result.Failure(MascotaErrors.Unhandled);
            }
        }



    }
}
