using Microsoft.AspNetCore.Mvc;
using MyWebAppMVC.DBOperations;
using MyWebAppMVC.Models;

namespace MyWebAppMVC.Controllers
{
    public class ArtSupplierController : Controller
    {
        private readonly ArtSupplierDBContext _DbContext; // private readonly _DbContext of type CategoryDBContext

        // Constructor to get a copy of the DBContext object
        public ArtSupplierController(ArtSupplierDBContext CopyofdbContext) // DI
        {
            _DbContext = CopyofdbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<ArtSupplier> artSupplierList = _DbContext.ArtSuppliers; // retrieves all category records
            return View(artSupplierList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtSupplier newArtSupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.ArtSuppliers.Add(newArtSupplier);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newArtSupplier);
        }

        // Get Action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var supplierfound = _DbContext.ArtSuppliers.Find(id);
            if (supplierfound == null)
                return NotFound();

            return View(supplierfound);
        }

        // Post Action for Edit
        [HttpPost]
        public async Task<IActionResult> Edit(ArtSupplier newartsupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.ArtSuppliers.Update(newartsupplier);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newartsupplier);
        }

        // Get Action for Remove
        [HttpGet]
        public IActionResult Remove(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var supplierfound = _DbContext.ArtSuppliers.Find(Id);
            if (supplierfound == null)
                return NotFound();

            return View(supplierfound);
        }

        // Post Action for Remove
        // Removing an item from cart
        [HttpPost]
        public IActionResult Remove(ArtSupplier newartSupplier)
        {
            if (ModelState.IsValid)
            {
                _DbContext.ArtSuppliers.Remove(newartSupplier);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newartSupplier);
        }
    }
}




 
       

