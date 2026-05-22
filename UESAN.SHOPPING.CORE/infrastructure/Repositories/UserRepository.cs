using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.Entities;
using Microsoft.EntityFrameworkCore;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDBContext _context;

        public UserRepository(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<User> SignIn(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }

        public async Task<int> Sigup(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
