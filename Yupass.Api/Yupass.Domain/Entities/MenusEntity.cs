using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yupass.Domain.Entities;

[Table("Menus")]
public class MenusEntity : BaseEntity
{
    [Required]
    public string? NomeMenu { get; set; }
    public string? Router { get; set; }
    public string? ClassName { get; set; }
    public Guid IdPerfil { get; set; }
    public Guid IdSubMenu { get; set; }

}
