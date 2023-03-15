using Microsoft.Extensions.DependencyInjection;
using Yupass.Data.Context;
using Yupass.Data.Repository;
using Yupass.Domain.Entities;
using Yupass.Domain.Repository;
using static Yupass.Data.Test.BaseTest;

namespace Yupass.Data.Test
{
    public class PerfilCrud : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public PerfilCrud(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD Perfil")]
        [Trait("CRUD", "PerfisEntity")]
        public async Task CRUD_Perfis()
        {
            using var context = _serviceProvider.GetService<AppDbContext>();

            var _perfilRepository = new RepositoryBase<PerfisEntity>(context);
            //var idPerfil = Guid.NewGuid();
            BaseTest.IdPerfil = Guid.NewGuid();

            PerfisEntity _entity = new PerfisEntity { 
                Id = BaseTest.IdPerfil,
                Nome = "Perfil_Teste",
                Permissao = "Permissao_Teste"
            };

            var _registroCriado = await _perfilRepository.InsertAsync(_entity);

            Assert.NotNull(_registroCriado);
            Assert.Equal("Perfil_Teste", _registroCriado.Nome);
            Assert.Equal("Permissao_Teste", _registroCriado.Permissao);
        }
    }
}
