using Microsoft.AspNetCore.Mvc;
using MyWebAppMVC.DBOperations;
using MyWebAppMVC.ViewModels;
using MyWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly WarehouseDBContext _DbContext; // private readonly _DbContext of type WarehouseDBContext


        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor to get a copy of the DBContext object
        public ProductController(WarehouseDBContext CopyofdbContext, IWebHostEnvironment webHostEnvironment) // DI
        {
            _DbContext = CopyofdbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _DbContext.Products.ToListAsync(); // display all the products
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var SupplierList = await _DbContext.Suppliers
                .Select(
                n => new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString(),
                })
                .ToListAsync();

            ViewBag.SupplierList = SupplierList;

            var  WarehouseList = await _DbContext.Warehouses
                .Select(
                w => new SelectListItem
                {
                    Text = w.Name,
                    Value = w.Id.ToString(),
                })
                .ToListAsync();
            ViewBag.WarehouseList = WarehouseList;
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Product newProduct, int[] SupplierIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Product");
                    var extension = Path.GetExtension(file.FileName);

                    using (var filestreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestreams);
                    }
                    newProduct.Image = @"\Images\Product\" + filename + extension;
                }

                foreach (var supplierId in SupplierIds)
                {
                    var supplier = _DbContext.Suppliers.Find(supplierId);
                    if (supplier != null)
                    {
                        newProduct.Suppliers.Add(supplier);
                    }
                }

                _DbContext.Products.Add(newProduct);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newProduct);
        } 

        // Get Action for Edit
        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            var product = _DbContext.Products.Include(p => p.Suppliers).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var supplierList = await _DbContext.Suppliers.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString(),
                Selected = product.Suppliers.Select(ps => ps.Id).Contains(s.Id)
            })
            .ToListAsync();

            ViewBag.SupplierList = supplierList;

            var warehouseList = await _DbContext.Warehouses.Select(w => new SelectListItem
            {
                Text = w.Name,
                Value = w.Id.ToString(),
                Selected = product.WarehouseId == w.Id
            })
            .ToListAsync();

            ViewBag.WarehouseList = warehouseList;

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product updatedProduct, IFormFile file, int[] selectedSuppliers)
        {
            if (ModelState.IsValid)
            {
                var product = _DbContext.Products.Include(p => p.Suppliers).FirstOrDefault(p => p.Id == updatedProduct.Id);
                if (product == null)
                {
                    return NotFound();
                }

                // Update product properties
                product.Name = updatedProduct.Name;
                product.Quantity = updatedProduct.Quantity;
                product.Price = updatedProduct.Price;
                product.WarehouseId = updatedProduct.WarehouseId;

                //string wwwRootFolder = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string wwwRootFolder = _webHostEnvironment.WebRootPath;

                    // Generate a new filename to avoid conflicts
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootFolder, @"Images\Product");
                    var extension = Path.GetExtension(file.FileName);

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        var oldImagePath = Path.Combine(wwwRootFolder, product.Image.Trim('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Save new image
                    using (var filestream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    // Set the new image URL
                    product.Image = @"\Images\Product\" + filename + extension;
                }

                // Clear existing suppliers and add new ones
                product.Suppliers.Clear();

                    foreach (var supplierId in selectedSuppliers)
                    {
                        var supplier = _DbContext.Suppliers.Find(supplierId);
                        if (supplier != null)
                        {
                            product.Suppliers.Add(supplier);
                        }
                    }

                // Save changes to the database
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierList = await _DbContext.Suppliers.Select(
            s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString(),
                Selected = updatedProduct.Suppliers.Any(ps => ps.Id == s.Id)
            }).ToListAsync();

            ViewBag.WarehouseList = await _DbContext.Warehouses.Select(w => new SelectListItem
            {
                Text = w.Name,
                Value = w.Id.ToString()
            }).ToListAsync();

            // If ModelState is invalid, return the same view with the updated product
            return View(updatedProduct);
        }


        // Get Action for Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var productfound = await _DbContext.Products.FindAsync(Id);
            if (productfound == null)
                return NotFound();

            return View(productfound);
        }

        // Post Action for Remove
        [HttpPost]
        public async Task <IActionResult> Delete(Product newproduct)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Products.Remove(newproduct);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newproduct);
        }
    }
}
