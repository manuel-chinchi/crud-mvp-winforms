using DataLayer.Repositories.Contracts;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Providers.SQLite
{
    public class CategoryRepository : BaseRepository, ICategoryRepository<Category>
    {
        #region metodos base
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_DELTECATEGORY, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_GETCATEGORIES, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var name = reader["name"];
                        var dateCreated = reader["dateCreated"];
                        var articlesRelated = reader["articlesRelated"];

                        categories.Add(new Category()
                        {
                            Id = Convert.ToInt32(id),
                            Name = Convert.ToString(name),
                            DateCreated = Convert.ToDateTime(dateCreated),
                            ArticlesRelated = Convert.ToInt32(articlesRelated)
                        });
                    }
                }
            }

            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                var cmd = new SQLiteCommand(Queries.SP_INSERTCATEGORY, connection);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@DateCreated", datetime);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
