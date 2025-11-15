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
        #region Contracts '''''''''''''''''''''''''''''''''''''''''''''''''''''

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(this.ConnectionString))
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

            using (var connection = new SQLiteConnection(this.ConnectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_GETCATEGORIES, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var name = reader["name"];
                        var dateCreated = reader["createdAt"];
                        var totalItems = reader["totalItems"];

                        categories.Add(new Category()
                        {
                            Id = Convert.ToInt32(id),
                            Name = Convert.ToString(name),
                            CreatedAt = Convert.ToDateTime(dateCreated),
                            TotalItems = Convert.ToInt32(totalItems)
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
            // TODO cuando se tiene abierta la base de datos se produce un bloqueante q
            //      hasta que se libere la instancia de uso. Revisar.
            using (var connection = new SQLiteConnection(this.ConnectionString))
            {
                connection.Open();
                var datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                var cmd = new SQLiteCommand(Queries.SP_INSERTCATEGORY, connection);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@CreatedAt", datetime);

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
