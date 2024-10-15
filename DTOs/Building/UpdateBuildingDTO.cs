using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.Building
{
    public class UpdateBuildingDTO
    {
         public required string Title { get; set; }

        public string Description { get; set; }
        public string BuildingType { get; set; }
        public string Status { get; set; }

        public DateTime ExitDate { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public string Address { get; set; }
        public string DocumentsURL { get; set; }

        public DateTime LastValuedAt { get; set; }

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