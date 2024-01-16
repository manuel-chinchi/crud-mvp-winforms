using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository = new ArticleRepository();

        public DataTable GetArticles()
        {
            DataTable dt = new DataTable();
            dt = _articleRepository.GetArticles();
            return dt;
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            _articleRepository.InsertArticle(name, description, brand, stock);
        }

        public void DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public void UpdateArticle(string name, string description, string brand, string stock, string id)
        {
            _articleRepository.EditArticle(name, description, brand, stock, id);
        }

        public DataTable SearchArticle(int includeName, int includeDescription, int includeBrand, string search)
        {
            return _articleRepository.SearchArticle(includeName, includeDescription, includeBrand, search);
        }
    }
}
