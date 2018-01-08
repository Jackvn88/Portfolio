using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShuPortfolio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ShuPortfolio.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            _repository = repository;
        }
        [AllowAnonymous]
        public IActionResult Index() => View(_repository.Categories);


        public IActionResult Edit(int id)
        {
            var test =  _repository.Categories.FirstOrDefault(p => p.ID == id);
            return View(Mapper.Map<CategoryViewModel>(test));
        } 

        [HttpPost]
        public IActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "wwwroot\\img\\Categories", category.File.FileName
                );

                category.Image = category.File.FileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    category.File.CopyTo(stream);
                }

                var test = Mapper.Map<Category>(category);
                _repository.SaveCategory(test);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public IActionResult Create() => View("Edit", new CategoryViewModel());

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Category deletedProduct = _repository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
