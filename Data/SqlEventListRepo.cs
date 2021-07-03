using System;
using System.Collections.Generic;
using System.Linq;
using EventListApi.Models;

namespace EventListApi.Data
{
    public class SqlEventListRepo : IEventListRepo
    {
        private readonly EventListContext _context;

        public SqlEventListRepo(EventListContext context)
        {
            _context = context;
        }

        public void CreateEventDetail(EventDetail eventDetail)
        {
            if(eventDetail == null)
            {
                throw new ArgumentNullException(nameof (eventDetail));
            }

            _context.Events.Add(eventDetail);
        }

        public void DeleteEventDetail(EventDetail eventDetail)
        {
            if(eventDetail == null)
            {
                throw new ArgumentNullException(nameof(eventDetail));
            }
            _context.Events.Remove(eventDetail);
        }

        public IEnumerable<EventDetail> GetAllEvents()
        {
            return getSortedEvents();
        }

        public IEnumerable<EventDetail> getSortedEvents()
        {
            var eventDetailsList = _context.Events.ToList();
            eventDetailsList.Sort(new EventDetailComparerDate());

            return eventDetailsList;
        }

        public IEnumerable<EventDetail> GetEventsPagination(int pageSize, int page)
        {
            int excludeNumber = pageSize*page;

            return getSortedEvents().Skip(excludeNumber).Take(pageSize);
        }

        public EventDetail GetEventById(int id)
        {
            return _context.Events.FirstOrDefault(p => p.EventDetailId == id);
        }

        public void UpdateEventDetail(EventDetail eventDetail)
        {
            // Nothing
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public long Count()
        {
            return _context.Events.Count();
        }

    }
}