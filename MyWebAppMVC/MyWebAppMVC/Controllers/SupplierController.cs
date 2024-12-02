using Microsoft.AspNetCore.Mvc;
using MyWebAppMVC.DBOperations;
using MyWebAppMVC.Models;

namespace MyWebAppMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly WarehouseDBContext _DbContext; // private readonly _DbContext of type CategoryDBContext

        // Constructor to get a copy of the DBContext object
        public SupplierController(WarehouseDBContext CopyofdbContext) // DI
        {
            _DbContext = CopyofdbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Supplier> SupplierList = _DbContext.Suppliers; // retrieves all category records
            return View(SupplierList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier newSupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Suppliers.Add(newSupplier);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newSupplier);
        }

        // Get Action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var supplierfound = _DbContext.Suppliers.Find(id);
            if (supplierfound == null)
                return NotFound();

            return View(supplierfound);
        }

        // Post Action for Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Supplier newsupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Suppliers.Update(newsupplier);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newsupplier);
        }

        // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var supplierfound = _DbContext.Suppliers.Find(Id);
            if (supplierfound == null)
                return NotFound();

            return View(supplierfound);
        }

        // Post Action for Delete
        [HttpPost]
        public IActionResult Delete(Supplier newsupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Suppliers.Remove(newsupplier);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsupplier);
        }
    }
}




 
       

