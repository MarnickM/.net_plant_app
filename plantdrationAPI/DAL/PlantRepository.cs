using plantdrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PlantdrationAPI.DAL
{
    public class PlantRepository : IRepository<Plant>
    {
        private PlantContext _context;

        public PlantRepository(PlantContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var plant = _context.Plants.Find(id);
            _context.Plants.Remove(plant);
        }

        public async Task<IEnumerable<Plant>> GetAll()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetByID(int id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public async Task<Plant> GetByName(string name)
        {
            return await _context.Plants.FirstOrDefaultAsync(p => p.tag.ToLower() == name.ToLower());
        }

        public async Task Insert(Plant obj)
        {
            await _context.Plants.AddAsync(obj);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Plant Update(Plant obj)
        {
            _context.Plants.Update(obj);
            return obj;
        }   
    }
}
