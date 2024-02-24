using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public interface ICategoryService<T>
    {
        T GetCategories();
        void CreateCategory(string name);
        void DeleteCategory(string id);
    }
}
