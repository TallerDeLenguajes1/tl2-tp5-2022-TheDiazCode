using CadeteriaWeb.Models;
using System.Data.SqlClient;

namespace CadeteriaWeb.servicios
{
    public interface IRepositorioCliente
    {
        void RegistrarCliente(ClienteDTO cliente);
    }
    public class RepositorioCliente:IRepositorioCliente
    {
        private readonly string connectionString;

        public RepositorioCliente(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void RegistrarCliente(ClienteDTO clienteDTO)
        {
            string query = "insert into Cliente(nombre,apellido,direccion,telefono) values (@nombre,@apellido,@direccion,@telefono)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@nombre", clienteDTO.nombre);
                command.Parameters.AddWithValue("@apellido", clienteDTO.apellido);
                command.Parameters.AddWithValue("@telefono", clienteDTO.telefono);
                command.Parameters.AddWithValue("@direccion", clienteDTO.direccion);
                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    throw;
                }
            }

        }
    }
}