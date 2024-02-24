using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
