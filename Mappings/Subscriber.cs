using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.DTOs.Subscriber;
using fractionalized.Models;

namespace fractionalized.Mappings
{
    public static class SubscriberMapper
    {

        public static Subscriber ToRegisterDTO(this RegisterDTO signupDTO)
        {
            return new Subscriber
            {
                // Password = signupDTO.Password,
                Name = signupDTO.Name,
                // Username = signupDTO.Username,
                CryptoAddress = signupDTO.CryptoAddress,
            };
        }

        public static SubscriberDTO ToSubscriberDTO(this Subscriber subscriber)
        {
            return new SubscriberDTO
            {
                // Id = subscriber.Id,
                Name = subscriber.Name,
                // Username = subscriber.Username,
                CryptoAddress = subscriber.CryptoAddress,
                Balance = subscriber.Balance,
                Spent = subscriber.Spent,
                BuildingUnits = subscriber.BuildingUnits.Select(bu => bu.ToBuildingUnitDTO()).ToList(),
            };
        }
    }
}