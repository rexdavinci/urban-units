using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace fractionalized.Models
{
    public class Subscriber: IdentityUser
    {
        public List<BuildingUnit> BuildingUnits { get; set; } = new List<BuildingUnit>();
        public string Name { get; set; } = "";
        public int Balance { get; set; }
        public int Spent { get; set; } = 0;
        public string CryptoAddress { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}