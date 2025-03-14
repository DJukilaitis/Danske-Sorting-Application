using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Lakss.Application.SalesOrders;

public record OrderNumbersCommand(List<int>? numbers) : IRequest<Unit>;

public class OrderNumbersCommandHandler : IRequestHandler<OrderNumbersCommand, Unit>
{
    private readonly INumberOrderingService numberOrderingService;

    public OrderNumbersCommandHandler(INumberOrderingService numberOrderingService)
    {
        this.numberOrderingService = numberOrderingService;
    }

    public async Task<Unit> Handle(OrderNumbersCommand request, CancellationToken cancellationToken)
    {
        if (request.numbers == null || request.numbers.Count == 0)
            throw new ArgumentException("Expected a list of numbers, none were submitted.");

        await numberOrderingService.OrderNumbers(request.numbers, cancellationToken);

        return Unit.Value;
    }
}