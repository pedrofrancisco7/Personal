using System.ComponentModel.DataAnnotations;

namespace Yupass.Domain.Dtos.Perfis;

public class PerfilDTOCreate
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [StringLength(50, ErrorMessage = "O Nome deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O campo Permissao é obrigatório")]
    [StringLength(200, ErrorMessage = "A Permissao deve ter no máximo {1} caracteres")]
    public string? Permissao { get; set; }
}
