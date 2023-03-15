namespace Yupass.Domain.Dtos.Perfis;

public class PerfilDTOCreateResult
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Permissao { get; set; }
    public DateTime CriadoEm { get; set; }
    public int Status { get; set; }
}
