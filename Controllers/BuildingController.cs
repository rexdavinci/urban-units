using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Mappings;
using fractionalized.DTOs.Building;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Controllers
{
    [Route("/api/building")]
    [ApiController]
    public class BuildingController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var buildings = await _context.Buildings.ToListAsync();
            var buildingDTO = buildings.Select(s => s.ToBuildingDTO());
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuilding([FromRoute] int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building.ToBuildingDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewBuildingDTO createBuildingDTO)
        {
            var buildingModel = createBuildingDTO.ToBuildingFromNewBuildingDTO();
            await _context.Buildings.AddAsync(buildingModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingModel.Id }, buildingModel.ToBuildingDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBuildingDTO updateBuildingDTO)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(x => x.Id == id);

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
            await _context.SaveChangesAsync ();
            return Ok(building.ToBuildingDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}