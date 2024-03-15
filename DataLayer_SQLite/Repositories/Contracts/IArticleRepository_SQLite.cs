using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_SQLite.Repositories.Contracts
{
    public interface IArticleRepository_SQLite<T> : IBaseRepository_SQLite<T>
    {
        IEnumerable<T> Search(Dictionary<string, object> filters);
    }
}
