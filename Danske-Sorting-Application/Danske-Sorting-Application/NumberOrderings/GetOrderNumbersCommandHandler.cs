using Danske_Sorting_Application.Exceptions;
using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Danske_Sorting_Application.NumberOrderings;

public record GetOrderNumbersCommand : IRequest<string>;

public class GetOrderNumbersCommandHandler : IRequestHandler<GetOrderNumbersCommand, string>
{
    private readonly INumberOrderingRepository numberOrderingRepository;

    public GetOrderNumbersCommandHandler(INumberOrderingRepository numberOrderingRepository)
    {
        this.numberOrderingRepository = numberOrderingRepository;
    }

    public async Task<string> Handle(GetOrderNumbersCommand request, CancellationToken cancellationToken)
    {
        var content = await numberOrderingRepository.GetLatestFileContentAsync(cancellationToken);

        return content ?? throw new NotFoundException("Expected a file in storage, but none were found.");
    }
}