using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Yupass.Data.Crypto;

namespace Yupass.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        //var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=YupassV2;Persist Security Info=True;TrustServerCertificate=true;User ID=sa;Password=!!Dan123";
        //var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=YupassV2;Persist Security Info=True;TrustServerCertificate=true;User ID=user_yuppie;Password=yuppie@";
        var connectionString = "Server=localhost; Database=YupassV2; User Id=user_yuppie; Password=yuppie@;TrustServerCertificate=true;";
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        //var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        //optionsBuilder.UseSqlServer(new BaseCrypto().Decrypt(connectionString));
        return new AppDbContext(optionsBuilder.Options);
        
    }
}

