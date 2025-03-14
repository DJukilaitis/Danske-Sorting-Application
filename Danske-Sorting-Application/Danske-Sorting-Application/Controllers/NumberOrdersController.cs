using Danske_Sorting_Application.NumberOrderings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Api.Controllers;

namespace Danske_Sorting_Application.Controllers;

public class NumberOrdersController : ApiController
{
    public NumberOrdersController(IMediator mediator) : base(mediator) { }

    [HttpGet("latest")]
    public async Task<ActionResult> GetLatestOrderedNumbers([FromQuery] GetLatestOrderedNumbersCommand command)
    {
        return await SendMessage(command);
    }

    [HttpPost("save")]
    public async Task<ActionResult> SaveOrderedNumbers([FromBody] SaveOrderedNumbersCommand command)
    {
        return await SendMessage(command);
    }
}
