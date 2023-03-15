using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yupass.Domain.Entities;

namespace Yupass.Data.Mapping;

public class UsuariosPerfisMap : IEntityTypeConfiguration<UsuariosPerfisEntity>
{
    public void Configure(EntityTypeBuilder<UsuariosPerfisEntity> builder)
    {
        builder.ToTable("UsuariosPerfis");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Id)
               .IsUnique();
            
        builder.Property(up => up.UsuarioId)
               .IsRequired();

        builder.Property(up => up.PerfilId)
               .IsRequired();

        builder.Property(up => up.Descricao)
               .HasMaxLength(100);

    }
}
