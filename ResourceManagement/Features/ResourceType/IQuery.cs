using Enums = ResourceManagement.Features.Enumerations;

namespace ResourceManagement.Features.ResourceType;

internal interface IQuery
{
    Guid? Id { get; set; }
    string? NameSearch { get; set; }
    Enums.ResourceType? ResourceType { get; set; }
}
