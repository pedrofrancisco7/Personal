using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuloRH.Domain.Entites;

namespace ModuloRH.Infra.Data.EntityConfig
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.UsuarioId);

            builder.Property(c => c.UsuarioLogin)
                .IsRequired();

            builder.Property(c => c.SenhaLogin)
                .IsRequired();
        }
    }
}
