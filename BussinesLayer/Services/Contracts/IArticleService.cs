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
        void CreateArticle(TEntity article);
        void UpdateArticle(TEntity article);
        void DeleteArticle(string id);
        IEnumerable<TEntity> SearchArticle(int includeName, int includeDescription, string search);
    }
}
