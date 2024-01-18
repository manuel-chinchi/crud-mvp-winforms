using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface IArticleRepository<T>
    {
        T GetArticles();
        void InsertArticle(string name, string description, string brand, string stock);
        void DeleteArticle(string id);
        void EditArticle(string name, string description, string brand, string stock, string id);
        T SearchArticle(int includeName, int includeDescription, int includeBrand, string search);
    }
}
