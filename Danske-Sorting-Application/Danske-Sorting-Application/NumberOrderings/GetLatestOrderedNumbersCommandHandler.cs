using Danske_Sorting_Application.Exceptions;
using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Danske_Sorting_Application.NumberOrderings;

public record GetLatestOrderedNumbersCommand : IRequest<string>;

public class GetLatestOrderedNumbersCommandHandler : IRequestHandler<GetLatestOrderedNumbersCommand, string>
{
    private readonly INumberOrderingRepository numberOrderingRepository;

    public GetLatestOrderedNumbersCommandHandler(INumberOrderingRepository numberOrderingRepository)
    {
        this.numberOrderingRepository = numberOrderingRepository;
    }

    public async Task<string> Handle(GetLatestOrderedNumbersCommand request, CancellationToken cancellationToken)
    {
        var content = await numberOrderingRepository.GetLatestFileContentAsync(cancellationToken);

        return content ?? throw new NotFoundException("Expected a file in storage, but none were found.");
    }
}