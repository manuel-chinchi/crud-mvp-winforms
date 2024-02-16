using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.SQLite
{
    public class ArticleRepositorySQLite : BaseRepositorySQLite, IArticleRepository<IEnumerable<Article>>
    {
        public void CreateArticle(string name, string description, string stock, string categoryId)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_INSERTARTICLE, connection);

                var dateCreated = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                string dateUpdated = null;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void DeleteArticle(string id)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_DELETEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public IEnumerable<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_GETARTICLES, connection);
                
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

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search)
        {
            List<Article> articles = new List<Article>();
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_SEARCHARTICLE, connection);

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

        public void UpdateArticle(string name, string description, string stock, string id, string categoryId)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoreProceduresSQLite.SP_UPDATEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }
    }
}
