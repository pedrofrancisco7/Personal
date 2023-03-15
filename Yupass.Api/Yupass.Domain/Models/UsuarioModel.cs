namespace Yupass.Domain.Models;

public class UsuarioModel
{
    private Guid _id;
    private string? _nome;
    private string? _cpf;
    private string? _senha;
    private DateTime? _criadoEm;
    private DateTime _atualizadoEm;

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string? Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }
    public string? Cpf
    {
        get { return _cpf; }
        set { _cpf = value; }
    }

    public string? Senha
    {
        get { return _senha; }
        set { _senha = value; }
    }

    public DateTime? CriadoEm
    {
        get { return _criadoEm; }
        set { _criadoEm = value == null ? DateTime.UtcNow : value; }
    }
    public DateTime AtualizadoEm
    {
        get { return _atualizadoEm; }
        set { _atualizadoEm = value; }
    }

}
