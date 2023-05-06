using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnoTest.Infrastructure;
public static class StartupExtensions
{
    public static void AddCustomPostgreSql(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddDbContext<IdentityContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });
    }
}