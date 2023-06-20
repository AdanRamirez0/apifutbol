using ProyectoFutbol_Api.Models; 
using Microsoft.EntityFrameworkCore;


namespace ProyectoFutbol_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Torneo> Torneos { get; set; } 
    }
}
