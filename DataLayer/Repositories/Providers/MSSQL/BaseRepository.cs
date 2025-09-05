using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Providers.MSSQL
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
            _connectionString = ConfigurationManager.ConnectionStrings["cs_mssql"].ConnectionString;
        }
    }
}
