using Danske_Sorting_Application.Exceptions;
using Danske_Sorting_Application.Interfaces;
using MediatR;

namespace Lakss.Application.SalesOrders;

public record GetOrderNumbersCommand : IRequest<string>;

public class GetOrderNumbersCommandHandler : IRequestHandler<GetOrderNumbersCommand, string>
{
    private readonly INumberOrderingRepository numberOrderingRepository;

    public GetOrderNumbersCommandHandler(INumberOrderingRepository numberOrderingRepository)
    {
        this.numberOrderingRepository = numberOrderingRepository;
    }

    public async Task<string?> Handle(GetOrderNumbersCommand request, CancellationToken cancellationToken)
    {
        var content = await numberOrderingRepository.GetLatestFileContentAsync(cancellationToken);

        if (content == null)
            throw new NotFoundException("Expected a file in storage, but none were found.");

        return content;
    }
}