using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Interfaces;
using ShopWeb.Dtos;

namespace ShopWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories categoriesDb;

        public CategoriesController(ICategories categoriesDb) 
        {
          this.categoriesDb = categoriesDb;
        }
        // GET: CategoriesController

        public ActionResult Index()
        {
            var categories = this.categoriesDb.GetCategories();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var categories = this.categoriesDb.GetCategoriesById(id);
            return View(categories);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesAddDto addDto)
        {
            try
            {
                this.categoriesDb.SaveCategories(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = this.categoriesDb.GetCategoriesById(id);
            return View(categories);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
