using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IArticleRepository<T>
    {
        T GetArticles();
        void CreateArticle(string name, string description, string brand, string stock);
        void UpdateArticle(string name, string description, string brand, string stock, string id);
        void DeleteArticle(string id);
        T SearchArticle(int includeName, int includeDescription, int includeBrand, string search);
    }
}
