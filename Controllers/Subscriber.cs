using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Interfaces;
using fractionalized.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace fractionalized.Controllers
{
    [Route("api/subscribers")]
    [ApiController]
    public class Subscriber(ISubscriberRepo subscriberRepo) : ControllerBase
    {
        private readonly ISubscriberRepo _subscriberRepo = subscriberRepo;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subscribers = await _subscriberRepo.GetSubscribersAsync();
            return Ok(subscribers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriber([FromRoute] int id)
        {
            var subscriber = await _subscriberRepo.SubscriberAsync(id);
            // subscriber
            if(subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber.ToSubscriberDTO());
        }
    }
}