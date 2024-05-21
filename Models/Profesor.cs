using System.ComponentModel.DataAnnotations;

namespace GestionCecepWEB.Models
{
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
