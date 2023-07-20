using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ResourceManagement.Features.CheckOutResource;

public class CheckOutResourceHandler : IRequestHandler<CheckOutResourceCommand, CheckOutResourceResponse>
{
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public CheckOutResourceHandler(IMapper mapper, IMediator mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }
    public async Task<CheckOutResourceResponse> Handle(CheckOutResourceCommand request, CancellationToken cancellationToken)
    {
        //get user
        var users = await mediator.Send(new User.GetQuery { Id = request.UserId }, cancellationToken);
        //check user exists
        if (!await users.AnyAsync(cancellationToken))
        {
            return new CheckOutResourceResponse
            {
                IsSuccess = false,
                Status = "User not found"
            };
        }

        var firstUser = await users.FirstAsync(cancellationToken);
        //get resource
        var resources = await mediator.Send(new Resource.GetQuery { Id = request.ResourceId }, cancellationToken);
        //check resource exists
        if (!await resources.AnyAsync(cancellationToken))
        {
            return new CheckOutResourceResponse
            {
                IsSuccess = false,
                Status = "Resource not found"
            };
        }

        //ensure resource is not already checked out by any user
        if (await resources.AnyAsync(r => r.Id == request.ResourceId &&  r.ResourceUserAccess!.Any(rua => !rua.CheckInTimestamp.HasValue), cancellationToken))
        {
            return new CheckOutResourceResponse
            {
                IsSuccess = false,
                Status = "Resource already checked out"
            };
        }

        //create checkout record
        var saveCommand = mapper.Map<ResourceUserAccess.SaveResourceUserAccessCommand>(request);
        var resourceUserAccess = await mediator.Send(saveCommand, cancellationToken);

        return new CheckOutResourceResponse { 
            IsSuccess = true,
            Result = resourceUserAccess.Id,
            Status = "Resource has been successfully checked out"
        };
    }
}
