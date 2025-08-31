using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface IArticleRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Search(Dictionary<string, object> filters);
    }
}
