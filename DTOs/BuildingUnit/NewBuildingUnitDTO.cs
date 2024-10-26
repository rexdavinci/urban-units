using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.BuildingUnit
{
    public class NewBuildingUnitDTO
    {
        public int BuildingId { get; set; }
        public decimal DividendsEarned { get; set; }
        public int SubscriberId { get; set; }
    }
}