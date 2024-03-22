using Application.Contracts.Persistance;
using Application.Features.Finance.Command.UpdateCommand;
using Application.Features.Finance.Queries;
using Application.MappingProfiles;

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
    public async Task UpdateFinanceCommandhandler_Should_Change_Title_Of_Finance()
    {
        // Arrange
        var handler = new UpdateFinanceCommandHandler(_mapper, _mockRepo.Object);
        var newFinanceCommand = new UpdateFinanceCommand()
        {
            Id = 1,
            Title = "NewTitle",
            Amount = 1.00M,
            FinanceType = FinanceTypeDTO.Liabilities,
        };

        // Act
        var result = await handler.Handle(newFinanceCommand, CancellationToken.None);
        var newFinance = await _mockRepo.Object.GetByIdAsync(1);

        // Assert
        Assert.Equal(newFinanceCommand.Title, newFinance.Title);

    }    
}
