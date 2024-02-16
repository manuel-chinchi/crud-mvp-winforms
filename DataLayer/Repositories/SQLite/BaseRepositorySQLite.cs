using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.SQLite
{
    public class BaseRepositorySQLite
    {
        public string CONNECTION_STRING
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["SQLiteDataBase"].ConnectionString;
                return cs.Replace("|DataDirectory|", AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        public bool GetStatusConnection()
        {
            try
            {
                using (var connection = new SQLiteConnection(CONNECTION_STRING))
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
