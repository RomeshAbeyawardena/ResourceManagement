using ResourceManagement.Models;

namespace ResourceManagement.Features.CheckOutResource;

public record CheckOutResourceResponse : IStatusResult<Guid?>
{
    public string? Status { get; set; }
    public bool IsSuccess { get; set; }
    public Guid? Result { get; set; }
}
