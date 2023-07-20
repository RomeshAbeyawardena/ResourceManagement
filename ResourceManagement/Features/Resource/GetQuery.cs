using MediatR;

namespace ResourceManagement.Features.Resource;

public record GetQuery : IRequest<IQueryable<Models.Resource>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; set; }
    public Enumerations.ResourceType? ResourceType { get; set; }
    public Guid? ResourceTypeId { get; set; }
}
