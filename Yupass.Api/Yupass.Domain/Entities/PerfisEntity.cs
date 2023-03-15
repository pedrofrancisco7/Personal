using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yupass.Domain.Entities;

[Table("Perfis")]
public class PerfisEntity : BaseEntity
{
    public PerfisEntity()
    {
        Usuarios = new List<UsuariosEntity>();
    }

    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }

    public string? Permissao { get; set; }

    public virtual List<UsuariosEntity> Usuarios { get; set; }

}
