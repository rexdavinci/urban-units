using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.Building;
using fractionalized.Models;

namespace fractionalized.Mappings
{
    public static class BuildingMapper
    {
        public static BuildingDTO ToBuildingDTO(this Building building)
        {
            return new BuildingDTO
            {
                Id = building.Id,
                Title = building.Title,
                Description = building.Description,
                BuildingType = building.BuildingType,
                Status = building.Status,
                ExitDate = building.ExitDate,
                Address = building.Address,
                Cost = building.Cost,
                SubscribersCount = building.SubscribersCount,
                AvailableUnits = building.AvailableUnits,
                SoldUnits = building.SoldUnits,
                DividendPerUnit = building.DividendPerUnit,
                UnitCost = building.UnitCost,
                MinimumPurchaseUnits = building.MinimumPurchaseUnits,
                MaximumPurchaseUnits = building.MaximumPurchaseUnits,
                LastValuedAt = building.LastValuedAt,
                CurrentValuation = building.CurrentValuation,
                DocumentsURL = building.DocumentsURL,
            };
        }

        public static Building ToBuildingFromNewBuildingDTO(this NewBuildingDTO buildingDTO)
        {
            return new Building
            {
                Title = buildingDTO.Title,
                Description = buildingDTO.Description,
                BuildingType = buildingDTO.BuildingType,
                Status = buildingDTO.Status,
                ExitDate = buildingDTO.ExitDate,
                Address = buildingDTO.Address,
                Cost = buildingDTO.Cost,
                AvailableUnits = buildingDTO.AvailableUnits,
                DividendPerUnit = buildingDTO.DividendPerUnit,
                UnitCost = buildingDTO.UnitCost,
                MinimumPurchaseUnits = buildingDTO.MinimumPurchaseUnits,
                MaximumPurchaseUnits = buildingDTO.MaximumPurchaseUnits,
                LastValuedAt = buildingDTO.LastValuedAt,
                CurrentValuation = buildingDTO.CurrentValuation,
                DocumentsURL = buildingDTO.DocumentsURL,
            };
        }
    }
}
