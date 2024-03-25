using Application.Features.Finance.Queries;
using Application.Features.Finance.Queries.GetFinances;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/finances")]
public class FinanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public FinanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<FinanceDTO>> GetAll()
    {
        var finances = await _mediator.Send(new GetFinancesQuery());

        return finances;
    }

}
