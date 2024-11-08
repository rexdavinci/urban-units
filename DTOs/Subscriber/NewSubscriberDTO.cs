using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.Subscriber
{
    public class NewSubscriberDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}