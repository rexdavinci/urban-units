using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.DTOs.BuildingUnit;
using fractionalized.Interfaces;
using fractionalized.Models;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Repository
{
    public class BuildingUnitRepo(ApplicationDBContext context) : IBuildingUnitRepo
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<BuildingUnit> CreateBuildingUnitAsync(BuildingUnit buildingUnitModel)
        {
            await _context.BuildingUnits.AddAsync(buildingUnitModel);
            await _context.SaveChangesAsync();
            return buildingUnitModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var buildingUnit = await _context.BuildingUnits.FirstOrDefaultAsync(b => b.Id == id);
            if (buildingUnit == null)
            {
                return false;
            }
            _context.BuildingUnits.Remove(buildingUnit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BuildingUnit?> GetBuildingUnitAsync(int id)
        {
            return await _context.BuildingUnits.FindAsync(id);
        }

        public async Task<List<BuildingUnit>> GetBuildingUnitsAsync()
        {
            return await _context.BuildingUnits.ToListAsync();

        }



        public async Task<bool> IsExists(int id)
        {
            return await _context.BuildingUnits.AnyAsync(b => b.Id == id);
        }

        public async Task<BuildingUnit?> UpdateAsync(int id, BuildingUnitUpdateDTO buildingDTO)
        {
            var buildingUnit = await _context.BuildingUnits.FirstOrDefaultAsync(b => b.Id == id);
            if (buildingUnit == null)
            {
                return null;
            }

            buildingUnit.DividendsEarned = buildingDTO.DividendsEarned;
            buildingUnit.Units += buildingDTO.Units;

            await _context.SaveChangesAsync();
            return buildingUnit;
        }
    }
}