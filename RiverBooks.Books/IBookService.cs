namespace RiverBooks.Books;

internal interface IBookService {
    Task<List<BookDto>> ListBooksAsync();
    Task<BookDto> GetBookByIdAsync(Guid id);
    Task CreateBookAysnc(BookDto book);
    Task DeleteBookAysncAsync(Guid id);
    Task UpdateBookPrice(Guid bookId, decimal newPrice);
}
