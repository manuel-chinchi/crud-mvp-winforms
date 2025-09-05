using Dapper;
using DataLayer.Repositories.Contracts;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Providers.MSSQL
{
    public class CategoryRepository : BaseRepository, ICategoryRepository<Category>
    {
        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Execute(
                    "InsertCategory",
                    new
                    {
                        Name = entity.Name
                    },
                    null,
                    null,
                    CommandType.StoredProcedure
                );
            }
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
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

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> result = new List<Category>();

            using (var connection=new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                result = connection.Query<Category>("GetCategories", CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
