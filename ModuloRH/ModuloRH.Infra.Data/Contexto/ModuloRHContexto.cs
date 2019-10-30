using Microsoft.EntityFrameworkCore;
using ModuloRH.Domain.Entites;
using ModuloRH.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloRH.Infra.Data.Context
{
    public class ModuloRHContexto : DbContext
    {
        public ModuloRHContexto(DbContextOptions<ModuloRHContexto> options) : base(options)
        {
        }

        DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosConfiguration());
        }

    }
}
