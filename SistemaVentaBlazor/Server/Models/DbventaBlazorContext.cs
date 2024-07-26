using Microsoft.EntityFrameworkCore;
using SistemaPlania.Server.Models;

namespace SistemaPlania.Server.DataBase
{
    public class DbventaBlazorContext : DbContext
    {
        public DbventaBlazorContext(DbContextOptions<DbventaBlazorContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<NumeroDocumento> NumeroDocumentos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.IdRolNavigation)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.IdCategoriaNavigation)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.IdVentaNavigation)
                .WithMany(v => v.DetalleVenta)
                .HasForeignKey(dv => dv.IdVenta);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.IdProductoNavigation)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(dv => dv.IdProducto);
        }
    }
}
