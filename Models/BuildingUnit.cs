using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace fractionalized.Models
{
    public class BuildingUnit
    {
        public int Id { get; set; }

        public int? subscriberId { get; set; }
        public int? buildingId { get; set; }

        public Building? building { get; set; }
        public Subscriber? subscriber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal DividendsEarned { get; set; }
    }
}