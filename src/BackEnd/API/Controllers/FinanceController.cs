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
        var result = await _mediator.Send(new GetFinancesQuery());
        _logger.LogInformation("Return all finances", result);
     
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FinanceDTO>> Get(int id)
    {
        var result = await _mediator.Send(new GetFinanceQuery(id));
        _logger.LogInformation($"Return{id}", result);
     
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateFinanceCommand command)
    {
        var result = await _mediator.Send(command);
        _logger.LogInformation($"Finance: {result} has ben created");
     
        return Created($"/api/finances/{result}", result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(UpdateFinanceCommand command)
    {
        try
        {
            _ = await _mediator.Send(command);
            _logger.LogInformation($"Finance: {command.Id} wos updated");

            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<FinanceDTO>> Delete(int id)
    {
        _ = await _mediator.Send(new DeleteFinanceCommand(id));
        _logger.LogInformation($"Delete Finance: {id}");
        
        return NoContent();
    }
}
