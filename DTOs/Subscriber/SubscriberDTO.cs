using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.BuildingUnit;

namespace fractionalized.DTOs.Subscriber
{
    public class SubscriberDTO
    {
        public int Id { get; set; }


        public string Username { get; set; }
        public List<BuildingUnitDTO> BuildingUnits { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Spent { get; set; }
        public string CryptoAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
