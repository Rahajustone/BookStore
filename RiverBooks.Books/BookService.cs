namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return
        [
            new BookDto(Guid.NewGuid(), "Cracking the Codding Interview", "Gayle Laakmann mcdowel"),
            new BookDto(Guid.NewGuid(), "Cracking the Codding Interview", "Gayle Laakmann mcdowel"),
            new BookDto(Guid.NewGuid(), "Cracking the Codding Interview", "Gayle Laakmann mcdowel")
        ];
    }
}
