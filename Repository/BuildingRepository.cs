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
    public class BuildingRepository(ApplicationDBContext context) : IBuildingRepository
    {
        private readonly ApplicationDBContext _context = context;

        // public Task<Building> GetBuilding()
        // {
        //     // throw new NotImplementedException();
        //     return _context.Buildings.ToBuildingDTO();
        // }

        public Task<List<Building>> GetBuildingsAsync()
        {
            // throw new NotImplementedException();
            return _context.Buildings.ToListAsync();
        }
    }

}
