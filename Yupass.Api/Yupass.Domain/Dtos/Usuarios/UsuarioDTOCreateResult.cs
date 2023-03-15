namespace Yupass.Domain.Dtos.Usuarios;

public class UsuarioDTOCreateResult
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime CriadoEm { get; set; }
}
