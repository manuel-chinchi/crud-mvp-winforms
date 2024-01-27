﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICategoryRepository<T>
    {
        T GetCategories();
        void CreateCategory(string name);
        void DeleteCategory(string id);
    }
}