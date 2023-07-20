namespace ResourceManagement.Features.Models;

public partial record User
{
    public virtual ICollection<ResourceUserAccess>? ResourceUserAccesses { get; set; }
}
