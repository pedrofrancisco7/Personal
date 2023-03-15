namespace Yupass.Domain.Dtos.Usuarios;

public class UsuarioDTOUpdateResult
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public string? Senha { get; set; }
    public string? Email { get; set; }
    public bool AcessoTemporario { get; set; }
}
