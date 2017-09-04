using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PublisherWebAPI.Models;

namespace PublisherWebAPI.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        public IActionResult Get()
        {
            var model = new Message { Id = 1, Text = "Message, from the Get Action." };
            return Ok(model);
        }
    }
}
