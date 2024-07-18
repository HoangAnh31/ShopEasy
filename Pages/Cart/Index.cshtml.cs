using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopEasy.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly CartService? _cartService;
        
        public IndexModel (CartService cartService)
        {
            _cartService = cartService;
        }

        public List<CartItem> CartItems { get; set; }

        public decimal TotalPrice { get; set; }

        public void OnGet ()
        {
            CartItems = _cartService.GetCartItems();
            TotalPrice = CalculateTotalPrice();
        }

        private decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in CartItems)
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }

        public IActionResult OnPostRemove(int productId)
        {
            _cartService.removeFromCart(productId);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateQuantity(int productId, int quantity) { 
            _cartService.UpdateQuantity(productId, quantity);
            return RedirectToPage();
        }

    }
}
