using CadeteriaWeb.Models;
using System.Data.SqlClient;

namespace CadeteriaWeb.servicios
{
    public interface IRepositorioCliente
    {
        bool Editar(ClienteDTO clienteDTO);
        bool Eliminar(int idCliente);
        List<ClienteDTO> listar();
        ClienteDTO ObtenerID(int idCliente);
        void RegistrarCliente(ClienteDTO cliente);
    }
    public class RepositorioCliente : IRepositorioCliente
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
        public List<ClienteDTO> listar()
        {
            var lista = new List<ClienteDTO>();
            string query = "select * from Cliente";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new ClienteDTO
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            telefono = reader["telefono"].ToString(),
                        });
                    }
                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    throw;
                }
            }
            return lista;
        }
        public ClienteDTO ObtenerID(int idCliente)
        {
            var cliente = new ClienteDTO();
            string query = "select * from Cliente where id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", idCliente);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cliente.Id = Convert.ToInt32(reader["id"]);
                        cliente.nombre = reader["nombre"].ToString();
                        cliente.apellido = reader["apellido"].ToString();
                        cliente.direccion = reader["direccion"].ToString();
                        cliente.telefono = reader["telefono"].ToString();   
                    }
                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    throw;
                }
            }
            return cliente;
        }
        public bool Editar(ClienteDTO clienteDTO)
        {
            bool estado;
            string query = "update Cliente set nombre=@nombre, apellido=@apellido, direccion=@direccion,telefono=@telefono where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Id", clienteDTO.Id);
                command.Parameters.AddWithValue("nombre", clienteDTO.nombre);
                command.Parameters.AddWithValue("apellido", clienteDTO.apellido);
                command.Parameters.AddWithValue("telefono", clienteDTO.telefono);
                command.Parameters.AddWithValue("direccion", clienteDTO.direccion);
                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    estado = true;
                }
                catch (Exception exe)
                {
                    string error = exe.Message;
                    estado = false;
                }
                return estado;
            }
        }
        public bool Eliminar(int idCliente)
        {
            bool estado;
            string query = "delete from Cliente where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Id", idCliente);
                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    estado = true;
                }
                catch (Exception exe)
                {
                    string error = exe.Message;
                    estado = false;
                }
                return estado;
            }
        }
    }

}