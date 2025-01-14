using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyWebAppMVC.DBOperations;
using MyWebAppMVC.Models;
using MyWebAppMVC.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace MyWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly WarehouseDBContext _DbContext;

        public HomeController(WarehouseDBContext CopyofdbContext)
        {
            _DbContext = CopyofdbContext;
        }

        public async Task <IActionResult> Index(string searchString, int? warehouseID, int? supplierID, string sortOrder)
        {
            var productsQuery = _DbContext.Products
                .Include(p => p.Warehouse)
                .Include(p => p.Suppliers)
                .AsQueryable();

            var warehouses = await _DbContext.Warehouses
                .Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Name
                })
                .ToListAsync();

            var suppliers = await _DbContext.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();

                if (!String.IsNullOrEmpty(searchString))
                {
                    var lowercaseSearchString = searchString.ToLower();
                    productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(lowercaseSearchString));
                }
                

                if (warehouseID.HasValue)
                {
                    productsQuery = productsQuery.Where(p => p.WarehouseId == warehouseID.Value);

                    if (!productsQuery.Any() && !string.IsNullOrEmpty(searchString))
                    {
                        ViewBag.SearchMsg = $"No products found for '{searchString}' in the selected warehouse.";
                    }
                    else if (!productsQuery.Any())
                    {
                        ViewBag.SearchMsg = "No products found in the selected warehouse.";
                    }
                }

                if (supplierID.HasValue)
                {
                    productsQuery = productsQuery.Where(p => p.Suppliers.Any(s => s.Id == supplierID.Value));

                    if (!productsQuery.Any() && !string.IsNullOrEmpty(searchString))
                    {
                        ViewBag.SearchMsg = $"No products found for '{searchString}' in the selected supplier.";
                    }
                    else if (!productsQuery.Any())
                    {
                        ViewBag.SearchMsg = "No products found in the selected supplier.";
                    }
                }

                var filteredProductsCount = await productsQuery.CountAsync();
                if (!string.IsNullOrEmpty(searchString))
                {
                    if (filteredProductsCount == 0)
                    {
                        ViewBag.SearchMsg = $"No results found for '{searchString}'.";
                    }
                    else
                    {
                        ViewBag.SearchMsg = $"Showing {filteredProductsCount} result(s) for '{searchString}'.";
                    }
                }

                if (string.IsNullOrEmpty(sortOrder))
                {
                    sortOrder = "name_asc"; // Default to alphabetical sorting (A-Z)
                }

                // Sorting functionality - sort from A-Z or Z-A
                if (sortOrder == "name_asc")
                {
                    productsQuery = productsQuery.OrderBy(p => p.Name);
                }
                else if (sortOrder == "name_desc")
                {
                    productsQuery = productsQuery.OrderByDescending(p => p.Name);
                }

            ViewBag.CurrentSortOrder = sortOrder ?? "name_asc"; // Default sort order if sortOrder is null

                // Create the ViewModel
                var viewModel = new ProductIndexViewModel
                {
                    SearchString = searchString,
                    SelectedWarehouse = warehouseID,
                    SelectedSupplier = supplierID,
                    SortOrder = sortOrder,
                    WarehouseList = warehouses,
                    SupplierList = suppliers,
                    Products = await productsQuery.ToListAsync()
                };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int ID)
        {
            var productItem = await _DbContext.Products
                .Include(p => p.Suppliers)
                .Include(p => p.Warehouse)
                .FirstOrDefaultAsync((p => p.Id == ID));

            if (productItem == null)
            {
                return NotFound();
            }

            return View(productItem);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
