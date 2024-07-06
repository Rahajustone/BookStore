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
        yield return new Book(Guid.Parse("5edbfe2c-f3f4-4b4c-9129-61c1b45e89d1"), "The followship of the Ring", tolkien, 10.99m);
        yield return new Book(Guid.Parse("e03696c8-78a3-49e7-bc48-481ef94f0483"), "The followship of the Ring II", tolkien, 12.99m);
        yield return new Book(Guid.Parse("90514419-d88a-40dc-91ea-67eb32107a29"), "The followship of the Ring III", tolkien, 20.99m);
        yield return new Book(Guid.Parse("a9eb78d7-f5e2-47a6-860d-d42d28a7214a"), "The followship of the Ring IV", tolkien, 30.99m);
    }
}
