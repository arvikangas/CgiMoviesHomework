using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        T Remove(int id);
    }
}
