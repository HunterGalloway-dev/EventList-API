using EventListApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventListApi.Data
{
    public class EventListContext : DbContext
    {
        public EventListContext(DbContextOptions<EventListContext> opt) : base(opt)
        {
        }

        public DbSet<EventDetail> Events { get; set; }
        
    }
}