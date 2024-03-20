using Moq;
using Test.Mocks;
using AutoMapper;
using Shouldly;
using Application.Contracts.Persistance;
using Application.MappingProfiles;
using Application.Features.Finance.Command.CreateFinance;
using Application.Features.Finance.Queries;

namespace Test.Features.Finance.Commands;

public class CreateFinanceCommandHandlerTest
{
    private IMapper _mapper;
    private readonly Mock<IFinanceRepository> _mockRepo;

    public CreateFinanceCommandHandlerTest()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();

        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<FinanceProfile>();
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

    // CreateFinanceCommandHandler_Shound_Reeturn_Error When Title is empty or null
    // CreateFinanceCommandHandler_Shound_Reeturn_Error When Title have more than 70 characters
    


}
