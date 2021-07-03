using System.Collections.Generic;

namespace EventListApi.Dtos
{
    public class EventDetailPageDto
    {
        public long numOfPages { get; set; }
        public IEnumerable<EventDetailReadDto> eventDetailsList { get; set; }
    }
}