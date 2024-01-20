using DataLayer.Repositories;
using DataLayer.Repositories.Contracts;
using EntityLayer;
using EntityLayer.Models;
using EntityLayer.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public class ArticleService : IArticleService<SortableBindingList<Article>>
    {
        private IArticleRepository<IEnumerable<Article>> _repository = new ArticleRepository();

        public SortableBindingList<Article> GetArticles()
        {
            var res = _repository.GetArticles().ToList();
            var sortRes = new SortableBindingList<Article>(res);
            return sortRes;
        }

        public void DeleteArticle(string id)
        {
            _repository.DeleteArticle(id);
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            _repository.InsertArticle(name, description, brand, stock);
        }

        public SortableBindingList<Article> SearchArticle(int includeName, int includeDescription, int includeBrand, string search)
        {
            var res = _repository.SearchArticle(includeName, includeDescription, includeBrand,  search).ToList();
            var sortRes = new SortableBindingList<Article>(res);
            return sortRes;
        }

        public void UpdateArticle(string name, string description, string brand, string stock, string id)
        {
            _repository.EditArticle(name, description, brand, stock, id);
        }
    }
}
