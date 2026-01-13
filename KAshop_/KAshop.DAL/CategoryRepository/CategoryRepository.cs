using KAshop.DAL.Data;
using KAshop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAshop.DAL.CategoryRepository
{
    
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext context;
        public CategoryRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return 0;
        }

        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            if(withTracking) 
            return context.Categories.ToList();

            return context.Categories.AsNoTracking().ToList();
        }

        public Category? GetById(int id)
        {
            return context.Categories.Find( id);
        }

        public int Remove(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
            return 0;
        }

        public int Update(Category category)
        {
            context.Categories.Update(category);
           context.SaveChanges ();
            return 0;
        }
    }
}
