using DataLayer.Repositories;
using DataLayer_SQLite.Repositories.Contracts;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_SQLite.Repositories
{
    public class CategoryRepository_SQLite : BaseRepository_SQLite, ICategoryRepository_SQLite<Category>
    {
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

                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_INSERTCATEGORY, connection);

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

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_DELTECATEGORY, connection);

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
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_GETCATEGORIES, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var name = reader["name"];
                        var dateCreated = reader["dateCreated"];
                        var articlesRelated = reader["articlesRelated"];

                        categories.Add(new Category
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
    }
}
