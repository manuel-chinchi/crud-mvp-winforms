using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public interface IArticleService<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetArticles();
        void CreateArticle(string name, string description, string stock, string categoryId);
        void UpdateArticle(string name, string description, string stock, string id, string categoryId);
        void DeleteArticle(string id);
        IEnumerable<TEntity> SearchArticle(int includeName, int includeDescription, string search);
    }
}
