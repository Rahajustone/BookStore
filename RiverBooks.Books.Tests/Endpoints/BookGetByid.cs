using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.Endpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookGetByid(Fixture fixture, ITestOutputHelper outputHelper) :
    TestClass<Fixture>(fixture, outputHelper)
{
    [Theory]
    [InlineData("e03696c8-78a3-49e7-bc48-481ef94f0483", "The followship of the Ring II")]
    [InlineData("5edbfe2c-f3f4-4b4c-9129-61c1b45e89d1", "The followship of the Ring")]
    [InlineData("90514419-d88a-40dc-91ea-67eb32107a29", "The followship of the Ring III")]
    [InlineData("a9eb78d7-f5e2-47a6-860d-d42d28a7214a", "The followship of the Ring IV")]
    public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
    {
        Guid bookId = Guid.Parse(validId);
        var request = new GetBookByIdRequest(bookId);
        var testResult = await
            Fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(request);

        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Id.Should().Be(bookId);
        testResult.Result.Title.Should().Be(expectedTitle);
    }

}
