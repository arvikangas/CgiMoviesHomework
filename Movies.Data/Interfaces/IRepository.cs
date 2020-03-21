using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
    }
}
