using System;
using System.Collections.Generic;

namespace EventListApi.Models
{
    public class EventDetailComparerDate : Comparer<EventDetail>
    {
        public override int Compare(EventDetail x, EventDetail y)
        {
            return -1 * x.CreatedDate.CompareTo(y.CreatedDate);;
        }
    }
}