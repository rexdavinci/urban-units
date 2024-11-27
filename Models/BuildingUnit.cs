using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace fractionalized.Models
{
    [Table("Comments")]
    public class BuildingUnit
    {
        public int Id { get; set; }

        public int SubscriberId { get; set; }
        public int BuildingId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int Units { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DividendsEarned { get; set; }
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<BuildingGroup> BuildingGroups { get; set; } = new List<BuildingGroup>();
    }
}