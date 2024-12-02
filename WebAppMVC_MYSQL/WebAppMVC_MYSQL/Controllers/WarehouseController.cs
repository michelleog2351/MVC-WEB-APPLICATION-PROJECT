using WebAppMVC_MYSQL.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC_MYSQL.DBAccess;

namespace WebAppMVC_MYSQL.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly WarehouseDBContext _DbContext; // private readonly _DbContext of type CategoryDBContext

        // Constructor to get a copy of the DBContext object
        public WarehouseController(WarehouseDBContext CopyofdbContext) // DI
        {
            _DbContext = CopyofdbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Warehouse> warehouseList = _DbContext.Warehouses; // retrieves all category records
            return View(warehouseList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Warehouse newWarehouse)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Warehouses.Add(newWarehouse);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newWarehouse);
        }

        // Get Action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var warehousefound = _DbContext.Warehouses.Find(id);
            if (warehousefound == null)
                return NotFound();

            return View(warehousefound);
        }

        // Post Action for Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Warehouse newWarehouse)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Warehouses.Update(newWarehouse);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newWarehouse);
        }

        // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var warehousefound = _DbContext.Warehouses.Find(Id);
            if (warehousefound == null)
                return NotFound();

            return View(warehousefound);
        }

        // Post Action for Delete
        [HttpPost]
        public IActionResult Delete(Warehouse newWarehouse)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Warehouses.Remove(newWarehouse);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newWarehouse);
        }
    }
}
