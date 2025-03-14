using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Danske_Sorting_Application.NumberOrderings;

public record SaveOrderedNumbersCommand(List<int>? numbers) : IRequest<Unit>;

public class SaveOrderedNumbersCommandHandler : IRequestHandler<SaveOrderedNumbersCommand, Unit>
{
    private readonly INumberOrderingService numberOrderingService;

    public SaveOrderedNumbersCommandHandler(INumberOrderingService numberOrderingService)
    {
        this.numberOrderingService = numberOrderingService;
    }

    public async Task<Unit> Handle(SaveOrderedNumbersCommand request, CancellationToken cancellationToken)
    {
        if (request.numbers == null || request.numbers.Count == 0)
            throw new ArgumentException("Expected a list of numbers, none were submitted.");

        await numberOrderingService.OrderNumbers(request.numbers, cancellationToken);

        return Unit.Value;
    }
}