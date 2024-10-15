using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Models;
// using fractionalized.Controllers;

namespace fractionalized.Interfaces
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetBuildingsAsync();
        // Task<Building> GetBuilding();
    }
}