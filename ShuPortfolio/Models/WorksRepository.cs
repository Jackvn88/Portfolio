using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuPortfolio.Models
{
    public class WorksRepository : IWorksRepository
    {
        private CategoriesDbContext _context;

        public WorksRepository(CategoriesDbContext categories)
        {
            _context = categories;
        }

        public async Task<IList<Work>> GetAllWorks()
        {
            return await _context.Works.ToListAsync();
        }

        public async Task<IList<Work>> GetWorksByCategoryId(int? id)
        {
            return await _context.Works.Where(w => w.CategoryID == id).ToListAsync();
        }

       
    }
}
