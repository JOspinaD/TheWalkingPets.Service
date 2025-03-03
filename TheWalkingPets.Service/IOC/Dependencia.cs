using Microsoft.EntityFrameworkCore;
using TheWalkingPets.Service.BLL.Services.Contract.IMascota;
using TheWalkingPets.Service.BLL.Services.Contract.IUsuarioService;
using TheWalkingPets.Service.BLL.Services.MascotaService;
using TheWalkingPets.Service.BLL.Services.UsuarioService.UsuarioService;
using TheWalkingPets.Service.DAL;
using TheWalkingPets.Service.DAL.Contract;

namespace TheWalkingPets.Service.IOC
{
    public static class Dependencia
    {
        public static IServiceCollection InyectarDependencias(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env, bool tryDbConnection = false)
        {
            if(env.IsProduction() || tryDbConnection)
            {
                Console.WriteLine("--> using SqlServer");
                var connectionString = configuration.GetConnectionString("TheWalkingPets");
                Console.WriteLine("--> connectionString:" + connectionString);
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            }
            else
            {
                Console.WriteLine("--> Using InMemory");
                services.AddDbContext<AppDbContext>(option =>
                option.UseInMemoryDatabase("TheWalkingPets"));
            }

            services.AddExceptionHandler<GlobalExcepcionHandler>();
            services.AddProblemDetails();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<PasswordService>();

            services.AddScoped<IRazaMascotaService, RazaMascotaService>();
            services.AddScoped<ITipoMascotaService, TipoMascotaService>();
            services.AddScoped<IMascotaService, MascotaService>();

            return services;
        }
    }
}
