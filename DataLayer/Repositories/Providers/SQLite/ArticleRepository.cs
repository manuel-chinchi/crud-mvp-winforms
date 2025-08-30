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
    public class ArticleRepository : BaseRepository, IArticleRepository<Article>
    {
        #region metodos base
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_DELETEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public IEnumerable<Article> GetAll()
        {
            List<Article> articles = new List<Article>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_GETARTICLES, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var name = reader["name"];
                        var description = reader["description"];
                        var stock = reader["stock"];
                        var categoryId = reader["categoryId"];
                        var dateCreated = reader["dateCreated"];
                        var dateUpdated = reader["dateUpdated"];
                        if (dateUpdated == DBNull.Value)
                        {
                            dateUpdated = null;
                        }
                        var categoryName = reader["categoryName"];

                        articles.Add(new Article
                        {
                            Id = Convert.ToInt32(id),
                            Name = Convert.ToString(name),
                            Description = Convert.ToString(description),
                            Stock = Convert.ToInt32(stock),
                            CategoryId = Convert.ToString(categoryId),
                            DateCreated = Convert.ToDateTime(dateCreated),
                            DateUpdated = Convert.ToDateTime(dateUpdated),
                            CategoryName = Convert.ToString(categoryName)
                        });
                    }
                }

            }
            return articles;
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Article entity)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_INSERTARTICLE, connection);

                var dateCreated = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                string dateUpdated = null;
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public IEnumerable<Article> Search(Dictionary<string, object> filters)
        {
            int includeName = (int)filters["includeName"];
            int includeDescription = (int)filters["includeDescription"];
            string search = (string)filters["search"];

            List<Article> articles = new List<Article>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_SEARCHARTICLE, connection);

                cmd.Parameters.AddWithValue("@IncludeName", includeName);
                cmd.Parameters.AddWithValue("@IncludeDesc", includeDescription);
                cmd.Parameters.AddWithValue("@Search", search);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        ;
                    }
                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var name = reader["name"];
                        var description = reader["description"];
                        var stock = reader["stock"];
                        var categoryId = reader["categoryId"];
                        var dateCreated = reader["dateCreated"];
                        var dateUpdated = reader["dateUpdated"];
                        if (dateUpdated == DBNull.Value)
                        {
                            dateUpdated = null;
                        }
                        var categoryName = reader["categoryName"];

                        articles.Add(new Article
                        {
                            Id = Convert.ToInt32(id),
                            Name = Convert.ToString(name),
                            Description = Convert.ToString(description),
                            Stock = Convert.ToInt32(stock),
                            CategoryId = Convert.ToString(categoryId),
                            DateCreated = Convert.ToDateTime(dateCreated),
                            DateUpdated = Convert.ToDateTime(dateUpdated),
                            CategoryName = Convert.ToString(categoryName)
                        });
                    }
                }
            }
            return articles;
        }

        public void Update(Article entity)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(Queries.SP_UPDATEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@Id", entity.Id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }
        #endregion
    }
}
