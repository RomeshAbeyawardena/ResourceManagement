using MediatR;
using ResourceManagement.Models;
using RST.Contracts;

namespace ResourceManagement.Features.User;

public record SaveUserCommand : IRequest<Models.User>, IUser, IDbCommand
{
    public Guid? Id { get; set; }
    public string? EmailAddressId { get; set; }
    public string? UserName { get; set; }
    public bool CommitChanges { get; set; }
}
