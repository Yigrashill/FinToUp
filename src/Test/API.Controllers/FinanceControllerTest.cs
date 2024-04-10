using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Application.Features.Finance.Queries;
using Application.Features.Finance.Command.CreateFinance;
using Application.Features.Finance.Command.UpdateCommand;

namespace Test.Api.Controllers;

public class FinanceControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public FinanceControllerTest()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<FinanceDataBaseContext>));
                services.AddDbContext<FinanceDataBaseContext>(options =>
                {
                    options.UseInMemoryDatabase("Test");
                });
            });
        });

        using (var scope = _factory.Services.CreateScope())
        {
            var scopService = scope.ServiceProvider;
            var dbContext = scopService.GetRequiredService<FinanceDataBaseContext>();

            dbContext.Database.EnsureCreated();

            // ADD new Object if You need
            // Object is Created in FinanceDataBaseContext
            dbContext.Finances.Add(new Domain.Models.Finance()
            {
                Title = "Biedronka",
                Amount = 200.00M,
                FinanceType = Domain.Models.FinanceType.Liabilities,
                Createrd = DateTime.UtcNow,
            });

            dbContext.SaveChanges();
        }
    }


    [Fact]
    public async Task Get_By_Id_Request_In_FinanceController_Should_Return_Single_Finance()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/finances/1");
        var result = await response.Content.ReadFromJsonAsync<FinanceDTO>();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        result.ShouldBeOfType<FinanceDTO>();
    }

    [Fact]
    public async Task Get_Request_In_FinanceController_Should_Return_List_Of_Finances()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/finances/");
        var textResult = await response.Content.ReadAsStringAsync();
        var result = await response.Content.ReadFromJsonAsync<List<FinanceDTO>>();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        result.ShouldBeOfType<List<FinanceDTO>>();
    }

    [Fact]
    public async Task Get_By_Id_Request_In_FinanceControllerr_Should_Return_NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/api/finances/{0}");
        var result = await response.Content.ReadAsStringAsync();


        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        result.ShouldNotBeNullOrEmpty();
    }


    [Fact]
    public async Task Post_Request_In_FinanceController_Shoululd_Created_New_Finance_And_Return_Created()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new CreateFinanceCommand
        {
            Title = "Nowy Tytuł",
            Amount = 510.00M,
            FinanceType = FinanceTypeDTO.Assets
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/finances/", command);


        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Created);
    }

    [Fact]
    public async Task Post_Request_In_FinanceController_Shoululd_Shoululd_ReturnBedRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new CreateFinanceCommand
        {
            Title = "",
            Amount = 510.00M,
            FinanceType = FinanceTypeDTO.Assets
        };

        // Act
        var response = await client.PostAsJsonAsync("api/finances/", command);
        var result = await response.Content.ReadAsStringAsync();


        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
        result.ShouldNotBeNullOrEmpty();
    }


    [Fact]
    public async Task Put_Request_In_FinanceController_Should_Update_Finance_And_Return_NoContent()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new UpdateFinanceCommand
        {
            Id = 1,
            Title = "Zaktualizowany Tytuł",
            Amount = 500.00M,
            FinanceType = FinanceTypeDTO.Assets
        };

        // Act
        var response = await client.PutAsJsonAsync("/api/finances/", command);
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Put_Request_In_FinanceController_Shoululd__Shoululd_ReturnBedRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new UpdateFinanceCommand
        {
            Id = 1,
            Title = "",
            Amount = 500.00M,
            FinanceType = FinanceTypeDTO.Assets
        };

        // Act
        var response = await client.PutAsJsonAsync("/api/finances/", command);
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
        result.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Put_Request_In_FinanceController_Should_Return_NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new UpdateFinanceCommand
        {
            Id = 0,
            Title = "New Title",
            Amount = 500.00M,
            FinanceType = FinanceTypeDTO.Assets
        };

        // Act
        var response = await client.PutAsJsonAsync("/api/finances/", command);
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        result.ShouldNotBeNullOrEmpty();
    }


    [Fact]
    public async Task Deleate_Request_In_FinanceController_Shoululd_Deleted_Finance_And_Return_NoContent()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("/api/finances/2");


        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Deleate_Request_In_FinanceController_Shoululd_NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();
   
        // Act
        var response = await client.DeleteAsync($"/api/finances/{0}");
        var result = await response.Content.ReadAsStringAsync();


        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        result.ShouldNotBeNullOrEmpty();
    }

}