using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;


public static class BookEnpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.Map("books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
}
