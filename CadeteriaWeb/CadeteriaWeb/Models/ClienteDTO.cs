namespace CadeteriaWeb.Models
{
    public class ClienteDTO
    {
        static int nro = 0;
        public ClienteDTO()
        {
            Id = nro++;
        }

        public int Id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string detalles { get; set; }
    }
}
