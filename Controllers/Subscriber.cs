using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Interfaces;
using fractionalized.DTOs.Subscriber;
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
            if(subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber.ToSubscriberDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDTO registerUserDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subscriber = registerUserDTO.ToRegisterDTO();
            await _subscriberRepo.CreateAsync(subscriber);
            return Ok(subscriber);

            // return CreatedAtAction(nameof(GetBuilding), new { id = subscriber.Id }, buildingModel.ToBuildingDTO());
        }

    }
}