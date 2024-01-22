using DataLayer.Repositories;
using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ArticleService : IArticleService<SortableBindingList<Article>>
    {
        private IArticleRepository<IEnumerable<Article>> _articleRepository = new ArticleRepository();

        public SortableBindingList<Article> GetArticles()
        {
            var result = _articleRepository.GetArticles().ToList();
            var sortable = new SortableBindingList<Article>(result);
            return sortable;
        }

        public void CreateArticle(string name, string description, string brand, string stock)
        {
            _articleRepository.CreateArticle(name, description, brand, stock);
        }

        public void UpdateArticle(string name, string description, string brand, string stock, string id)
        {
            _articleRepository.UpdateArticle(name, description, brand, stock, id);
        }

        public void DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public SortableBindingList<Article> SearchArticle(int includeName, int includeDescription, int includeBrand, string search)
        {
            var result = _articleRepository.SearchArticle(includeName, includeDescription, includeBrand, search).ToList();
            var sortable = new SortableBindingList<Article>(result);
            return sortable;
        }
    }
}
