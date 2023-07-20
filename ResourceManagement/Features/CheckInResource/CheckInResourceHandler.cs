using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResourceManagement.Features.CheckOutResource;
using RST.Contracts;

namespace ResourceManagement.Features.CheckInResource;

public class CheckInResourceHandler : IRequestHandler<CheckInResourceCommand, CheckInResourceResponse>
{
    private readonly IMapper mapper;
    private readonly IMediator mediator;
    private readonly IClockProvider clockProvider;

    public CheckInResourceHandler(IMapper mapper, IMediator mediator, IClockProvider clockProvider)
    {
        this.mapper = mapper;
        this.mediator = mediator;
        this.clockProvider = clockProvider;
    }

    public async Task<CheckInResourceResponse> Handle(CheckInResourceCommand request, CancellationToken cancellationToken)
    {
        if (request.ResourceId.HasValue && request.UserId.HasValue)
        {
            var resources = await mediator.Send(new Resource.GetQuery { Id = request.ResourceId }, cancellationToken);
            //check resource exists
            if (!await resources.AnyAsync(cancellationToken))
            {
                return new CheckInResourceResponse
                {
                    IsSuccess = false,
                    Status = "Resource not found"
                };
            }

            var users = await mediator.Send(new User.GetQuery { Id = request.UserId }, cancellationToken);
            //check user exists
            if (!await users.AnyAsync(cancellationToken))
            {
                return new CheckInResourceResponse
                {
                    IsSuccess = false,
                    Status = "User not found"
                };
            }

            var userAccess = await users.SelectMany(u => u.ResourceUserAccesses!).FirstOrDefaultAsync(u => !u.CheckInTimestamp.HasValue, cancellationToken);

            if (userAccess != null)
            {
                request.ResourceUserAccessId = userAccess.Id;
            }
        }
        else if (request.ResourceUserAccessId.HasValue)
        {
            var resourceUserAccesses = await mediator.Send(new ResourceUserAccess.GetQuery { Id = request.ResourceUserAccessId }, cancellationToken);

            if (!await resourceUserAccesses.AnyAsync(cancellationToken))
            {
                return new CheckInResourceResponse
                {
                    Status = "Unable to check in resource, access not found"
                };
            }

            var resourceUserAccess = await resourceUserAccesses.FirstAsync(cancellationToken);
            request.ResourceId = resourceUserAccess.ResourceId;
            request.UserId = resourceUserAccess.UserId;
        }

        if (!request.ResourceUserAccessId.HasValue)
        {
            return new CheckInResourceResponse
            {
                Status = "Unable to check in resource, parameters not supplied"
            };
        }

        if(!request.CheckInTimestamp.HasValue)
        {
            request.CheckInTimestamp = clockProvider.UtcNow;
        }

        var saveCommand = mapper.Map<ResourceUserAccess.SaveResourceUserAccessCommand>(request);

        saveCommand.CommitChanges = true;

        var savedResourceUserAccess = await mediator.Send(saveCommand, cancellationToken);

        return new CheckInResourceResponse { 
            IsSuccess = true,
            Result = savedResourceUserAccess.Id,
            Status = "Resource successfully checked out"
        };
    }
}
