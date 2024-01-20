using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public interface IArticleService<T>
    {
        T GetArticles();
        void InsertArticle(string name, string description, string brand, string stock);
        void DeleteArticle(string id);
        void UpdateArticle(string name, string description, string brand, string stock, string id);
        T SearchArticle(int includeName, int includeDescription, int includeBrand, string search);
    }
}
