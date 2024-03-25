using Application.Contracts.Logging;
using Application.Features.Finance.Queries;
using Application.Features.Finance.Queries.GetFinance;
using Application.Features.Finance.Queries.GetFinances;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        try
        {
            var finances = await _mediator.Send(new GetFinancesQuery());

            _logger.LogInformation("Return all finances", finances);
            return Ok(finances);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FinanceDTO>> Get(int id)
    {
        try
        {
            var finacne = await _mediator.Send(new GetFinanceQuery(id));

            _logger.LogInformation($"Return{id}", finacne);
            return Ok(finacne);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

}
