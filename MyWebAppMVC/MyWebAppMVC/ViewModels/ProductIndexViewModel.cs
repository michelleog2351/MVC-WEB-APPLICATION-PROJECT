using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebAppMVC.Models;

namespace MyWebAppMVC.ViewModels
{
    public class ProductIndexViewModel
    {
        public string SearchString { get; set; }
        public int? SelectedWarehouse { get; set; }
        public int? SelectedSupplier { get; set; }
        public IEnumerable<SelectListItem> WarehouseList { get; set; }
        public IEnumerable<SelectListItem> SupplierList { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string SortOrder { get; set; } = string.Empty;
    }
}
