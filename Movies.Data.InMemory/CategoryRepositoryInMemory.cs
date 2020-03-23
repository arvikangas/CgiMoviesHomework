using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Interfaces;

namespace Movies.Data.InMemory
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        public Category Create(Category entity)
        {
            var max = InMemoryDb.Categories.Any() ? InMemoryDb.Categories.Max(x => x.Id) : 0;
            entity.Id = max + 1;
            InMemoryDb.Categories.Add(entity);
            return entity;
        }

        public Category Get(int id)
        {
            return InMemoryDb.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Category> GetAll()
        {
            return InMemoryDb.Categories.AsQueryable();
        }


        public Category Remove(int id)
        {
            var category = Get(id);
            if(category != null)
            {
                InMemoryDb.Categories.Remove(category);
            }
            return category;
        }

        public Category Update(Category entity)
        {
            var category = Get(entity.Id);

            category.Name = entity.Name;

            return category;
        }
    }
}
