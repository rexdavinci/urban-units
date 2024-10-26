using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.BuildingUnit;
using fractionalized.Models;

namespace fractionalized.Interfaces
{
    public interface IBuildingUnitRepo
    {
        Task<List<BuildingUnit>> GetBuildingUnitsAsync();
        Task<BuildingUnit?> GetBuildingUnitAsync(int id);

        Task<BuildingUnit> CreateBuildingUnitAsync(BuildingUnit buildingUnitModel);

        Task<bool> IsExists(int id);

        Task<BuildingUnit?> UpdateAsync(int id, BuildingUnitUpdateDTO buildingDTO);

        Task<bool> DeleteAsync(int id);
    }
}