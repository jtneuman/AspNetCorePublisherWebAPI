using Microsoft.AspNetCore.Mvc;
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
    }
}
