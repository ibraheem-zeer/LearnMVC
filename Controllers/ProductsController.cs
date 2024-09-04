using LearnMVC.Data;
using LearnMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Controllers
{
    public class ProductsController : Controller
    {
        public AppDbContext context { get; }
        public ProductsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            context.products.Add(model);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangeStatus(int id)
        {
            var product = context.products.Find(id);
            product.InPublish = !product.InPublish;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
