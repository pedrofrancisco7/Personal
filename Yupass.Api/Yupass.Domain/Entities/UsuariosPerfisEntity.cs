using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yupass.Domain.Entities;

[Table("UsuariosPerfis")]
public class UsuariosPerfisEntity : BaseEntity
{
    [ForeignKey("UsuarioId")]
    [Required]
    public Guid UsuarioId { get; set; }

    [ForeignKey("PerfilId")]
    [Required]
    public Guid PerfilId { get; set; }

    [StringLength(100)]
    public string? Descricao { get; set; }

    public virtual UsuariosEntity? Usuarios { get; set; }
    public virtual PerfisEntity? Perfis { get; set; }

}
