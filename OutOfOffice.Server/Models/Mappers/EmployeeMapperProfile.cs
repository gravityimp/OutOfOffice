using AutoMapper;
using OutOfOffice.Server.Models.Dto.Employee;

namespace OutOfOffice.Server.Models.Mappers
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<EmployeeDtoPost, Employee>();

            CreateMap<Employee, EmployeeDtoGetShort>();
            CreateMap<Employee, EmployeeDtoGet>()
                .ForMember(e => e.PeoplePartner, e => e.MapFrom(src => src.PeoplePartnerRef));
        }
    }
}
