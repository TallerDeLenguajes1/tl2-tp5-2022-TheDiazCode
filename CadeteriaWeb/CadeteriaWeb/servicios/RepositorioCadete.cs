using CadeteriaWeb.Models;
using System.Data.SqlClient;

namespace CadeteriaWeb.servicios
{
    public interface IRepositorioCadete
    {
        bool Editar(CadeteDTO cadeteDTO);
        bool Eliminar(int idCadete);
        List<CadeteDTO> listar();
        CadeteDTO ObtenerId(int idCadete);
        void RegistrarCadete(CadeteDTO cadeteDTO);
    }
    public class RepositorioCadete : IRepositorioCadete
    {
        
        private readonly string connectionString;
        
        public RepositorioCadete(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       
        public void RegistrarCadete(CadeteDTO cadeteDTO)
        {
            string query = "insert into Cadete(nombre,apellido,direccion,telefono) values (@nombre,@apellido,@direccion,@telefono)";

            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@nombre",cadeteDTO.nombre);
                command.Parameters.AddWithValue("@apellido", cadeteDTO.apellido);
                command.Parameters.AddWithValue("@telefono", cadeteDTO.telefono);
                command.Parameters.AddWithValue("@direccion", cadeteDTO.direccion);
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
        public List<CadeteDTO> listar()
        {
            var lista = new List<CadeteDTO>();
            string query = "select * from Cadete";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new CadeteDTO
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
        public CadeteDTO ObtenerId(int idCadete)
        {
            var cadete = new CadeteDTO();
            string query = "select * from Cadete where id = @id";
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id",idCadete);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cadete.Id = Convert.ToInt32(reader["id"]);
                        cadete.nombre = reader["nombre"].ToString();
                        cadete.apellido = reader["apellido"].ToString();
                        cadete.direccion = reader["direccion"].ToString();
                        cadete.telefono = reader["telefono"].ToString();
                    }
                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    throw;
                }
            }
            return cadete;
        }
        public bool Editar(CadeteDTO cadeteDTO)
        {
            bool estado;
            string query = "update Cadete set nombre=@nombre, apellido=@apellido, direccion=@direccion,telefono=@telefono where Id = @id";
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Id", cadeteDTO.Id);
                command.Parameters.AddWithValue("nombre", cadeteDTO.nombre);
                command.Parameters.AddWithValue("apellido", cadeteDTO.apellido);
                command.Parameters.AddWithValue("telefono", cadeteDTO.telefono);
                command.Parameters.AddWithValue("direccion", cadeteDTO.direccion);
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
        public bool Eliminar(int idCadete)
        {
            bool estado;
            string query = "delete from Cadete where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Id", idCadete);
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
