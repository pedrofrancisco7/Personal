namespace Yupass.Domain.Models;

public class PerfilModel
{
    private Guid _id;
    private string? _nome;
    private string? _permissao;
    private DateTime? _criadoEm;
    private DateTime _atualizadoEm;
    private int _status;

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
    public string? Permissao
    {
        get { return _permissao; }
        set { _permissao = value; }
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

    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }

}
