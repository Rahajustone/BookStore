using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class UpdatePrice(IBookService bookService) : Endpoint<UpdateBookPriceRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Post("books/{Id}/priceHistory");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBookPriceRequest request, CancellationToken ct)
    {
        // Hadle if book is not found id db

        await _bookService.UpdateBookPrice(request.Id, request.newPrice);

        var updatedBook = await _bookService.GetBookByIdAsync(request.Id);

        await SendAsync(updatedBook);
    }
}
