using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.SQLite
{
    public class CategoryRepositorySQLite : BaseRepositorySQLite, ICategoryRepository<IEnumerable<Category>>
    {
        public void CreateCategory(string name)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_INSERTCATEGORY, connection);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@DateCreated", datetime);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void DeleteCategory(string id)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_DELTECATEGORY, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_GETCATEGORIES, connection);

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
    }
}
