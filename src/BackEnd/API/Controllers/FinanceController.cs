using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Contracts.Logging;
using Application.Features.Finance.Command.UpdateCommand;
using Application.Features.Finance.Queries;
using Application.Features.Finance.Queries.GetFinance;
using Application.Features.Finance.Queries.GetFinances;
using Application.Features.Finance.Command.CreateFinance;
using Application.Features.Finance.Command.DeleteFinance;

namespace API.Controllers;

[ApiController]
[Route("api/finances")]
public class FinanceController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAppLogger<FinanceController> _logger;

    public FinanceController(IMediator mediator, IAppLogger<FinanceController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<FinanceDTO>>> Get()
    {
        _logger.LogInformation($"Send as mediator: GetFinancesQuery()");
        var result = await _mediator.Send(new GetFinancesQuery());
        _logger.LogInformation("Return all finances: ", result);
     
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FinanceDTO>> Get(int id)
    {
        _logger.LogInformation($"Send as mediator: GetFinanceQuery({id})");
        var result = await _mediator.Send(new GetFinanceQuery(id));
        _logger.LogInformation($"Return: {id}", result);
     
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateFinanceCommand command)
    {
        _logger.LogInformation($"Send as mediator: CreateFinanceCommand()");
        var result = await _mediator.Send(command);
        _logger.LogInformation($"New FinanceId: {result} has ben created");
     
        return Created($"/api/finances/{result}", result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(UpdateFinanceCommand command)
    {
        _logger.LogInformation($"Send as mediator: UpdateFinanceCommand()");
        _ = await _mediator.Send(command);
        _logger.LogInformation($"FinanceId: {command.Id} wos updated");
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<FinanceDTO>> Delete(int id)
    {
        _logger.LogInformation($"Send as mediator: DeleteFinanceCommand({id})");
        _ = await _mediator.Send(new DeleteFinanceCommand(id));
        _logger.LogInformation($"Delete FinanceID: {id}, has been deleted");
        
        return NoContent();
    }
}
