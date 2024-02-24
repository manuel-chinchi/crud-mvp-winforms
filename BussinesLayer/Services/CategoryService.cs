using BussinesLayer.Services.Contracts;
using DataLayer.Repositories;
using DataLayer.Repositories.Contracts;
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
        private readonly ICategoryRepository<Category> _categoryRepository = new CategoryRepository();

        public void CreateCategory(string name)
        {
            _categoryRepository.Insert(new Category { Name = name });
        }

        public void DeleteCategory(string id)
        {
            id = string.IsNullOrEmpty(id) == true ? "0" : id;
            _categoryRepository.Delete(Convert.ToInt32(id));
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}
