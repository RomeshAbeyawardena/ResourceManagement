using ResourceManagement.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManagement.Features.Models;

[Table(nameof(User))]
public partial record User : IUser, IIdentity
{
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 755)]
    public string? EmailAddressId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 255)]
    public string? UserName { get; set; }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
