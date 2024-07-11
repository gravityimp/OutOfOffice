using AutoMapper;

namespace OutOfOffice.Server.Models.Mappers
{
    public class DateMapper : Profile
    {
        public DateMapper() 
        {
            CreateMap<DateTime, DateOnly>().ConvertUsing(e => DateOnly.FromDateTime(e));
            CreateMap<DateOnly, DateTime>().ConvertUsing(e => e.ToDateTime(TimeOnly.MinValue));
        }
    }
}
