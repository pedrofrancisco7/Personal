using System.ComponentModel.DataAnnotations;

namespace ModuloRH.Domain.Entites
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UsuarioLogin { get; set; }
        public string SenhaLogin { get; set; }


    }
}
