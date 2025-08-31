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
    public class ArticleService : IArticleService<Article>
    {
        private readonly IArticleRepository<Article> _articleRepository;

        public ArticleService()
        {
            _articleRepository = RepositoryFactory.CreateArticleRepository();
        }

        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetAll();
        }

        public void CreateArticle(Article article)
        {
            _articleRepository.Insert(article);
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.Update(article);
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
