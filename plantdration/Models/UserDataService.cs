using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserDataService
    {
        public async static Task<List<User>> GetUsersAsync()
        {
            return await ApiService<List<User>>.GetAsync("users");
        }
        public async static Task InsertUserAsync(User user)
        {
            await ApiService<User>.PostAsync("users", user);
        }

        public async static Task UpdateUserAsync(User user)
        {
            await ApiService<User>.PutAsync($"users/{user.Id}", user);
        }

        public async static Task DeleteUserAsync(int id)
        {
            await ApiService<User>.DeleteAsync($"users/{id}");
        }
    }
}
