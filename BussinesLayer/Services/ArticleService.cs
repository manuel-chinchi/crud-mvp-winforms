using BussinesLayer.Services.Contracts;
using DataLayer.Repositories;
using DataLayer.Repositories.Contracts;
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
        private readonly IArticleRepository<Article> _articleRepository = new ArticleRepository();

        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetAll();
        }

        public void CreateArticle(string name, string description, string stock, string categoryId)
        {
            stock = string.IsNullOrEmpty(stock) ? "0" : stock;
            _articleRepository.Insert(
                new Article()
                {
                    Name = name,
                    Description = description,
                    Stock = Convert.ToInt32(stock),
                    CategoryId = categoryId
                });
        }

        public void UpdateArticle(string name, string description, string stock, string id, string categoryId)
        {
            _articleRepository.Update(
                new Article
                {
                    Id = Convert.ToInt32(id),
                    Name = name,
                    Description = description,
                    Stock = Convert.ToInt32(stock),
                    CategoryId = categoryId
                });
        }

        public void DeleteArticle(string id)
        {
            id = string.IsNullOrEmpty(id) == true ? "0" : id;
            _articleRepository.Delete(Convert.ToInt32(id));
        }

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search)
        {
            var filters = new Dictionary<string, object>()
            {
                { "includeName", includeName},
                { "includeDescription", includeDescription },
                { "search", search }
            };
            return _articleRepository.Search(filters);
        }
    }
}
