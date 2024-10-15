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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBuildingDTO updateBuildingDTO)
        {
            var building = _context.Buildings.FirstOrDefault(x => x.Id == id);

            if (building == null)
            {
                return NotFound();
            }
            building.SoldUnits = updateBuildingDTO.SoldUnits;
            building.Address = updateBuildingDTO.Address;
            building.BuildingType = updateBuildingDTO.BuildingType;
            building.Description = updateBuildingDTO.Description;
            building.CurrentValuation = updateBuildingDTO.CurrentValuation;
            building.DocumentsURL = updateBuildingDTO.DocumentsURL;
            building.SoldUnits = updateBuildingDTO.SoldUnits;
            building.AvailableUnits = updateBuildingDTO.AvailableUnits;
            _context.SaveChanges();
            return Ok(building.ToBuildingDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var building = _context.Buildings.FirstOrDefault(b => b.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            _context.Buildings.Remove(building);
            _context.SaveChanges();
            return NoContent();

        }
    }
}