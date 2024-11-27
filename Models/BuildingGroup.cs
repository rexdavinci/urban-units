using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.Models
{
    [Table("BuildingGroups")]
    public class BuildingGroup
    {
        public string BuildingUnitId { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public BuildingUnit BuildingUnit { get; set; }
    }
}