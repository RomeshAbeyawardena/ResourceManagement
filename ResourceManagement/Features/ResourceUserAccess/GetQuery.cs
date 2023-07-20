using MediatR;

namespace ResourceManagement.Features.ResourceUserAccess;

public record GetQuery : IRequest<IQueryable<Models.ResourceUserAccess>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ResourceId { get; set; }
}
