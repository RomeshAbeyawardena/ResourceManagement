namespace ResourceManagement.Models;

public interface IStatusResult<T>
{
    string? Status { get; set; }
    bool IsSuccess { get; set; }
    T? Result { get; set; }
}
