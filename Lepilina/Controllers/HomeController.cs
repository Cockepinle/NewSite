using Lepilina.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lepilina.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tem = HttpContext.Items["Theme"]?.ToString();
            ViewBag.Theme = tem;
            return View();
        }

        [HttpPost]
        public IActionResult ToggleTheme()
        {
            var currentTheme = HttpContext.Items["Theme"].ToString();
            var newTem = currentTheme == "dark" ? "light" : "dark";
            Response.Cookies.Append("Theme", newTem);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Catalog()
        {
            var tem = HttpContext.Items["Theme"]?.ToString();
            ViewBag.Theme = tem;

            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            var productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var images = await _context.Images.Where(i => i.products_id == product.products_id).ToListAsync();
                productViewModels.Add(new ProductViewModel
                {
                    Product = product,
                    Images = images
                });
            }

            return View(productViewModels);
        }
        public IActionResult GetImage(int id)
        {
            var image = _context.Images.Find(id);

            if (image != null && !string.IsNullOrEmpty(image.image_data))
            {
                return File(image.image_data, "image/jpeg"); 
            }

            return NotFound();
        }

    }
}
