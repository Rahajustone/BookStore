using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using RiverBooks.Books.Endpoints;

namespace RiverBooks.Books;

internal class List(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
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
        var books = await _bookService.ListBooksAsync();
        await SendAsync(new ListBooksResponse
        {
            Books = books,
        });
    }
}
