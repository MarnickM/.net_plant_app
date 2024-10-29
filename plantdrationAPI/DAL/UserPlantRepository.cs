using plantdrationAPI.Models;
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
    }
}
