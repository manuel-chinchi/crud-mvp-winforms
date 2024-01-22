using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface IArticleRepository<T>
    {
        T GetArticles();
        void CreateArticle(string name, string description, string stock);
        void EditArticle(string name, string description, string stock, string id);
        void DeleteArticle(string id);
        T SearchArticle(int includeName, int includeDescription, string search);
    }
}
