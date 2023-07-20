using RST.Contracts;
using RST.Enumerations;

namespace ResourceManagement.Features.Resource;

public record GetPagedQuery : IPagedRequest<Models.Resource>, IQuery
{
    public string? NameSearch { get; set; }
    public Enumerations.ResourceType? ResourceType { get; set; }
    public Guid? ResourceTypeId { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
}
