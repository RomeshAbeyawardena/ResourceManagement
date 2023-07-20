using MediatR;

namespace ResourceManagement.Features.User;

public record GetQuery : IRequest<IQueryable<Models.User>>, IQuery
{
    public string? UserSearch { get; set; }
    public Guid? Id { get; set; }
}
