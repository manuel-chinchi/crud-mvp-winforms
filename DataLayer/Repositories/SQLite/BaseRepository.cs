using DataLayer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.SQLite
{
    public class BaseRepository
    {
        protected string _connectionString;
        public BaseRepository()
        {
            var full_cs = ConfigurationManager.ConnectionStrings["cs_sqlite"].ConnectionString;
            _connectionString = full_cs.Replace("|DataDirectory|", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
