using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Interfaces;
using fractionalized.Models;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Repository
{
    public class BuildingUnitRepo(ApplicationDBContext context) : IBuildingUnitRepo
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<BuildingUnit?> GetBuildingUnitAsync(int id)
        {
            return await _context.BuildingUnits.FindAsync(id);
        }

        public async Task<List<BuildingUnit>> GetBuildingUnitsAsync()
        {
           return await _context.BuildingUnits.ToListAsync();

        }
    }
}