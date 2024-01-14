using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DataConnection
    {
        const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB; DataBase=crud_mvp_winforms; Integrated Security=true";
        private SqlConnection _connection = new SqlConnection(CONNECTION_STRING);

        public SqlConnection OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public SqlConnection CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            return _connection;
        }
    }
}
