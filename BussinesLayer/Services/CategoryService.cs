using DataLayer.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class CategoryService : ICategoryService<IEnumerable<Category>>
    {
        private readonly ICategoryRepository<IEnumerable<Category>> _categoryRepository = new CategoryRepository();

        public void CreateCategory(string name)
        {
            _categoryRepository.CreateCategory(name);
        }

        public void DeleteCategory(string id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
