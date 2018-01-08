using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuPortfolio.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Categories { get; }

        void SaveCategory(Category category);

        Category DeleteCategory(int id);
    }
}
