using plantdrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PlantdrationAPI.DAL
{
    public class UserRepository : IRepository<User>
    {
        private PlantContext _context;

        public UserRepository(PlantContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByID(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToLower());
        }

        public async Task Insert(User obj)
        {
            await _context.Users.AddAsync(obj);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public User Update(User obj)
        {
            _context.Users.Update(obj);
            return obj;
        }

    }
}
