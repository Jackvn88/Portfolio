using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuPortfolio.Models
{
    public interface IWorksRepository
    {
        Task<IList<Work>> GetAllWorks();
        Task<IList<Work>> GetWorksByCategoryId(int? id);
    }
}
