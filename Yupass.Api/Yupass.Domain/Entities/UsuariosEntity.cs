using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Yupass.Domain.Entities;

[Table("Usuarios")]
public class UsuariosEntity : BaseEntity
{

    [StringLength(11), Required]
    public string? Cpf { get; set; }

    [StringLength(60), Required]
    public string? Nome { get; set; }

    [StringLength(200), Required]
    public string? Senha { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }
    
    public Guid PerfilId { get; set; }

    public bool AcessoTemporario { get; set; }

    [ForeignKey("PerfilId")]
    [JsonIgnore]
    public virtual PerfisEntity? Perfil { get; set; }

}
