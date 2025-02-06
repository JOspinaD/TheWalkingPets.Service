using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
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

            return services;
        }
    }
}
