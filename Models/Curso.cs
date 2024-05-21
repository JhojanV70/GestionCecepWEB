using System.ComponentModel.DataAnnotations;

namespace GestionCecepWEB.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public int IdProfesor { get; set; } // FK
        public Profesor? Profesor { get; set; } // Propiedad de navegación
        public ICollection<Estudiante> Estudiantes { get; set; } // Relación uno a muchos

    }
}
