using System;
using System.Collections.Generic;
using EventListApi.Models;

namespace EventListApi.Data
{
    public class MockEventListRepo : IEventListRepo
    {
        public long Count()
        {
            throw new NotImplementedException();
        }

        public void CreateEventDetail(EventDetail eventDetail)
        {
            throw new NotImplementedException();
        }

        public void DeleteEventDetail(EventDetail eventDetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventDetail> GetAllEvents()
        {
            var events = new List<EventDetail>
            {
                new EventDetail{EventDetailId = 0, Name = "Test Event Name1", Caption="Test Event Caption1", Description="Test Event Description1", CreatedDate=DateTime.Parse("2021-02-26 04:19:50.913")},
                new EventDetail{EventDetailId = 0, Name = "Test Event Name2", Caption="Test Event Caption2", Description="Test Event Description2", CreatedDate=DateTime.Parse("2021-02-26 05:19:50.913")},
                new EventDetail{EventDetailId = 0, Name = "Test Event Name3", Caption="Test Event Caption3", Description="Test Event Description3", CreatedDate=DateTime.Parse("2021-02-26 06:19:50.913")}
            };

            return events;
        }

        public EventDetail GetEventById(int id)
        {
            return new EventDetail {EventDetailId = 0, Name = "Test Event Name By ID", Caption="Test Event Caption", Description="Test Event Description", CreatedDate=DateTime.Parse("2021-02-26 04:19:50.913")};
        }

        public IEnumerable<EventDetail> GetEventsPagination(int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEventDetail(EventDetail eventDetail)
        {
            throw new NotImplementedException();
        }
    }
}