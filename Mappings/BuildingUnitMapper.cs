using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.BuildingUnit;
using fractionalized.Models;

namespace fractionalized.Mappings
{
    public static class BuildingUnitMapper
    {
        public static BuildingUnitDTO ToBuildingUnitDTO(this BuildingUnit buildingModel)
        {
            return new BuildingUnitDTO
            {
                
                Id = buildingModel.Id,
                DividendsEarned = buildingModel.DividendsEarned,
                CreatedAt = buildingModel.CreatedAt,
                BuildingId = buildingModel.BuildingId,
                SubscriberId = buildingModel.SubscriberId,
                
            };
        }
    }
}

        // public int? subscriberId { get; set; }
        // public int? buildingId { get; set; }

        // // public Building? building { get; set; }
        // // public Subscriber? subscriber { get; set; } // No NAVIGATION PROPERTY

        // public DateTime CreatedAt { get; set; } = DateTime.Now;

        // public decimal DividendsEarned { get; set; }