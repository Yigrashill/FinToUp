using Moq;
using Test.Mocks;
using AutoMapper;
using Application.Contracts.Persistance;
using Application.MappingProfiles;
using Application.Features.Finance.Queries;
using Application.Features.Finance.Queries.GetFinance;

namespace Test.Features.Finance.Queries;

public class GetFinanceQueryHandlerTests
{
    private readonly Mock<IFinanceRepository> _mockRepo;
    private IMapper _mapper;

    public GetFinanceQueryHandlerTests()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<FinanceProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetFinanceQueryHandler_Dhould_Return__FinanceDTO()
    {
        // Arrange
        var handler = new  GeFinanceQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetFinanceQuery(1), CancellationToken.None);

        result.ShouldBeOfType<FinanceDTO>();
    }

}
