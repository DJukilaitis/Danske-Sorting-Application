using Danske_Sorting_Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NumberOrdering.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly IMediator mediator;

        protected ApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<ActionResult> SendMessage<TResponse>(IRequest<TResponse> request)
        {
            try
            {
                var response = await mediator.Send(request);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return NotFound(ex.Message);

                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
