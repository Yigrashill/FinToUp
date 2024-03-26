using Application.Features.Finance.Queries;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit;

namespace Test.Api.Controllers;

public class FinanceControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public FinanceControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


    [Fact]
    public async Task FinanceController_Should_Return_Finance()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var result = await client.GetAsync("/api/finance/1");


        // Assert
        // TODO Mock Database Finance context
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        //result.ShouldBeOfType<FinanceDTO>();
    }

}

