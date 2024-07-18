using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopEasy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopEasy.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ShopEasyContext _shopEasyContext;

        public IndexModel (ShopEasyContext shopEasyContext)
        {
            _shopEasyContext = shopEasyContext; 
        }

        public IList<Product> Products { get; set; }
        public string searchString { get; set; }
        public int pageIndex { get; set; }
        public int totalPages { get; set; }

        public async Task OnGetAsync(string inputString = null, int indexPage = 1) {
            const int pageSize = 8;
            pageIndex = indexPage;
            searchString = inputString;

            var products = _shopEasyContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(inputString)) { 
                products = products.Where(p => p.Name.Contains(inputString) || p.Category.Contains(inputString));
            }

            //Products = await products.ToListAsync();

            //count page            
            var count = await products.CountAsync();
            totalPages = (int)Math.Ceiling(count / (double)pageSize);

            Products = await products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
