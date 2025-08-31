using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface ICategoryRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
