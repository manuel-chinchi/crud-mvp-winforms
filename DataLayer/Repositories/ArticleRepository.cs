using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ArticleRepository
    {
        private DataConnection connection = new DataConnection();

        SqlDataReader drArticles;
        DataTable dtArticles = new DataTable();
        SqlCommand cmd = new SqlCommand();
        
        public DataTable GetArticles()
        {
            cmd.Connection = connection.AbrirConexion();
            cmd.CommandText = "GetArticles";
            cmd.CommandType = CommandType.StoredProcedure;
            drArticles = cmd.ExecuteReader();
            dtArticles.Load(drArticles);
            connection.CerrarConexion();
            return dtArticles;
        }
    }
}
