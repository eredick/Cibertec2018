using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        IEnumerable<T> GetList();
        //T GetById(string id);
        T GetById(int id);
    }
}
