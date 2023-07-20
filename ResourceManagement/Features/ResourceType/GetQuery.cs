using MediatR;

namespace ResourceManagement.Features.ResourceType;

public record GetQuery : IRequest<IQueryable<Models.ResourceType>>, IQuery
{
    public string? NameSearch { get; set; }
    public Enumerations.ResourceType? ResourceType { get; set; }
    public Guid? Id { get; set; }
}
