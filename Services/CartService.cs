using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShopEasy.Models;
using System.Collections.Generic;

public class CartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ISession session => _httpContextAccessor.HttpContext.Session;

    public List<CartItem> GetCartItems() {
        var cartJson = session.GetString("Cart");
        if (string.IsNullOrEmpty(cartJson)) return new List<CartItem>();
        return JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
    }

    public void SaveCartItem(List<CartItem> cartItems) { 
        var cartJson = JsonConvert.SerializeObject(cartItems);
        session.SetString("Cart", cartJson);
    }

    public void AddToCart(CartItem item)
    {
        var cartItems = GetCartItems();

        var existingItem = cartItems.Find(i => i.ProductId == item.ProductId);
        if (existingItem != null) { 
            existingItem.Quantity = item.Quantity + 1; 
        }else
        {
            cartItems.Add(item);
        }
        SaveCartItem(cartItems);
    }

    public void removeFromCart (int itemProductId)
    {
        var cartItems = GetCartItems();
        var removeItem = cartItems.Find(i => i.ProductId == itemProductId);
        if (removeItem != null)
        {
            cartItems.Remove(removeItem);
        }
        SaveCartItem(cartItems);
    }

    public void UpdateQuantity(int id, int quantity) {
        var cartItems = GetCartItems();
        var updateQuantityItem = cartItems.Find(i => i.ProductId == id);
        if (updateQuantityItem != null)
        {
            updateQuantityItem.Quantity = quantity;
        }
        SaveCartItem (cartItems);
    }
    
}
