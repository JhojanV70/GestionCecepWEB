using GestionCecepWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Data
{
    public class GestionCecepContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=GestionCecep;Trusted_Connection=True;");
        }
    }
}
