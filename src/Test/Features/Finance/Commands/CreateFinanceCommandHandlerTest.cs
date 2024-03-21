using Application.Contracts.Persistance;
using Application.MappingProfiles;
using Application.Features.Finance.Command.CreateFinance;
using Application.Features.Finance.Queries;
using Application.Contracts.Exceptions;

namespace Test.Features.Finance.Commands;

public class CreateFinanceCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IFinanceRepository> _mockRepo;

    public CreateFinanceCommandHandlerTest()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<FinanceProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateFinanceCommandHandler_Should_Return_New_Finance()
    {
        // Arrange
        var handler = new CreateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var repoItems = await _mockRepo.Object.GetAsync();
        var actualItemCount = repoItems.Count();
        var newFinance = new CreateFinanceCommand()
        {
            Title = "Test",
            Amount = 1.00M,
            FinanceType = FinanceTypeDTO.Liabilities
        };

        // Act
        var result = await handler.Handle(newFinance, CancellationToken.None);
        var financeItems = await _mockRepo.Object.GetAsync();


        //Assert
        financeItems.Count.ShouldBe(actualItemCount + 1);
        result.ShouldBeOfType<int>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task CreateFinanceCommandHandler_Should_Return_Error_When_Title_Is_Empty_Or_Null(string title)
    {
        // Arrange
        var handler = new CreateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var newFinance = new CreateFinanceCommand()
        {
            Title = title,
            Amount = 1.00M,
            FinanceType = FinanceTypeDTO.Liabilities
        };

        // Act & Assert
        await Should.ThrowAsync<BadRequestException>(async () =>
        {
            await handler.Handle(newFinance, CancellationToken.None);
        });
    }

    [Fact]
    public async Task CreateFinanceCommandHandler_Should_Return_Error_When_Title_Exceeds_70_Characters()
    {
        // Arrange
        var handler = new CreateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var longTitle = new string('A', 71); 
        var newFinance = new CreateFinanceCommand()
        {
            Title = longTitle,
            Amount = 1.00M,
            FinanceType = FinanceTypeDTO.Liabilities
        };

        // Act & Assert
        await Should.ThrowAsync<BadRequestException>(async () =>
        {
            await handler.Handle(newFinance, CancellationToken.None);
        });
    }

}
