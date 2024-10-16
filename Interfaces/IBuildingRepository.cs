using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.Building;
using fractionalized.Models;
// using fractionalized.Controllers;

namespace fractionalized.Interfaces
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetBuildingsAsync();
        Task<Building?> GetBuildingAsync(int id); // Might be null
        Task<Building> CreateAsync(Building buildingModel);
        Task<Building?> UpdateAsync(int id, UpdateBuildingDTO buildingDTO);
        Task<Building?> DeleteAsync(int id);
    }
}