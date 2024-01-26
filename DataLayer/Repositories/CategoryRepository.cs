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
    public class CategoryRepository : BaseRepository, ICategoryRepository<IEnumerable<Category>>
    {
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
