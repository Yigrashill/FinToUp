using Application.Contracts.Persistance;
using Application.MappingProfiles;
using Application.Features.Finance.Queries;
using Application.Features.Finance.Queries.GetFinance;
using Application.Contracts.Logging;

namespace Test.Features.Finance.Queries;

public class GetFinanceQueryHandlerTests
{
    private IMapper _mapper;
    private Mock<IAppLogger<GeFinanceQueryHandler>> _mocklogger;
    private readonly Mock<IFinanceRepository> _mockRepo;

    public GetFinanceQueryHandlerTests()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<FinanceProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _mocklogger = new Mock<IAppLogger<GeFinanceQueryHandler>>();
    }

    [Fact]
    public async Task GetFinanceQueryHandler_Dhould_Return__FinanceDTO()
    {
        // Arrange
        var handler = new  GeFinanceQueryHandler(_mapper, _mocklogger.Object, _mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetFinanceQuery(1), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<FinanceDTO>();
    }
}
