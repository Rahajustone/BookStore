
namespace RiverBooks.Books;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBookAysnc(BookDto newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAysncAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is not null) {
            await _bookRepository.DeleteAsync(book);
            await _bookRepository.SaveChangesAsync();
        }

    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        // handle not found case

        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        var books = (await _bookRepository.ListAsync())
            .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
            .ToList();
        
        return books;
    }

    public async Task UpdateBookPrice(Guid bookId, decimal newPrice)
    {
        // validate the price

        var book = await _bookRepository.GetByIdAsync(bookId);

        // handle not found case

        book!.UpdatePrice(newPrice);
        await _bookRepository.SaveChangesAsync();
    }
}
