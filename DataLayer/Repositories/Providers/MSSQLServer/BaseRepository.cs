using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Providers.MSSQLServer
{
    public class BaseRepository
    {
        protected readonly string _connectionString = ConfigurationManager.ConnectionStrings["cs_mssql"].ConnectionString;
    }
}
