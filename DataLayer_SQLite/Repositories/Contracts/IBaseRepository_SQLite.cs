using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_SQLite.Repositories.Contracts
{
    public interface IBaseRepository_SQLite<T>
    {
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
