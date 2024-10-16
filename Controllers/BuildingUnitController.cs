using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Interfaces;
using fractionalized.Mappings;
using fractionalized.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fractionalized.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class BuildingUnitController(IBuildingUnitRepo buildingUnitRepo) : ControllerBase
    {
        // private readonly ApplicationDBContext _context = context;
        private readonly IBuildingUnitRepo _buildingUnitRepo = buildingUnitRepo;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var buildingUnits = await _buildingUnitRepo.GetBuildingUnitsAsync();
            var buildingUnitsDTO = buildingUnits.Select(bu => bu.ToBuildingUnitDTO());
            return Ok(buildingUnitsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildingUnit([FromRoute] int id)
        {
            var buildingUnit = await _buildingUnitRepo.GetBuildingUnitAsync(id);
            if (buildingUnit == null)
            {
                return NotFound();
            }
            return Ok(buildingUnit.ToBuildingUnitDTO());
        }
    }
}