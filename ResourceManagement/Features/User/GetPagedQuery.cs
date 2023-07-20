using MediatR;
using RST.Contracts;
using RST.Enumerations;

namespace ResourceManagement.Features.User;

public record GetPagedQuery : IPagedRequest<Models.User>, IQuery
{
    public string? UserSearch { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
}
