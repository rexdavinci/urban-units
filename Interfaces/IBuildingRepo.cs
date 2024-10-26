using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.Building;
using fractionalized.Models;
// using fractionalized.Controllers;

namespace fractionalized.Interfaces
{
    public interface IBuildingRepo
    {
        Task<List<Building>> GetBuildingsAsync();
        Task<Building?> GetBuildingAsync(int id); // Might be null
        Task<Building> CreateAsync(Building buildingModel);
        Task<Building?> UpdateAsync(int id, UpdateBuildingDTO buildingDTO);
        Task<Building?> SellAsync(int id, int availableUnits, int soldUnits);
        Task<Building?> DeleteAsync(int id);
        Task<bool> BuildingExists(int id);
    }
}