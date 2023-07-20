namespace ResourceManagement.Features.User;

public interface IQuery
{
    Guid? Id { get; set; }
    string? UserSearch { get; set; }
}
