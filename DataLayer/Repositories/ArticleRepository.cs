using DataLayer.Models;
using EntityLayer.Models;
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
        private DataConnection _connection = new DataConnection();

        SqlDataReader drArticles;
        DataTable dtArticles = new DataTable();
        SqlCommand cmd = new SqlCommand();
        
        public DataTable GetArticles()
        {
            cmd.Connection = _connection.OpenConnection();
            cmd.CommandText = "GetArticles";
            cmd.CommandType = CommandType.StoredProcedure;
            drArticles = cmd.ExecuteReader();
            dtArticles.Load(drArticles);
            _connection.CloseConnection();
            return dtArticles;
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            cmd.Connection = _connection.OpenConnection();
            cmd.CommandText = "InsertArticle";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Brand", brand);
            cmd.Parameters.AddWithValue("@Stock", stock);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            _connection.CloseConnection();
        }

        public void EditArticle(string name, string description, string brand, string stock, string id)
        {
            cmd.Connection = _connection.OpenConnection();
            cmd.CommandText = "UpdateArticle";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Brand", brand);
            cmd.Parameters.AddWithValue("@Stock", stock);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            _connection.CloseConnection();
        }

        public void DeleteArticle(string id)
        {
            cmd.Connection = _connection.OpenConnection();
            cmd.CommandText = "DeleteArticle";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            _connection.CloseConnection();
        }
    }
}
