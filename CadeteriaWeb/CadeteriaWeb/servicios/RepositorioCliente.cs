using CadeteriaWeb.Models;
namespace CadeteriaWeb.servicios
{
    public interface IRepositorioCliente
    {
        List<ClienteDTO> ObtenerClientes();
        List<ClienteDTO> RegistrarClientes(ClienteDTO cliente);
    }
    public class RepositorioCliente:IRepositorioCliente
    {
        private List<ClienteDTO> lista = new List<ClienteDTO>();

        public List<ClienteDTO> RegistrarClientes(ClienteDTO cliente)
        {
           lista.Add(cliente);
           return lista;
        }
        public List<ClienteDTO> ObtenerClientes()
        {
            return lista;
        }




    }

  
}
