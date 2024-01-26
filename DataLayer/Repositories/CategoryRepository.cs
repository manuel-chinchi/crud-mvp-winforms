using Dapper;
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
    public class CategoryRepository : ICategoryRepository<IEnumerable<Category>>
    {
        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB; DataBase=crud_mvp_winforms; Integrated Security=true";

        public void CreateCategory(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "InsertCategory",
                    new
                    {
                        Name = name
                    },
                    null,
                    null,
                    CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteCategory(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "DeleteCategory",
                    new
                    {
                        Id = id
                    },
                    null,
                    null,
                    CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> result;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Category>("GetCategories", CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
