using MediatR;
using ResourceManagement.Models;
using RST.Contracts;

namespace ResourceManagement.Features.ResourceType;

public class SaveResourceTypeCommand : IResource, IRequest<Models.ResourceType>, IDbCommand
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid ResourceTypeId { get; set; }
    public bool CommitChanges { get; set; }
}
