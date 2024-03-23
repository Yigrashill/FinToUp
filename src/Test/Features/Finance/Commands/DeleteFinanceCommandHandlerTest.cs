using Application.Contracts.Exceptions;
using Application.Contracts.Persistance;
using Application.Features.Finance.Command.DeleteFinance;

namespace Test.Features.Finance.Commands;

public class DeleteFinanceCommandHandlerTest
{
    private readonly Mock<IFinanceRepository> _mockRepo;

    public DeleteFinanceCommandHandlerTest()
    {
        _mockRepo = MockFinanceRepository.GetMockFinanceRepository();
    }

    [Fact]
    public async Task DeleteFinacneCommandHandlert_Should_Delete_Singele_Finance()
    {
        // Arrange
        var repoItems = await _mockRepo.Object.GetAsync();
        var actualItemCount = repoItems.Count();
        var handler = new DeleteFinanceCommandHandler(_mockRepo.Object);

        // Act
        await handler.Handle(new DeleteFinanceCommand(1), CancellationToken.None);
        var repoItems2 = await _mockRepo.Object.GetAsync();
        var actualItemCount2 = repoItems2.Count();

        // Assert
        actualItemCount2.ShouldBe(actualItemCount -1);
    }

    [Fact]
    public async Task DeleteFinacneCommandHandlert_Should_Throw_NotFoundException_when_Item_Dont_Exist()
    {
        // Arrange
        var handler = new DeleteFinanceCommandHandler(_mockRepo.Object);

        // Act & Assert
        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new DeleteFinanceCommand(20), CancellationToken.None);
        });
    }
}
