﻿using plantdrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PlantdrationAPI.DAL
{
    public class UserPlantRepository
    {
        private PlantContext _context;

        public UserPlantRepository(PlantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPlant>> GetByID(int userId)
        {
            return await _context.UserPlants
                .Where(up => up.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserPlant> GetByUserIdAndPlantId(int userId, int plantId)
        {
            return await _context.UserPlants.FirstOrDefaultAsync(up => up.UserId == userId && up.PlantId == plantId);
        }

        public async Task Insert(UserPlant obj)
        {
            await _context.UserPlants.AddAsync(obj);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public UserPlant Update(UserPlant obj)
        {
            _context.UserPlants.Update(obj);
            return obj;
        }

        public void Delete(UserPlant obj)
        {
            _context.UserPlants.Remove(obj);
        }
    }
}
