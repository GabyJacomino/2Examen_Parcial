using Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace Datos
{
    public class ParcialContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Infractor>()
                   .HasOne<Infraccion>(ictor => ictor.Infraccion)
                   .WithMany(icion => icion.Infractores)
                   .HasForeignKey(ictor => ictor.CodInfraccion);

            modelBuilder.Entity<Liquidacion>()
                .HasOne<Infractor>(liq => liq.Infractor)
                .WithOne(ictor => ictor.Liquidacion)
                .HasForeignKey<Liquidacion>(liq => liq.IdInfraccion);
        }

        public DbSet<Infractor> Infractores { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
    }
}