using Lakss.Application.SalesOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Api.Controllers;

namespace Danske_Sorting_Application.Controllers;

public class NumberOrderController : ApiController
{
    public NumberOrderController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> List([FromQuery] GetOrderNumbersCommand command)
    {
        return await SendMessage(command);
    }

    [HttpPost]
    public async Task<ActionResult> Save([FromQuery] OrderNumbersCommand command)
    {
        return await SendMessage(command);
    }
}
