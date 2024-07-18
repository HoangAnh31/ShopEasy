using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopEasy.Pages.OrderConfirm
{
    public class IndexModel : PageModel
    {
        public int OrderId { get; set; }
        public void OnGet(int orderid)
        {
            OrderId = orderid;
        }
    }
}
