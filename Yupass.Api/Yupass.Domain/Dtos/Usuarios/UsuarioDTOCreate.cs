using System.ComponentModel.DataAnnotations;

namespace Yupass.Domain.Dtos.Usuarios;

public class UsuarioDTOCreate
{
    [Required(ErrorMessage = "O campo cpf é obrigatório")]
    [StringLength(11, ErrorMessage = "O cpf deve ter no máximo {1} caracteres")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O cpf deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }
}
