using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public interface ICategoryService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetCategories();
        void CreateCategory(TEntity category);
        void DeleteCategory(string id);
    }
}
