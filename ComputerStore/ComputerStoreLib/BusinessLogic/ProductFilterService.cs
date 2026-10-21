using ComputerStoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    public class ProductFilterService
    {
        private ProductRepository productRepo;

        public ProductFilterService(ProductRepository repo)
        {
            productRepo = repo;
        }

        public List<ProductItem> FilterByNameAndCategory(string name, string category)
        {
            var products = productRepo.GetAllProducts();
            if (products == null) return new List<ProductItem>();

            var filtered = products.AsEnumerable();

            if (!string.IsNullOrEmpty(name))
                filtered = filtered.Where(p => p.Name.IndexOf(name, System.StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrEmpty(category) && category != "Все категории")
                filtered = filtered.Where(p => p.Category == category);

            return filtered.ToList();
        }
    }
}