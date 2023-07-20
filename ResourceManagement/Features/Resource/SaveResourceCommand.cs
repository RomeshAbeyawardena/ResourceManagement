using MediatR;
using ResourceManagement.Models;
using RST.Contracts;

namespace ResourceManagement.Features.Resource;

public class SaveResourceCommand : IRequest<Models.Resource>, IResource, IDbCommand
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid ResourceTypeId { get; set; }
    public bool CommitChanges { get; set; }
}
