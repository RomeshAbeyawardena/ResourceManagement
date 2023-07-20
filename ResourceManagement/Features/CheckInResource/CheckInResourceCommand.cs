using MediatR;
using RST.Contracts;

namespace ResourceManagement.Features.CheckInResource;

public record CheckInResourceCommand : IRequest<CheckInResourceResponse>, IDbCommand
{
    public Guid? ResourceUserAccessId { get; set; }
    public Guid? ResourceId { get; set; }
    public Guid? UserId { get; set; }
    public DateTimeOffset? CheckInTimestamp { get; set; }
    public bool CommitChanges { get; set; }
}
