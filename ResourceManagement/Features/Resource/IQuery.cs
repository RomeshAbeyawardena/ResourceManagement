using Enums = ResourceManagement.Features.Enumerations;

namespace ResourceManagement.Features.Resource;

public interface IQuery
{
    Guid? Id { get; set; }
    string? NameSearch { get; set; }
    Enums.ResourceType? ResourceType { get; set; }
    Guid? ResourceTypeId { get; set; }
}
