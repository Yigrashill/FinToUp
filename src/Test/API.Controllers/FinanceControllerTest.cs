﻿using Application.Features.Finance.Command.UpdateCommand;
using Application.Features.Finance.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Json;

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
    public async Task FinanceController_Should_Return_Single_Finance()
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
    public async Task FinanceController_Should_Return_List_Of_Finances()
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
    public async Task Put_Should_Update_Finance_And_Return_NoContent()
    {
        // Arrange
        var client = _factory.CreateClient();
        var updateCommand = new UpdateFinanceCommand
        {
            Id = 1, 
            Title = "Zaktualizowany Tytuł",
            Amount = 500.00M,
            FinanceType = FinanceType.Assets 
        };

        // Act
        var response = await client.PutAsJsonAsync("/api/finances/", updateCommand);
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NoContent);
    }
}