namespace Yupass.Domain.Dtos.Perfis;

public class PerfilDTO
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Permissao { get; set; }
    public DateTime CriadoEm { get; set; }
}
