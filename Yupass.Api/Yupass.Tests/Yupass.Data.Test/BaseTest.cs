using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yupass.Data.Context;

namespace Yupass.Data.Test;

public abstract class BaseTest
{
    public static Guid IdPerfil { get; set; }
    public BaseTest()
    {

    }

    public class DbTest : IDisposable
    {
        private string databaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer($"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};Persist Security Info=True;TrustServerCertificate=true;User ID=user_yuppie;Password=yuppie@"),
                ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            using var context = ServiceProvider.GetService<AppDbContext>();
            context?.Database.EnsureCreated();

        }
        public void Dispose()
        {
            using var context = ServiceProvider.GetService<AppDbContext>();
            context?.Database.EnsureDeleted();
        }
    }
}