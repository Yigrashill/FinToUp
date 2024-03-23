using Application.Contracts.Exceptions;
using Application.Contracts.Persistance;
using Application.Features.Finance.Command.UpdateCommand;
using Application.Features.Finance.Queries;
using Application.MappingProfiles;
using Domain.Models;
using Shouldly;

namespace Test.Features.Finance.Commands;

public class UpdateFinanceCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IFinanceRepository> _mockRepo;


    public UpdateFinanceCommandHandlerTest()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();
        var mapperConfig = new MapperConfiguration(map => 
        {
            map.AddProfile<FinanceProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }


    [Fact]
    public async Task UpdateFinanceCommandhandler_Should_Change_Title_Amout_Or_FinanceType_Of_Finance()
    {
        // Arrange
        var handler = new UpdateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var newFinanceCommand = new UpdateFinanceCommand()
        {
            Id = 1,
            Title = "NewTitle",
            Amount = 1.00M,
            FinanceType = FinanceType.Liabilities,
        };

        // Act
        await handler.Handle(newFinanceCommand, CancellationToken.None);
        var newFinance = await _mockRepo.Object.GetByIdAsync(1);

        // Assert
        newFinance.Title.ShouldBeSameAs(newFinanceCommand.Title);
        #pragma warning disable CS8629 // Nullable value type may be null.
        newFinance.Amount.Value.ShouldBe(newFinanceCommand.Amount.Value);
        #pragma warning restore CS8629 // Nullable value type may be null.
        newFinance.FinanceType.ShouldBe(newFinance.FinanceType);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task UpdateFinanceCommandhandle_Should_Return_Error_When_Title_Is_Empty_Or_Null(string? title)
    {   
        // Arrange
        var handler = new UpdateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var newFinanceCommand = new UpdateFinanceCommand()
        {
            Id = 1,
            Title = title,
            Amount = 1.00M,
            FinanceType = FinanceType.Liabilities,
        };

        // Act & Assert
        await Should.ThrowAsync<BadRequestException>(async () =>
        {
            await handler.Handle(newFinanceCommand, CancellationToken.None);
        });

    }
}
