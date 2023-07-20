namespace ResourceManagement.Features.ResourceUserAccess;

public interface IQuery
{
    Guid? Id { get; set; }
    Guid? UserId { get; set; }
    Guid? ResourceId { get; set; }
}
