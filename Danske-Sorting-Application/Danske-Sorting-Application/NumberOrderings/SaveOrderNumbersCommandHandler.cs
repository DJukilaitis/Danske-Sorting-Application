using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Danske_Sorting_Application.NumberOrderings;

public record SaveOrderNumbersCommand(List<int>? numbers) : IRequest<Unit>;

public class SaveOrderNumbersCommandHandler : IRequestHandler<SaveOrderNumbersCommand, Unit>
{
    private readonly INumberOrderingService numberOrderingService;

    public SaveOrderNumbersCommandHandler(INumberOrderingService numberOrderingService)
    {
        this.numberOrderingService = numberOrderingService;
    }

    public async Task<Unit> Handle(SaveOrderNumbersCommand request, CancellationToken cancellationToken)
    {
        if (request.numbers == null || request.numbers.Count == 0)
            throw new ArgumentException("Expected a list of numbers, none were submitted.");

        await numberOrderingService.OrderNumbers(request.numbers, cancellationToken);

        return Unit.Value;
    }
}