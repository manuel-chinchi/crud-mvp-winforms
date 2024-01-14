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
        private ArticleRepository articleRepository = new ArticleRepository();

        public DataTable GetArticles()
        {
            DataTable dt = new DataTable();
            dt = articleRepository.GetArticles();
            return dt;
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            articleRepository.InsertArticle(name, description, brand, stock);
        }
    }
}
