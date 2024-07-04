using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class GetBookById(IBookService bookService) : Endpoint<GetBookByIdRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/books/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
    {
        var book = await _bookService.GetBookByIdAsync(req.Id);

        if (book == null)
        {
            await SendNotFoundAsync();
            return;
        }

        await SendAsync(book);
    }
}
