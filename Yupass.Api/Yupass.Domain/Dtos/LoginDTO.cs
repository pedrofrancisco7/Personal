using System.ComponentModel.DataAnnotations;

namespace Yupass.Domain.Dtos;

public class LoginDTO
{
    [Required(ErrorMessage = "Usuário é campo obrigatório para Login")]
    public string? Login { get; set; }
    public string? Senha { get; set; }
}
