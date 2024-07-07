using Ardalis.GuardClauses;

namespace RiverBooks.Users;

public class CartItem
{
    public CartItem(Guid bookId, string description, int quantity, decimal unitPrice)
    {
        bookId = Guard.Against.Default(bookId);
        description = Guard.Against.Default(description);
        quantity = Guard.Against.Default(quantity);
        unitPrice = Guard.Against.Default(unitPrice);
    }

    public CartItem()
    {
        // EF
    }

    public Guid id { get;  set; } = Guid.NewGuid();
    public Guid BookId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    internal void UpdateQuantity(int quantity)
    {
        Quantity = Guard.Against.Negative(quantity);
    }

    internal void UpdateDescription(string description)
    {
        Description = Guard.Against.NullOrEmpty(description);
    }

    internal void UpdateUnitPrice(decimal unitPrice)
    {
        UnitPrice = Guard.Against.Negative(unitPrice);
    }
}
