using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Yupass.Data.Mapping;
using Yupass.Domain.Entities;

namespace Yupass.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<UsuariosEntity> Usuarios { get; set; }
    public DbSet<PerfisEntity> Perfis { get; set; }    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UsuariosEntity>(new UsuariosMap().Configure);
        modelBuilder.Entity<PerfisEntity>(new PerfisMap().Configure);

        InsertDefaultData(modelBuilder);
    }

    private static void InsertDefaultData(ModelBuilder modelBuilder)
    {
        #region Perfis

        var idPerfil = Guid.NewGuid();
        modelBuilder.Entity<PerfisEntity>().HasData(

            new PerfisEntity
            {
                Id = idPerfil,
                Nome = "SysAdmin",
                Permissao = "SysAdmin",
                Status = -1,
                CriadoEm = DateTime.Now
            },
            new PerfisEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Administrador",
                Permissao = "ADM",
                Status = 1,
                CriadoEm = DateTime.Now
            },
            new PerfisEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Gestão de Acessos",
                Permissao = "GA",
                Status = 1,
                CriadoEm = DateTime.Now
            },
            new PerfisEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Centro de Operações de Rede",
                Permissao = "NOC",
                Status = 1,
                CriadoEm = DateTime.Now
            }, new PerfisEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Supervisor",
                Permissao = "SUP",
                Status = 1,
                CriadoEm = DateTime.Now
            }, new PerfisEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Operacional",
                Permissao = "OPR",
                Status = 1,
                CriadoEm = DateTime.Now
            });

        #endregion

        modelBuilder.Entity<UsuariosEntity>().HasData(
            new UsuariosEntity
            {
                Id = Guid.NewGuid(),
                Cpf = "admin",
                Nome = "Administrador",
                Senha = "4cbf07ce91e4eb057dd4ea3be83ac829141cec8253be8dc167c702c35aa3b3ac", //Yupass@123
                PerfilId = idPerfil,
                CriadoEm = DateTime.Now,
                Status = 1

            },
            new UsuariosEntity
            {
                Id = Guid.NewGuid(),
                Cpf = "33667879881",
                Nome = "Pedro Rodrigues",
                Senha = "5feadddd041a836c742ccba61d11ebbc505a805552aec2cfc1225452a26683fb", //pedro@123
                PerfilId = idPerfil,
                CriadoEm = DateTime.Now,
                Status = 1
            });

    }
}