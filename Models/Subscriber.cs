using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public List<BuildingUnit> BuildingUnits { get; set; } = new List<BuildingUnit>();
        public string Name { get; set; } = "";
        public int Balance { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}