using System.IO.Pipelines;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;

    private readonly List<CartItem> _cartItems = new();
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

    public void AddItemToCart(CartItem item)
    {
        Guard.Against.Null(item);

        var exisitingBook = _cartItems.SingleOrDefault(c => c.BookId == item.BookId);
        if (exisitingBook != null)
        {
            exisitingBook.UpdateQuantity(exisitingBook.Quantity + item.Quantity);

            // What we do if the other details changes fixed
            exisitingBook.UpdateDescription(item.Description);
            exisitingBook.UpdateUnitPrice(item.UnitPrice);

            return;
        }

        _cartItems.Add(item);
    }
}
