using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yupass.Domain.Entities;

namespace Yupass.Data.Mapping;

public class PerfisMap : IEntityTypeConfiguration<PerfisEntity>
{
    public void Configure(EntityTypeBuilder<PerfisEntity> builder)
    {
        builder.ToTable("Perfis");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Id)
               .IsUnique();

        builder.Property(u => u.Nome)
                .HasMaxLength(50)
                .IsRequired();

        builder.HasMany(u => u.Usuarios)
               .WithOne(p => p.Perfil)
               .HasForeignKey(p => p.PerfilId);

    }
}
