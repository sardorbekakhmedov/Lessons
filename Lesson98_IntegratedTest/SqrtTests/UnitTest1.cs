using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Lesson98_IntegratedTest.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SqrtTests;


public class UnitTest1
{
    private readonly HttpClient _httpClient;
    public UnitTest1()
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

        var result = await response.Content.ReadFromJsonAsync<SqrtResultModel>();

        Assert.NotNull(result);
        Assert.Equal(5, result.Value);
    }
}

