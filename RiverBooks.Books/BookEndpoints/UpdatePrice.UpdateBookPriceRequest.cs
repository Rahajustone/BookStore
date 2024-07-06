using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.Endpoints;

public record UpdateBookPriceRequest(Guid Id, decimal newPrice);

public class UpdateBookPriceRequestValidation : Validator<UpdateBookPriceRequest>
{
    public UpdateBookPriceRequestValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("A book id is required.");

        RuleFor(x => x.newPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Book prices may not be negative.");
    }
}
