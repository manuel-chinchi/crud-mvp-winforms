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
    public class ArticleService : IArticleService<IEnumerable<Article>>
    {
        private IArticleRepository<IEnumerable<Article>> _articleRepository = new ArticleRepository();

        public IEnumerable<Article> GetArticles()
        {
            //var result = _articleRepository.GetArticles().ToList();
            //var sortable = new SortableBindingList<Article>(result);
            //return sortable;
            return _articleRepository.GetArticles().ToList();
        }

        public void CreateArticle(string name, string description, string stock)
        {
            _articleRepository.CreateArticle(name, description, stock);
        }

        public void UpdateArticle(string name, string description, string stock, string id)
        {
            _articleRepository.UpdateArticle(name, description, stock, id);
        }

        public void DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search)
        {
            //var result = _articleRepository.SearchArticle(includeName, includeDescription, search).ToList();
            //var sortable = new SortableBindingList<Article>(result);
            //return sortable;
            return _articleRepository.SearchArticle(includeName, includeDescription, search).ToList();
        }
    }
}
