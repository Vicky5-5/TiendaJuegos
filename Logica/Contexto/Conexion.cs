using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TiendaJuegos.Models;

namespace Logica.Contexto
{
    public class Conexion : DbContext
    {
        public Conexion()
        {

        }
        public Conexion(DbContextOptions<Conexion> options) : base(options){ }


        public DbSet<Videojuego> Videojuegos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=DESKTOP-F14E1IH\\SQLEXPRESS;Database=TiendaVideojuegos;Trusted_Connection=True;TrustServerCertificate=True;"; // o desde config
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }

}




