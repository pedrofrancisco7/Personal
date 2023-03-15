namespace Yupass.Domain.Dtos.Perfis;

public class PerfilDTOUpdateResult
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Permissao { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public int Status { get; set; }
}
