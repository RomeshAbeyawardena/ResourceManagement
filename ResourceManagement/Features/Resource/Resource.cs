using ResourceManagement.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums = ResourceManagement.Features.Enumerations;
namespace ResourceManagement.Features.Models;

public partial record Resource : IResource, IIdentity
{
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    public Guid ResourceTypeId { get; set; }

    public virtual ResourceType? ResourceType { get; set; }

    [NotMapped, EnumDataType(typeof(Enums.ResourceType))] 
    public Enums.ResourceType? Type => Enum.TryParse<Enums.ResourceType>(ResourceType?.Name, out var resourceType) ? resourceType : null;

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
}
