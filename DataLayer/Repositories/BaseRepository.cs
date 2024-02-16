using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BaseRepository
    {
        // FIXME: System.Configuration reference not found
        //https://stackoverflow.com/questions/4431034/configurationmanager-not-found
        //private static string _connectionString = ConfigurationManager.ConnectionStrings["MicrosoftDataBase"].ConnectionString;
        //FIXME: Usar esta conexión para evitar el error "Error al crear el componente 'ListArticleView'"
        // por alguna razón no puede tomar la connexión desde App.Config usando ConfigurationManager en tiempo de diseño
        protected static string _connectionString = "Server=(localdb)\\MSSQLLocalDB; DataBase=crud_mvp_winforms; Integrated Security=true";
        
        public bool GetStatusConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
