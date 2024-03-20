using Moq;
using Test.Mocks;
using AutoMapper;
using Application.Contracts.Persistance;
using Application.MappingProfiles;
using Application.Features.Finance.Queries.GetAllFinances;
using Shouldly;
using Application.Features.Finance.Queries;
using Application.Contracts.Exceptions;

namespace Test.Features.Finance.Queries;

public class GetFinanceListQueryHandlerTests
{
    private readonly Mock<IFinanceRepository> _mockRepo;
    private IMapper _mapper;


    public GetFinanceListQueryHandlerTests()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();

        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<FinanceProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAllFinancesQueryHandler_Should_Return_List_of_FinanceDTO_List()
    {
        // Arrange
        var handler = new GetAllFinancesQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetAllFinancesQuery(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<FinanceDTO>>();
    }

    [Fact]
    public async Task GetAllFinancesQueryHandler_Should_Greater_Than_0()
    {
        // Arrange
        var handler = new GetAllFinancesQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetAllFinancesQuery(), CancellationToken.None);

        // Assert
        result.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task GetAllFinancesQueryHandler_Should_Throw_NotFoundException()
    {
        // Arrange
        #pragma warning disable CS8603 // Possible null reference return.
        _mockRepo.Setup(m => m.GetAsync()).ReturnsAsync(() => null);
        #pragma warning restore CS8603 // Possible null reference return.
        var handler = new GetAllFinancesQueryHandler(_mapper, _mockRepo.Object);

        // Act & Assert
        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new GetAllFinancesQuery(), CancellationToken.None);
        });
    }
}