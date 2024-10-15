using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Mappings;
using fractionalized.DTOs.Building;
using Microsoft.AspNetCore.Mvc;

namespace fractionalized.Controllers
{
    [Route("/api/building")]
    [ApiController]
    public class BuildingController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult Get()
        {
            var buildings = _context.Buildings.ToList().Select(s => s.ToBuildingDTO());
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBuilding([FromRoute] int id)
        {
            var building = _context.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building.ToBuildingDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewBuildingDTO createBuildingDTO)
        {
            var buildingModel = createBuildingDTO.ToBuildingFromNewBuildingDTO();
            _context.Buildings.Add(buildingModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingModel.Id }, buildingModel.ToBuildingDTO());
        }
    }
}