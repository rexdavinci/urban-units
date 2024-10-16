using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Mappings;
using fractionalized.DTOs.Building;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fractionalized.Interfaces;

namespace fractionalized.Controllers
{
    [Route("/api/building")]
    [ApiController]
    public class BuildingController(IBuildingRepo buildingRepo) : ControllerBase
    {
        // private readonly ApplicationDBContext _context = context;
        private readonly IBuildingRepo _buildingRepo = buildingRepo;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var buildings = await _buildingRepo.GetBuildingsAsync();
            var buildingDTO = buildings.Select(s => s.ToBuildingDTO());
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuilding([FromRoute] int id)
        {
            var building = await _buildingRepo.GetBuildingAsync(id);
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
            await _buildingRepo.CreateAsync(buildingModel);
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingModel.Id }, buildingModel.ToBuildingDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBuildingDTO updateBuildingDTO)
        {
            var building = await _buildingRepo.UpdateAsync(id, updateBuildingDTO);

            if (building == null)
            {
                return NotFound();
            }
            return Ok(building.ToBuildingDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var building = await _buildingRepo.DeleteAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}