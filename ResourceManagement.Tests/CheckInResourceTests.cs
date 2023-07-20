using AutoMapper;
using MediatR;
using MockQueryable.NSubstitute;
using NSubstitute;
using ResourceManagement.Features.CheckInResource;
using RST.Contracts;

namespace ResourceManagement.Tests;

[TestFixture]
public class CheckInResourceTests
{
    [Test]
    public async Task Handles_InvalidResourceId_or_UserId()
    {
        var mapper = Substitute.For<IMapper>();
        var mediator = Substitute.For<IMediator>();
        var clockProvider = Substitute.For<IClockProvider>();
        var handler = new CheckInResourceHandler(mapper, mediator, clockProvider);

        var entities = new List<Features.Models.ResourceUserAccess>
        {
            new Features.Models.ResourceUserAccess(),
            new Features.Models.ResourceUserAccess(),
            new Features.Models.ResourceUserAccess()
        };
        // Create a mock IQueryable of TEntity
        var mockQueryable = entities.BuildMock();
        var id = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;
        mediator.Send(new Features.ResourceUserAccess.GetQuery { Id = id }, cancellationToken).Returns(mockQueryable);
        
        var result = await handler.Handle(new CheckInResourceCommand { ResourceUserAccessId = id }, cancellationToken);
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Status, Is.EqualTo("Unable to check in resource, parameters not supplied"));
    }
}
