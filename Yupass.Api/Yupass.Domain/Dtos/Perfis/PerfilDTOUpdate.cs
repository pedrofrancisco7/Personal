using System.ComponentModel.DataAnnotations;

namespace Yupass.Domain.Dtos.Perfis;

public class PerfilDTOUpdate
{
    [Required(ErrorMessage = "O campo Id é obrigatório")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [StringLength(50, ErrorMessage = "O Nome deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O campo Permissao é obrigatório")]
    [StringLength(200, ErrorMessage = "A Permissao deve ter no máximo {1} caracteres")]
    public string? Permissao { get; set; }

    public int Status { get; set; }

}
