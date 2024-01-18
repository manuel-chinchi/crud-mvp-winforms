using DataLayer.Repositories;
using DataLayer.Repositories.Contracts;
using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ArticleService2 : IArticleService<SortableBindingList<Article>>
    {
        private IArticleRepository<IEnumerable<Article>> _articleRepository = new ArticleRepository2();

        public SortableBindingList<Article> GetArticles()
        {
            var res = _articleRepository.GetArticles().ToList();
            var sortRes = new SortableBindingList<Article>(res);
            return sortRes;
        }

        public void DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            _articleRepository.InsertArticle(name, description, brand, stock);
        }

        public SortableBindingList<Article> SearchArticle(int includeName, int includeDescription, int includeBrand, string search)
        {
            var res = _articleRepository.SearchArticle(includeName, includeDescription, includeBrand,  search).ToList();
            var sortRes = new SortableBindingList<Article>(res);
            return sortRes;
        }

        public void UpdateArticle(string name, string description, string brand, string stock, string id)
        {
            _articleRepository.EditArticle(name, description, brand, stock, id);
        }
    }
}
