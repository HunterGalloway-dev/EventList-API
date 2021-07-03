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
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventListRepo _repository;
        private readonly IMapper _mapper;

        public EventsController(IEventListRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/events
        [HttpGet]
        public ActionResult <IEnumerable<EventDetailReadDto>> GetAllEvents()
        {
            var eventItems = _repository.GetAllEvents();

            return Ok(_mapper.Map<IEnumerable<EventDetailReadDto>>(eventItems));
        }

        [HttpGet("api/events/pages/{pageSize}/{page}")]
        public ActionResult <IEnumerable<EventDetailReadDto>> GetEventsPagination(int pageSize, int page)
        {
            var eventItems = _repository.GetEventsPagination(pageSize, page);
            var eventDetails = _mapper.Map<IEnumerable<EventDetailReadDto>>(eventItems);

            return Ok(eventDetails);
        }

        [HttpGet("api/events/pages/{pageSize}")]
        public ActionResult <long> GetNumOfPages(int pageSize)
        {
            return (long)Math.Round(((double) _repository.Count() + 0.51 )/ pageSize);
        }

        // GET api/events/{id}
        [HttpGet("{id}", Name="GetEventById")]
        public ActionResult <EventDetailReadDto> GetEventById(int id)
        {
            var eventItem = _repository.GetEventById(id);

            if(eventItem != null) {
                return Ok(_mapper.Map<EventDetailReadDto>(eventItem));
            } else {
                return NotFound();
            }

        }

        // POST api/events
        [HttpPost]
        public ActionResult <EventDetailReadDto> CreateEventDetail(EventDetailCreateDto eventDetailCreateDto)
        {
            var eventDetailModel = _mapper.Map<EventDetail>(eventDetailCreateDto);
            _repository.CreateEventDetail(eventDetailModel);
            _repository.SaveChanges();

            var eventDetailReadDto = _mapper.Map<EventDetailReadDto>(eventDetailModel);

            return CreatedAtRoute(nameof(GetEventById), new {Id = eventDetailReadDto.EventDetailId}, eventDetailReadDto);
            //return Ok(eventDetailReadDto);
        }

        // DELETE api/events/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEventDetail(int id)
        {
            var eventDetailModel = _repository.GetEventById(id);

            if(eventDetailModel == null)
            {
                return NotFound();
            }

            _repository.DeleteEventDetail(eventDetailModel);
            _repository.SaveChanges();

            return NoContent();
        }

        // PUT api/events/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEventDetail(int id, EventDetailUpdateDto EventDetailUpdateDto)
        {
            var eventDetailModel = _repository.GetEventById(id);

            if(eventDetailModel == null)
            {
                return NotFound();
            }

            // Ok this code is because mapper is overwriting the already created value in eventDetailModel ID so I have to put it back in after
            // I know there is a better way to do it but I am making it work before I clean it up.
            // If this is still here, I either forgot about this, or didn't find the time to clean it up

            long tempId = eventDetailModel.EventDetailId;
            _mapper.Map(EventDetailUpdateDto, eventDetailModel);
            eventDetailModel.EventDetailId = tempId;

            // Simply here incase further implementations of repository actually apply an update
            _repository.UpdateEventDetail(eventDetailModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEventDetailUpdate(int  id, JsonPatchDocument<EventDetailUpdateDto> patchDoc)
        {
            var eventDetailModel = _repository.GetEventById(id);
            Console.WriteLine(eventDetailModel.ThumbnailImageName);

            if(eventDetailModel == null)
            {
                return NotFound();
            }

            var eventDetailToPatch = _mapper.Map<EventDetailUpdateDto>(eventDetailModel);

            patchDoc.ApplyTo(eventDetailToPatch, ModelState);
            // if(!TryValidateModel(eventDetailToPatch))
            // {
            //     return ValidationProblem(ModelState);
            // } Gave me error of miss input idk why but it works without so sadly this error is but a mystery

            long tempId = eventDetailModel.EventDetailId;
            _mapper.Map(eventDetailToPatch, eventDetailModel);
            eventDetailModel.EventDetailId = tempId;



            _repository.UpdateEventDetail(eventDetailModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}