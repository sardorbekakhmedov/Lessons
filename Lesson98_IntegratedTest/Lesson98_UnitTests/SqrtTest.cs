using System.Net.Http.Json;
using Lesson98_IntegratedTest.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace Lesson98_UnitTests;

public class SqrtTest
{
    private readonly HttpClient _httpClient;
    public SqrtTest()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task CustomSqrt()
    {
        // Arrange

        var sqrtModel = new SqrtModel(25);

        var request = new HttpRequestMessage(HttpMethod.Post, "api/Sqrt"); 
        request.Content = JsonContent.Create(sqrtModel);

        /* request.Content = new StringContent(
            content: JsonConvert.SerializeObject(new { Value = 25 }),
            encoding: Encoding.UTF8,
            mediaType: "application/json");*/


        // Act
        var response = await _httpClient.SendAsync(request);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        var result = JsonConvert.DeserializeObject<SqrtResultModel>(await response.Content.ReadAsStringAsync());

        Assert.NotNull(result);
        Assert.Equal(5, result.ResultValue);
    }
}

