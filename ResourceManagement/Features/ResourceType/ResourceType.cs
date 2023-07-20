using ResourceManagement.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManagement.Features.Models
{
    [Table(nameof(ResourceType))]
    public record ResourceType : IResourceType, IIdentity
    {
        [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
        public string? Name { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
