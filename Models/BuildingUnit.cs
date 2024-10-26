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

        public int SubscriberId { get; set; }
        public int BuildingId { get; set; }

        public Building? Building { get; set; }
        public Subscriber? Subscriber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int Units { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DividendsEarned { get; set; }
    }
}