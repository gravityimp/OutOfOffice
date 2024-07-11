using AutoMapper;
using OutOfOffice.Server.Models.Dto.Project;

namespace OutOfOffice.Server.Models.Mappers
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<ProjectDtoPost, Project>();

            CreateMap<Project, ProjectDtoGetShort>()
                .ForMember(p => p.ProjectManager, p => p.MapFrom(src => src.ProjectManagerRef));
            CreateMap<Project, ProjectDtoGet>()
                .ForMember(p => p.ProjectManager, p => p.MapFrom(src => src.ProjectManagerRef));
        }
    }
}
