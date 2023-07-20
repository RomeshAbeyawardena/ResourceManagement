using ResourceManagement.Models;

namespace ResourceManagement.Features.CheckInResource;

public record CheckInResourceResponse : IStatusResult<Guid>
{
    public string? Status { get; set; }
    public bool IsSuccess { get; set; }
    public Guid Result { get; set; }
}
