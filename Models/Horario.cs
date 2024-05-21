using System.ComponentModel.DataAnnotations;

namespace GestionCecepWEB.Models
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }
        public int IdCurso { get; set; } // FK
        public string DiaSemana { get; set; }               
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
