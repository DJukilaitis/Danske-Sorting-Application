using Danske_Sorting_Application.NumberOrderings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Api.Controllers;

namespace Danske_Sorting_Application.Controllers;

public class NumberOrderController : ApiController
{
    public NumberOrderController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] GetOrderNumbersCommand command)
    {
        return await SendMessage(command);
    }

    [HttpPost]
    public async Task<ActionResult> Order([FromBody] SaveOrderNumbersCommand command)
    {
        return await SendMessage(command);
    }
}
