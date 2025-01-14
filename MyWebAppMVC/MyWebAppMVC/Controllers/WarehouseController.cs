using MyWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebAppMVC.DBOperations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace MyWebAppMVC.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly WarehouseDBContext _DbContext; // private readonly _DbContext of type WarehouseDBContext

        // Constructor to get a copy of the DBContext object
        public WarehouseController(WarehouseDBContext CopyofdbContext) // DI
        {
            _DbContext = CopyofdbContext;
        }

        public async Task<IActionResult> Index()
        {
            var warehouseList = await _DbContext.Warehouses.ToListAsync(); // retrieves all warehouse records
            return View(warehouseList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse newWarehouse)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Warehouses.Add(newWarehouse);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newWarehouse);
        }

        // Get Action for Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var warehousefound = await _DbContext.Warehouses.FindAsync(id);
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
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var warehousefound = await _DbContext.Warehouses.FindAsync(Id);
            if (warehousefound == null)
                return NotFound();

            return View(warehousefound);
        }

        // Post Action for Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Warehouse newWarehouse)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Warehouses.Remove(newWarehouse);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newWarehouse);
        }
    }
}
