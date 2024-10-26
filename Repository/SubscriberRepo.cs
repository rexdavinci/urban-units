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
        async public Task<Subscriber> CreateAsync(Subscriber subscriber)
        {
            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
            return subscriber;

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