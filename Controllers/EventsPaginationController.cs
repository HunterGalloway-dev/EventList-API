using System;
using System.Collections.Generic;
using AutoMapper;
using EventListApi.Data;
using EventListApi.Dtos;
using EventListApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventListApi.Controllers
{
    [Route("api/events/pages")]
    [ApiController]
    public class EventsPaginationController : ControllerBase
    {
        private readonly IEventListRepo _repository;
        private readonly IMapper _mapper;

        public EventsPaginationController(IEventListRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult <long> GetNumOfItems()
        {
            return _repository.Count();
        }

        [HttpGet("{pageSize}/{page}")]
        public ActionResult <IEnumerable<EventDetailReadDto>> GetEventsPagination(int pageSize, int page)
        {
            var eventItems = _repository.GetEventsPagination(pageSize, page);
            var eventDetails = _mapper.Map<IEnumerable<EventDetailReadDto>>(eventItems);

            return Ok(eventDetails);
        }

        [HttpGet("{pageSize}")]
        public ActionResult <long> GetNumOfPages(int pageSize)
        {
            return (long)Math.Round(((double) _repository.Count() + 0.51 )/ pageSize);
        }
    }
}