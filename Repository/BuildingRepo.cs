using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.DTOs.Building;
using fractionalized.Interfaces;
using fractionalized.Models;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Repository
{
    public class BuildingRepo(ApplicationDBContext context) : IBuildingRepo
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<bool> BuildingExists(int id)
        {
            return await _context.Buildings.AnyAsync(b => b.Id == id);
        }

        public async Task<Building> CreateAsync(Building buildingModel)
        {
            await _context.Buildings.AddAsync(buildingModel);
            await _context.SaveChangesAsync();
            return buildingModel;
        }

        public async Task<Building?> DeleteAsync(int id)
        {
            var buildingModel = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (buildingModel == null)
            {
                return null;
            }
            _context.Buildings.Remove(buildingModel);
            await _context.SaveChangesAsync();
            return buildingModel;

        }

        public async Task<Building?> GetBuildingAsync(int id)
        {
            // throw new NotImplementedException();
            // var building = await _context.Buildings.FindAsync(id); // Include won't work with this
            var building = await _context.Buildings.Include(b => b.BuildingUnits).FirstOrDefaultAsync(b => b.Id == id);
            return building;
        }

        public Task<List<Building>> GetBuildingsAsync()
        {
            // throw new NotImplementedException();
            return _context.Buildings.Include(b => b.BuildingUnits).ToListAsync();
        }

        public async Task<Building?> UpdateAsync(int id, UpdateBuildingDTO updateBuildingDTO)
        {
            // throw new NotImplementedException();
            var prevBuilding = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (prevBuilding == null)
            {
                return null;
            }
            prevBuilding.SoldUnits = updateBuildingDTO.SoldUnits;
            prevBuilding.Address = updateBuildingDTO.Address;
            prevBuilding.BuildingType = updateBuildingDTO.BuildingType;
            prevBuilding.Description = updateBuildingDTO.Description;
            prevBuilding.CurrentValuation = updateBuildingDTO.CurrentValuation;
            prevBuilding.DocumentsURL = updateBuildingDTO.DocumentsURL;
            prevBuilding.SoldUnits = updateBuildingDTO.SoldUnits;
            prevBuilding.AvailableUnits = updateBuildingDTO.AvailableUnits;

            await _context.SaveChangesAsync();
            return prevBuilding;

        }
        public async Task<Building?> SellAsync(int id, int availableUnits, int soldUnits)
        {
            // throw new NotImplementedException();
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (building == null)
            {
                return null;
            }
            building.SoldUnits = soldUnits;
            building.AvailableUnits = availableUnits;

            await _context.SaveChangesAsync();
            return building;

        }
    }
}