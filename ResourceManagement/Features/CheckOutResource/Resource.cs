namespace ResourceManagement.Features.Models;

public partial record Resource
{
    public virtual ICollection<ResourceUserAccess>? ResourceUserAccess { get; set; }
}
