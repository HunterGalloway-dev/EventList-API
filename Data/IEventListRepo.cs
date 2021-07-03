using System.Collections.Generic;
using EventListApi.Models;

namespace EventListApi.Data
{
    public interface IEventListRepo
    {
        bool SaveChanges();

        IEnumerable<EventDetail> GetAllEvents();
        EventDetail GetEventById(int id);
        IEnumerable<EventDetail> GetEventsPagination(int pageSize, int page);
        void CreateEventDetail(EventDetail eventDetail);
        void UpdateEventDetail(EventDetail eventDetail);
        void DeleteEventDetail(EventDetail eventDetail);
        long Count();
    }
}