using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface IArticleRepository<T> : IBaseRepository<T>
    {
        IEnumerable<T> Search(Dictionary<string, object> filters);
    }
}
