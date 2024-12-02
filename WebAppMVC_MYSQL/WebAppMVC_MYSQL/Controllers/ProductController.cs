using WebAppMVC_MYSQL.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC_MYSQL.DBAccess;

namespace WebAppMVC_MYSQL.Controllers
{
    public class ProductController : Controller
    {
        private readonly WarehouseDBContext _DbContext; // private readonly _DbContext of type CategoryDBContext

        // Constructor to get a copy of the DBContext object
        public ProductController(WarehouseDBContext CopyofdbContext) // DI
        {
            _DbContext = CopyofdbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _DbContext.Products; // retrieves all category records
            return View(ProductList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Products.Add(newProduct);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newProduct);
        }

        // Get Action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var productfound = _DbContext.Products.Find(id);
            if (productfound == null)
                return NotFound();

            return View(productfound);
        }

        // Post Action for Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Product newproduct)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Products.Update(newproduct);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newproduct);
        }

        // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var productfound = _DbContext.Products.Find(Id);
            if (productfound == null)
                return NotFound();

            return View(productfound);
        }

        // Post Action for Remove
        [HttpPost]
        public IActionResult Delete(Product newproduct)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Products.Remove(newproduct);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newproduct);
        }
    }
}
