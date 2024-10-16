using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Data;
using fractionalized.Interfaces;
using fractionalized.Models;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Repository
{
    public class SubscriberRepo(ApplicationDBContext context) : ISubscriberRepo
    {
        public readonly ApplicationDBContext _context = context;
        public Task<Subscriber> CreateAsync(Subscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subscriber>> GetSubscribersAsync()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<Subscriber?> SubscriberAsync(int id)
        {
            // var building = await _context.Buildings.Include(bu => bu.BuildingUnits).FirstOrDefaultAsync(b => b.Id == id);
            // return building;
            // return _context.Buildings.Include(bu => bu.BuildingUnits).ToListAsync();
            var subscriber = await _context.Subscribers.Include(b => b.BuildingUnits).FirstOrDefaultAsync(b => b.Id == id);
            return subscriber;
        }
    }
}