using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopEasy.Models;
using System.Threading.Tasks;

namespace ShopEasy.Pages.Products.Details
{
    public class IndexModel : PageModel
    {
        private readonly ShopEasyContext _shopEasycontext;
        private readonly CartService _cartService;

        public IndexModel (ShopEasyContext shopEasyContext, CartService cartService)
        {
            _shopEasycontext = shopEasyContext;
            _cartService = cartService;
        }

        public Product product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0) { return NotFound(); }

            product = await _shopEasycontext.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null) { return NotFound(); }

            return Page();

        }

        public IActionResult OnPostAddToCart(int id, string name, string imageUrl, decimal price, int quantity) {
            var cartItem = new CartItem
            {
                ProductId = id,
                Name = name,
                ImageURL = imageUrl,
                Price = price,
                Quantity = quantity
            };
            _cartService.AddToCart(cartItem);
            return RedirectToPage("/Cart/index"); // Redirect to the cart page
        }
    }
}
