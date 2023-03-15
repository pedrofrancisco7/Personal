using Microsoft.Extensions.DependencyInjection;
using Yupass.Application.Services;
using Yupass.Domain.Interfaces.Services.Perfis;
using Yupass.Domain.Interfaces.Services.Users;
using Yupass.Service.Services;

namespace Yupass.IoC.DependencyInjection;

public class ConfigureService
{
    public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUsuariosService, UsuariosService>();
        serviceCollection.AddTransient<ILoginService, LoginService>();
        serviceCollection.AddTransient<IPerfisService, PerfisService>();
    }
}