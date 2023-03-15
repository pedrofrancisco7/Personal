using Microsoft.Extensions.DependencyInjection;
using Yupass.Data.Context;
using Yupass.Data.Implementation;
using Yupass.Data.Repository;
using Yupass.Domain.Entities;
using static Yupass.Data.Test.BaseTest;

namespace Yupass.Data.Test;

public class UsuarioCrud : BaseTest, IClassFixture<DbTest>
{
    private ServiceProvider _serviceProvider;
    public UsuarioCrud(DbTest dbTest)
    {
        _serviceProvider = dbTest.ServiceProvider;
    }

    [Fact(DisplayName = "CRUD Usuário")]
    [Trait("CRUD", "UsuariosEntity")]
    public async Task CRUD_Usuario()
    {
        using var context = _serviceProvider.GetService<AppDbContext>();

        #region Inclusao Perfil (Chave estrangeira)
        var _perfilRepository = new RepositoryBase<PerfisEntity>(context);        
        BaseTest.IdPerfil = Guid.NewGuid();

        PerfisEntity _entityPerfil = new PerfisEntity
        {
            Id = BaseTest.IdPerfil,
            Nome = "Perfil_Teste",
            Permissao = "Permissao_Teste"
        };

        var _registroCriadoPerfil = await _perfilRepository.InsertAsync(_entityPerfil);
        #endregion

        UsuarioImplementation _repositorio = new UsuarioImplementation(context);

        #region Inclusão Usuário
        UsuariosEntity _entity = new UsuariosEntity
        {
            Nome = "Teste",
            Senha = "senha@senha",
            Cpf = "1234567890",
            Email = "teste@email.com",
            Status = 1,
            PerfilId = BaseTest.IdPerfil
        };

        var _registroCriado = await _repositorio.InsertAsync(_entity);

        Assert.NotNull(_registroCriado);
        Assert.Equal("Teste", _registroCriado.Nome);
        Assert.Equal("senha@senha", _registroCriado.Senha);
        Assert.Equal("1234567890", _registroCriado.Cpf);
        Assert.Equal("teste@email.com", _registroCriado.Email);
        Assert.Equal("1", _registroCriado.Status.ToString());
        Assert.Equal(BaseTest.IdPerfil.ToString(), _registroCriado.PerfilId.ToString());
        #endregion

        #region Atualização Usuário        
        _entity.Nome = "TESTE_ATUALIZADO";
        _entity.Cpf = "0987654321";
        var _registroAtualizado = await _repositorio.UpdateAsync(_entity);

        Assert.NotNull(_registroAtualizado);
        Assert.Equal("TESTE_ATUALIZADO", _registroAtualizado?.Nome);
        Assert.Equal("0987654321", _registroAtualizado?.Cpf);
        #endregion

        #region Get Usuário
        if (_registroAtualizado == null) return;
        var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
        Assert.NotNull(_registroSelecionado);
        Assert.Equal(_registroAtualizado.Nome, _registroSelecionado?.Nome);
        Assert.Equal(_registroAtualizado.Cpf, _registroSelecionado?.Cpf);
        Assert.Equal(_registroAtualizado.Senha, _registroSelecionado?.Senha);
        Assert.Equal(_registroAtualizado.Email, _registroSelecionado?.Email);
        #endregion

        #region Get All
        var _todosRegistros = await _repositorio.SelectAsync();
        Assert.NotNull(_todosRegistros);
        Assert.True(_todosRegistros.Count() > 1);
        #endregion

        #region Delete Usuario
        if (_registroSelecionado == null) return;
        
        var remover = await _repositorio.DeleteAsync(_registroSelecionado.Id);
        Assert.True(remover);
        #endregion

        #region Login
        var _admin = await _repositorio.FindByLogin("admin", "4cbf07ce91e4eb057dd4ea3be83ac829141cec8253be8dc167c702c35aa3b3ac");
        Assert.NotNull(_admin);
        Assert.Equal("Administrador", _admin?.Nome);
        Assert.Equal("admin", _admin?.Cpf);
        Assert.Equal("4cbf07ce91e4eb057dd4ea3be83ac829141cec8253be8dc167c702c35aa3b3ac", _admin?.Senha);        
        #endregion

    }
}
