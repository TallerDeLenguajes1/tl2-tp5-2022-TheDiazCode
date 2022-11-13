using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="el campo es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "el campo es obligatorio")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "el campo es obligatorio")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "el campo es obligatorio")]
        public string direccion { get; set; }
    }
}
