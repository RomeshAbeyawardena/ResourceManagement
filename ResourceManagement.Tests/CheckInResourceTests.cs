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
    private IMapper mapper;
    private IMediator mediator;
    private IClockProvider clockProvider;

    [SetUp]
    public void SetUp()
    {
        mapper = Substitute.For<IMapper>();
        mediator = mediator = Substitute.For<IMediator>();
        clockProvider = Substitute.For<IClockProvider>();
    }

    [Test]
    public async Task Handles_invalid_Id()
    {
        var handler = new CheckInResourceHandler(mapper, mediator, clockProvider);

        var entities = new List<Features.Models.ResourceUserAccess>
        {
            
        };

        // Create a mock IQueryable of TEntity
        var mockQueryable = entities.BuildMock();
        var id = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;
        
        mediator.Send(new Features.ResourceUserAccess.GetQuery { Id = id }, cancellationToken).Returns(mockQueryable);
        
        var result = await handler.Handle(new CheckInResourceCommand { 
            ResourceUserAccessId = id }, cancellationToken);
        
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Status, Is.EqualTo("Unable to check in resource, access not found"));
    }

    [Test]
    public async Task Handles_invalid_ResourceId()
    {
        var actualUserId = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;

        var users = new List<Features.Models.User> { 
            new Features.Models.User { Id = actualUserId }
        };

        mediator.Send(new Features.User.GetQuery { Id = actualUserId }, cancellationToken)
            .Returns(users.BuildMock());
        
        var handler = new CheckInResourceHandler(mapper, mediator, clockProvider);
        
        var response = await handler.Handle(new CheckInResourceCommand { UserId = actualUserId },
            cancellationToken);

        Assert.That(response.IsSuccess, Is.False);
        Assert.That(response.Status, Is.EqualTo("Unable to check in resource, parameters not supplied: ResourceId"));
    }

    [Test]
    public async Task Handles_invalid_UserId()
    {
        var actualResourceId = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;

        var users = new List<Features.Models.Resource> {
            new Features.Models.Resource { Id = actualResourceId }
        };

        mediator.Send(new Features.Resource.GetQuery { Id = actualResourceId }, cancellationToken)
            .Returns(users.BuildMock());

        var handler = new CheckInResourceHandler(mapper, mediator, clockProvider);

        var response = await handler.Handle(
            new CheckInResourceCommand { 
                ResourceId = actualResourceId},
            cancellationToken);

        Assert.That(response.IsSuccess, Is.False);
        Assert.That(response.Status, Is.EqualTo("Unable to check in resource, parameters not supplied: UserId"));
    }

    [Test]
    public async Task Handles_Resource_not_CheckedOut()
    {
        var actualUserId = Guid.NewGuid();
        var actualResourceId = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;

        var resources = new List<Features.Models.Resource> {
            new Features.Models.Resource { 
                Id = actualResourceId, 
                ResourceUserAccess = new List<Features.Models.ResourceUserAccess>() 
            }
        };

        mediator.Send(new Features.Resource.GetQuery { Id = actualResourceId }, cancellationToken)
            .Returns(resources.BuildMock());

        var users = new List<Features.Models.User> {
            new Features.Models.User { Id = actualUserId, 
                ResourceUserAccesses = new List<Features.Models.ResourceUserAccess>()
            }
        };

        mediator.Send(new Features.User.GetQuery { Id = actualUserId }, cancellationToken)
            .Returns(users.BuildMock());

        var handler = new CheckInResourceHandler(mapper, mediator, clockProvider);

        var response = await handler.Handle(
            new CheckInResourceCommand
            {
                ResourceId = actualResourceId,
                UserId = actualUserId
            },
            cancellationToken);
        Assert.That(response.IsSuccess, Is.False);
        Assert.That(response.Status, Is.Empty);
    }
}
