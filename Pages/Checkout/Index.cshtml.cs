using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopEasy.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly CartService _cartService;

        public IndexModel (CartService cartService)
        {
            _cartService = cartService; 
        }

        [BindProperty]
        public Order Order { get; set; }

        public void OnGet()
        {
            var cartItems = _cartService.GetCartItems();
            Order = new Order
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(i => i.Price * i.Quantity)
            };
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid)
            {
                var cartItems = _cartService.GetCartItems();
                Order.CartItems = cartItems;    
                Order.TotalPrice = cartItems.Sum(i => i.Price * i.Quantity);                
            }
            _cartService.SaveCartItem(new List<CartItem>());
            return RedirectToPage("/OrderConfirm/Index", new { orderId = 1 });
        }
    }
}
