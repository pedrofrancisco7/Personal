using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yupass.Domain.Entities;

namespace Yupass.Data.Mapping;

public class UsuariosMap : IEntityTypeConfiguration<UsuariosEntity>
{
    public void Configure(EntityTypeBuilder<UsuariosEntity> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Cpf)
               .IsUnique();

        builder.Property(u => u.Cpf)
                .HasMaxLength(11);

        builder.Property(u => u.Nome)
               .IsRequired()
               .HasMaxLength(60);

        builder.Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(u => u.Email)
               .HasMaxLength(200);

        builder.HasOne(p => p.Perfil)
               .WithMany(p => p.Usuarios)
               .HasForeignKey(p => p.PerfilId);
    }
}
