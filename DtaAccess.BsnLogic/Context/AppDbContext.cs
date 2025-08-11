using DtaAccess.BsnLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtaAccess.BsnLogic.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Formula> Formula { get; set; }
        public DbSet<FormulaMateriales> FormulaMateriales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Grupo)
                .WithMany(g => g.Usuarios)
                .HasForeignKey(u => u.IdGrupo);
        }
    }
}

