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
    public class ArticleRepository_SQLite : BaseRepository_SQLite, IArticleRepository_SQLite<Article>
    {
        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        public void Insert(Article entity)
        {
            using (var connection=new SQLiteConnection(_connectionString))
            {

                connection.Open();
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_INSERTARTICLE);

                var dateCreated = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@DateCreated", entity.DateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", null);

                cmd.ExecuteReader();
                connection.Close();
            }
        }
        
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_DELETEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteReader();
                connection.Close();
            }
        }
        
        public void Update(Article entity)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_UPDATEARTICLE, connection);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@Id", entity.Id);

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
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_GETARTICLES, connection);

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

        public IEnumerable<Article> Search(Dictionary<string, object> filters)
        {
            List<Article> articles = new List<Article>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand(StoredProcedures_SQLite.SP_SEARCHARTICLE, connection);

                cmd.Parameters.AddWithValue("@IncludeName", filters["includeName"]);
                cmd.Parameters.AddWithValue("@IncludeDesc", filters["includeDescription"]);
                cmd.Parameters.AddWithValue("@Search", filters["search"]);

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

    }
}
