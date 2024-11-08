using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Interfaces;
using fractionalized.DTOs.Subscriber;
using fractionalized.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using fractionalized.Models;


// [Route("api/subscribers")]
// [ApiController]
// public class Subscriber(UserManager<Subscriber> userManager) : ControllerBase
// {
//     private readonly UserManager<Subscriber> _userManager = userManager ;

//     [HttpPost("register")]
//     public async Task<IActionResult> Register([FromBody])

// }

namespace fractionalized.Controllers
{
    [Route("api/subscribers")]
    [ApiController]
    public class SubscriberController(UserManager<Subscriber> userManager) : ControllerBase
    {
        private readonly UserManager<Subscriber> _userManager = userManager;

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterDTO registerUserDTO)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newSubscriber = new Subscriber
                {
                    UserName = registerUserDTO.UserName,
                    Name = registerUserDTO.Name,
                    // Email = registerUserDTO.Email,
                    CreatedAt = DateTime.Now,
                };

                var createdSubscriber = await _userManager.CreateAsync(newSubscriber, registerUserDTO.Password);

                if (createdSubscriber.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(newSubscriber, "USER"); // make new user have `USER` role
                    if (roleResult.Succeeded)
                    {
                        return Ok("Subscriber Registered");
                    } 
                    return StatusCode(500, roleResult.Errors);
                }
                return StatusCode(500, createdSubscriber.Errors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subscriber = registerUserDTO.ToRegisterDTO();
            // await _subscriberRepo.CreateAsync(subscriber);
            return Ok(subscriber);

            // return CreatedAtAction(nameof(GetBuilding), new { id = subscriber.Id }, buildingModel.ToBuildingDTO());
        }

    }
}