using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ShuPortfolio.Models
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private CategoriesDbContext _context;

        public CategoriesRepository(CategoriesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;


        public void SaveCategory(Category category)
        {
            if (category.ID == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = _context.Categories.FirstOrDefault(c => c.ID == category.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;
                    dbEntry.Image = category.Image;
                }
            }
            _context.SaveChanges();
        }


        public Category DeleteCategory(int id)
        {
            Category dbEntry = _context.Categories
                .FirstOrDefault(p => p.ID == id);
            if (dbEntry != null)
            {
                _context.Categories.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }



    }
}
