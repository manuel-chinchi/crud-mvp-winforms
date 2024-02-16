using DataLayer.Repositories;
using DataLayer.Repositories.SQLite;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ArticleService : IArticleService<IEnumerable<Article>>
    {
        private readonly IArticleRepository<IEnumerable<Article>> _articleRepository = new ArticleRepositorySQLite();

        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetArticles().ToList();
        }

        public void CreateArticle(string name, string description, string stock, string categoryId)
        {
            _articleRepository.CreateArticle(name, description, stock, categoryId);
        }

        public void UpdateArticle(string name, string description, string stock, string id, string categoryId)
        {
            _articleRepository.UpdateArticle(name, description, stock, id, categoryId);
        }

        public void DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search)
        {
            return _articleRepository.SearchArticle(includeName, includeDescription, search).ToList();
        }
    }
}
