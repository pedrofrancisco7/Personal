using System.ComponentModel.DataAnnotations;

namespace Yupass.Domain.Dtos.Usuarios;

public class UsuarioDTOUpdate
{
    [Required(ErrorMessage = "O campo Id é obrigatório")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo cpf é obrigatório")]
    [StringLength(11, ErrorMessage = "O cpf deve ter no máximo {1} caracteres")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O cpf deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    [StringLength(200, ErrorMessage = "A senha deve ter no máximo {1} caracteres")]
    public string? Senha { get; set; }
    
    public string? Email { get; set; }

    public bool AcessoTemporario { get; set; }

 }
