using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiverBooks.Books.Data;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstant.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Author)
           .HasMaxLength(DataSchemaConstant.DEFAULT_NAME_LENGTH)
           .IsRequired();

        builder.HasData(GetSimpleBook());
    }

    private IEnumerable<Book> GetSimpleBook()
    {
        var tolkien = "J.R.R. Tokient";
        yield return new Book(Guid.NewGuid(), "The followship of the Ring", tolkien, 10.99m);
        yield return new Book(Guid.NewGuid(), "The followship of the Ring II", tolkien, 12.99m);
        yield return new Book(Guid.NewGuid(), "The followship of the Ring III", tolkien, 20.99m);
        yield return new Book(Guid.NewGuid(), "The followship of the Ring IV", tolkien, 30.99m);
    }
}
