using AutoMapper;

namespace ResourceManagement.Features.CheckOutResource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CheckOutResourceCommand, ResourceUserAccess.SaveResourceUserAccessCommand>();
    }
}
