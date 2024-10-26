using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.Building
{
    public class NewBuildingDTO
    {
        public required string Title { get; set; }

        public required string Description { get; set; }
        public required string BuildingType { get; set; }
        public required string Status { get; set; }

        public DateTime ExitDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public required string Address { get; set; }
        public required string DocumentsURL { get; set; }

        public DateTime? LastValuedAt { get; set; }

        public decimal Cost { get; set; }

        public decimal UnitCost { get; set; }

        public decimal DividendPerUnit { get; set; }
        public decimal CurrentValuation { get; set; }

        public int AvailableUnits { get; set; }

        public int SoldUnits { get; set; }

        public int MinimumPurchaseUnits { get; set; }
        public int MaximumPurchaseUnits { get; set; }
    }
}