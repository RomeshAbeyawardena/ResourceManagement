using MediatR;
using ResourceManagement.Models;
using RST.Contracts;

namespace ResourceManagement.Features.ResourceUserAccess;

public record SaveResourceUserAccessCommand : IRequest<Models.ResourceUserAccess>, IResourceUserAccess, IDbCommand
{
    public Guid? Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset? CheckInTimestamp { get; set; }
    public DateTimeOffset CheckOutTimestamp { get; set; }
    public bool CommitChanges { get; set; }
}
