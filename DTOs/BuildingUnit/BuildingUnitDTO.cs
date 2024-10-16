using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.BuildingUnit
{
    public class BuildingUnitDTO
    {
        public int Id { get; set; }
        public int? SubscriberId { get; set; }
        public int? BuildingId { get; set; }

        // public Building? building { get; set; }
        // public Subscriber? subscriber { get; set; } // No NAVIGATION PROPERTY

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal DividendsEarned { get; set; }
    }
}