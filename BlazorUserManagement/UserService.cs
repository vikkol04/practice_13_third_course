using BlazorUserManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BlazorUserManagement
{
    public class UserService
    {
        private List<User> users = new List<User>()
        {
            new User { Id = 1, FirstName = "Іван", LastName = "Іванов", Email = "ivan.ivanov@example.com" },
            new User { Id = 2, FirstName = "Марія", LastName = "Петрова", Email = "mariya.petrova@example.com" }
        };

        private int nextId = 3;

        public async Task<List<User>> GetUsersAsync()
        {
            await Task.Delay(1000); // Затримка на 1 секунду
            return users;
        }

        public async Task AddUserAsync(User user)
        {
            user.Id = nextId++;
            users.Add(user);
            await Task.Delay(1000); // Затримка на 1 секунду
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
            }
            await Task.Delay(1000); // Затримка на 1 секунду
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userToDelete = users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
            }
            await Task.Delay(1000); // Затримка на 1 секунду
        }
    }
}