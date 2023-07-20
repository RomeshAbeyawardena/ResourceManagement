using MediatR;
using RST.Contracts;

namespace ResourceManagement.Features.CheckOutResource;

public record CheckOutResourceCommand : IRequest<CheckOutResourceResponse>, IDbCommand
{
    public Guid ResourceId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset CheckOutTimestamp { get; set; }
    public bool CommitChanges { get; set; }
}
