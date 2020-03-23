using Movies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.SqLite
{
    public class CategoryRepositorySqLite : ICategoryRepository
    {
        SqLiteDbContext _db;

        public CategoryRepositorySqLite(SqLiteDbContext db)
        {
            _db = db;
        }

        public Category Create(Category entity)
        {
             _db.Categories.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public Category Get(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Category> GetAll()
        {
            return _db.Categories.AsQueryable();
        }

        public Category Remove(int id)
        {
            var cat = Get(id);
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            return cat;
        }

        public Category Update(Category entity)
        {
            _db.Categories.Update(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
