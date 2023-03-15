using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yupass.Data.Context;
using Yupass.Data.Crypto;
using Yupass.Data.Implementation;
using Yupass.Data.Repository;
using Yupass.Domain.Interfaces;
using Yupass.Domain.Repository;

namespace Yupass.IoC.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IUsuarioRepository, UsuarioImplementation>();
        //serviceCollection.AddTransient<IDbContext, AppDbContext>();


        //serviceCollection.AddSqlServer<MyContext>("Data Source=.\\SQLEXPRESS;Initial Catalog=YupassV2;Persist Security Info=True;TrustServerCertificate=true;User ID=sa;Password=!!Dan123");
        //serviceCollection.AddSqlServer<MyContext>("Data Source=.\\SQLEXPRESS;Initial Catalog=YupassV2;Persist Security Info=True;TrustServerCertificate=true;User ID=user_yuppie;Password=yuppie@");
        //serviceCollection.AddDbContext<MyContext>(opt => opt.UseSqlServer(new BaseCrypto().Decrypt(Environment.GetEnvironmentVariable("DB_CONNECTION"))));
        //var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=YupassV2;Persist Security Info=True;TrustServerCertificate=true;User ID=user_yuppie;Password=yuppie@";
        var connectionString = "Server=localhost; Database=YupassV2; User Id=user_yuppie; Password=yuppie@;TrustServerCertificate=true";
        serviceCollection.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}
