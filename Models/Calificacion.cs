using System.ComponentModel.DataAnnotations;

namespace GestionCecepWEB.Models
{
    public class Calificacion
    {
        [Key] // Esto define IdCalificacion como la clave primaria
        public int IdCalificacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public float Nota { get; set; }
        public DateTime Fecha { get; set; }
    }
}
