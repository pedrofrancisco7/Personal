namespace Yupass.Domain.Dtos.Usuarios;

public class UsuarioDTO
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Senha { get; set; }
    public DateTime CriadoEm { get; set; }
}
