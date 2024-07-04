using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

internal class ListBooksEnpoints(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    // REPR
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct=default)
    {
        var books = _bookService.ListBooks();
        await SendAsync(new ListBooksResponse
        {
            Books = books,
        });
    }
}
