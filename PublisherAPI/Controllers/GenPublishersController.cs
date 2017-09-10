using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublisherWebAPI.Entities;
using PublisherWebAPI.Models;
using PublisherWebAPI.Services;
using AutoMapper;

namespace PublisherWebAPI.Controllers
{
    [Route("api/genpublishers")]
    public class GenPublishersController : Controller
    {
        IGenericEFRepository _rep;

        public GenPublishersController(IGenericEFRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _rep.Get<Publisher>();
            var DTOs = Mapper.Map<IEnumerable<PublisherDTO>>(items);
            return Ok(DTOs);
        }

        [HttpGet("{id}", Name = "GetGenericPublisher")]
        public IActionResult Get(int id, bool includeRelatedEntities = false)
        {
            var item = _rep.Get<Publisher>(id, includeRelatedEntities);
            if (item == null) return NotFound();
            var DTO = Mapper.Map<PublisherDTO>(item);
            return Ok(DTO);

        }

        [HttpPost]
        public IActionResult Post([FromBody]PublisherDTO DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var itemToCreate = Mapper.Map<Publisher>(DTO);
            _rep.Add(itemToCreate);

            if (!_rep.Save()) return StatusCode(500,
                 "A problem occurred while handling your request.");

            var createdDTO = Mapper.Map<PublisherDTO>(itemToCreate);

            return CreatedAtRoute("GetGenericPublisher",
                new { id = createdDTO.Id }, createdDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PublisherUpdateDTO DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _rep.Get<Publisher>(id);

            if (entity == null) return NotFound();

            Mapper.Map(DTO, entity);

            if (!_rep.Save()) return StatusCode(500,
                "A problem occurred while handling your request.");

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
            [FromBody]JsonPatchDocument<PublisherUpdateDTO> DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _rep.Get<Publisher>(id);
            if (entity == null) return NotFound();

            var entityToPatch = Mapper.Map<PublisherUpdateDTO>(entity);
            DTO.ApplyTo(entityToPatch, ModelState);

            TryValidateModel(entityToPatch);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Mapper.Map(entityToPatch, entity);

            if (!_rep.Save()) return StatusCode(500,
                "A problem occurred while handling your request.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_rep.Exists<Publisher>(id)) return NotFound();

            var entityToDelete = _rep.Get<Publisher>(id);
            _rep.Delete(entityToDelete);

            if (!_rep.Save()) return StatusCode(500,
                "A problem occurred while handling your request.");

            return NoContent();
        }
    }
}
