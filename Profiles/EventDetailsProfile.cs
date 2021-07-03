using AutoMapper;
using EventListApi.Dtos;
using EventListApi.Models;

namespace EventListApi.Profiles
{
    public class EventDetailsProfile : Profile
    {
        public EventDetailsProfile()
        {
            // Source -> Target
            CreateMap<EventDetail, EventDetailReadDto>();
            CreateMap<EventDetailCreateDto, EventDetail>();
            CreateMap<EventDetailUpdateDto, EventDetail>();
            CreateMap<EventDetail, EventDetailUpdateDto>();
        }
    }
}