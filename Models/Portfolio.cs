using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public string SubscriberId { get; set; }
        public int BuildingUnitId { get; set; }
        public Subscriber Subscriber { get; set; }
        public BuildingUnit BuildingUnit { get; set; }
    }
}