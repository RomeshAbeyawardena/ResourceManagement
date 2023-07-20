namespace ResourceManagement.Models;

public interface IResourceUserAccess
{
    Guid ResourceId { get; set; }
    Guid UserId { get; set; } 
    DateTimeOffset? CheckInTimestamp { get; set; }
    DateTimeOffset CheckOutTimestamp { get; set; }
}
