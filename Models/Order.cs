using System.ComponentModel.DataAnnotations;

public class Order
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    public List<CartItem> CartItems { get; set; }

    public decimal TotalPrice { get; set; }
}