using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.DTOs.Building;
using fractionalized.DTOs.BuildingUnit;
using fractionalized.Interfaces;
using fractionalized.Mappings;
using fractionalized.Models;
using fractionalized.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fractionalized.Controllers
{
    [Route("api/building/units")]
    [ApiController]
    public class BuildingUnitController(IBuildingUnitRepo buildingUnitRepo, IBuildingRepo buildingRepo) : ControllerBase
    {
        private readonly IBuildingUnitRepo _buildingUnitRepo = buildingUnitRepo;
        private readonly IBuildingRepo _buildingRepo = buildingRepo;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var buildingUnits = await _buildingUnitRepo.GetBuildingUnitsAsync();
            var buildingUnitsDTO = buildingUnits.Select(bu => bu.ToBuildingUnitDTO());
            return Ok(buildingUnitsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBuildingUnit([FromRoute] int id)
        {
            var buildingUnit = await _buildingUnitRepo.GetBuildingUnitAsync(id);
            if (buildingUnit == null)
            {
                return NotFound();
            }
            return Ok(buildingUnit.ToBuildingUnitDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewBuildingUnitDTO newBuildingUnit)
        {
            if (!await _buildingRepo.BuildingExists(newBuildingUnit.BuildingId))
            {
                return BadRequest("Building Does Not Exist");
            }
            var buildingUnitModel = newBuildingUnit.ToBuildingUnitFromCreateDTO();
            await _buildingUnitRepo.CreateBuildingUnitAsync(buildingUnitModel);
            return CreatedAtAction(nameof(GetBuildingUnit), new { id = buildingUnitModel.Id }, buildingUnitModel.ToBuildingUnitDTO());
        }

        [HttpPut("{id:int}")]
        // [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BuildingUnitUpdateDTO buildingUnitUpdateDTO)
        {
            
            var buildingUnitModel = await _buildingUnitRepo.GetBuildingUnitAsync(id);

            if(buildingUnitModel == null)

            {
                return NotFound();
            }
        
            var buildingModel = await _buildingRepo.GetBuildingAsync(buildingUnitModel.BuildingId);
            if (buildingModel == null)
            {
                return NotFound();
            }
            int newAvailable = buildingModel.AvailableUnits - buildingUnitUpdateDTO.Units;
            int soldUnits = buildingModel.SoldUnits + buildingUnitUpdateDTO.Units;
            if(newAvailable < 0)
            {
                return BadRequest();
            }
            var buildingUnit = await _buildingUnitRepo.UpdateAsync(id, buildingUnitUpdateDTO);
            if (buildingUnit == null)
            {
                return NotFound();
            }
            await _buildingRepo.SellAsync(buildingUnit.BuildingId, newAvailable, soldUnits);
            return Ok(buildingUnit.ToBuildingUnitDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool done = await _buildingUnitRepo.DeleteAsync(id);
            if (!done)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}