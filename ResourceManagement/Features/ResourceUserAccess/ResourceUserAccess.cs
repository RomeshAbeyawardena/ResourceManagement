using ResourceManagement.Models;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManagement.Features.Models;

[Table(nameof(ResourceUserAccess))]
public class ResourceUserAccess : IResourceUserAccess, IIdentity
{
    public Guid ResourceId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset? CheckInTimestamp { get; set; }
    public DateTimeOffset CheckOutTimestamp { get; set; }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public virtual Resource? Resource { get; set; }
    public virtual User? User { get; set; }
}
