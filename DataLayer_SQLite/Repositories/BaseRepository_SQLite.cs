using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_SQLite.Repositories
{
    public class BaseRepository_SQLite
    {
        public string _connectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
                return cs.Replace("|DataDirectory|", AppDomain.CurrentDomain.BaseDirectory);
            }
        }
    }
}
