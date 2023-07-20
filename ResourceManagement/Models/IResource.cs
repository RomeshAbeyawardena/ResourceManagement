namespace ResourceManagement.Models;

internal interface IResource
{
    string? Name { get; set; }
    Guid ResourceTypeId { get; set; }
}
