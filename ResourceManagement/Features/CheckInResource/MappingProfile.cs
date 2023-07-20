using AutoMapper;
using ResourceManagement.Features.ResourceUserAccess;

namespace ResourceManagement.Features.CheckInResource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CheckInResourceCommand, SaveResourceUserAccessCommand>()
            .ForMember(m => m.Id, opt => opt.MapFrom(m => m.ResourceUserAccessId));
    }
}
