using CadeteriaWeb.Models;
using System.Data.SqlClient;

namespace CadeteriaWeb.servicios
{
    public interface IRepositorioCadete
    {
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
    }

   
}
