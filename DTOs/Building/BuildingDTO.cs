using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.BuildingUnit;

namespace fractionalized.DTOs.Building
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string BuildingType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime? ExitDate { get; set; }

        public string Address { get; set; } = string.Empty;
        public string DocumentsURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastValuedAt { get; set; }

        public decimal Cost { get; set; }

        public decimal UnitCost { get; set; }

        public decimal DividendPerUnit { get; set; }
        public decimal CurrentValuation { get; set; } = 0;

        public int SubscribersCount { get; set; } = 0;

        public int AvailableUnits { get; set; } = 0;

        public int SoldUnits { get; set; } = 0;

        public int MinimumPurchaseUnits { get; set; } = 0;
        public int MaximumPurchaseUnits { get; set; } = 0;

        public List<BuildingUnitDTO> BuildingUnits { get; set; } = [];
    }
}