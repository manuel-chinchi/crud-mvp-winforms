using Dapper;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository<IEnumerable<Article>>
    {
        public IEnumerable<Article> GetArticles()
        {
            IEnumerable<Article> result = new List<Article>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Article>("GetArticles", CommandType.StoredProcedure);
            }
            return result;
        }

        public void CreateArticle(string name, string description, string stock, string categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "InsertArticle",
                    new
                    {
                        Name = name,
                        Description = description,
                        Stock = stock,
                        CategoryId = categoryId
                    },
                    null,
                    null,
                    CommandType.StoredProcedure
                );
            }
        }

        public void UpdateArticle(string name, string description, string stock, string id, string categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "UpdateArticle",
                    new
                    {
                        Name = name,
                        Description = description,
                        Stock = stock,
                        Id = id,
                        CategoryId = categoryId
                    }, null, null,
                    CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteArticle(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "DeleteArticle",
                    new
                    {
                        Id = id
                    },
                    null, null,
                    CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search)
        {
            var result = new List<Article>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Article>(
                    "SearchArticle",
                    new
                    {
                        IncludeName = includeName,
                        IncludeDesc = includeDescription,
                        Search = search
                    },
                    null,
                    false,
                    null,
                    CommandType.StoredProcedure
                ).ToList();
            }
            return result;
        }

    }
}
