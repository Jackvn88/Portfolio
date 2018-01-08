using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShuPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace ShuPortfolio.Controllers
{
    public class WorksController : Controller
    {
        private IWorksRepository _repository;

        public WorksController(IWorksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return View(await _repository.GetAllWorks());
            }
            return  View(await _repository.GetWorksByCategoryId(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CategoryViewModel category)
        {
            var works = category.Works.ToList();
            return View(works);
        }
    }
}
