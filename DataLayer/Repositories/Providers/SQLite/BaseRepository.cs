using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Providers.SQLite
{
    public class BaseRepository
    {
        private readonly string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public BaseRepository()
        {
            var cs = ConfigurationManager.ConnectionStrings["cs_sqlite"].ConnectionString;
            _connectionString = cs.Replace("|DataDirectory|", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
