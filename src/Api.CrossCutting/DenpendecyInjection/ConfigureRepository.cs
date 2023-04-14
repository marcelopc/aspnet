using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;


namespace CrossCutting.DenpendecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            var connectionString = "Server=localhost;Port=3306;Database=api;Uid=root;Pwd=Windows@10";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, serverVersion)
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
        }
    }
}
