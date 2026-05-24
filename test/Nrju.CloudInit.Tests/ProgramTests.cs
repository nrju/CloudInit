using System.Text;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Nrju.CloudInit;

/// <summary>
/// Integration tests.
/// </summary>
public class ProgramTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public ProgramTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task GetRoot_Returns_HelloWorld()
    {
        var expectedContentType = "text/plain";
        var expectedContent = "Hello World!";
        var expectedContentLength = expectedContent.Length;

        var client = _webApplicationFactory.CreateClient();
        var response = await client.GetAsync("/", TestContext.Current.CancellationToken);

        var contentType = response.Content.Headers.ContentType?.MediaType;
        contentType.Should().Be(expectedContentType);

        var contentLength = response.Content.Headers.ContentLength;
        contentLength.Should().Be(expectedContentLength);

        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        content.Should().Be(expectedContent);
    }
}
