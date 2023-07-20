using RST.Contracts;
using RST.Enumerations;

namespace ResourceManagement.Features.ResourceUserAccess;

public record GetPagedQuery : IPagedRequest<Models.ResourceUserAccess>, IQuery
{
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ResourceId { get; set; }
}
