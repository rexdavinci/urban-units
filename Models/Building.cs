using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace fractionalized.Models
{
    [Table("Buildings")]
    public class Building
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string BuildingType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime? ExitDate { get; set; }

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DividendPerUnit { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValuation { get; set; } = 0;
        public DateTime? LastValuedAt { get; set; }

        public int SubscribersCount { get; set; } = 0;

        public int AvailableUnits { get; set; } = 0;

        public int SoldUnits { get; set; } = 0;

        public int MinimumPurchaseUnits { get; set; } = 0;
        public int MaximumPurchaseUnits { get; set; } = 0;
        public string DocumentsURL { get; set; } = string.Empty;

        public List<BuildingUnit> BuildingUnits { get; set; } = new List<BuildingUnit>();
        public List<BuildingGroup> BuildingGroups { get; set; } = new List<BuildingGroup>();
    }
}