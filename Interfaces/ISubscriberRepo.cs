using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Models;

namespace fractionalized.Interfaces
{
    public interface ISubscriberRepo
    {
        Task<Subscriber> CreateAsync(Subscriber subscriber);
        Task<Subscriber?> SubscriberAsync(int id);
        Task<List<Subscriber>> GetSubscribersAsync();
    }
}

// Task<List<Building>> GetBuildingsAsync();