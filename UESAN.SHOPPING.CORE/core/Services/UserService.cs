using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> SignIn(string email, string password)
        {
            var user = await _userRepository.SignIn(email, password);
            var token = "";
            if (user == null) return null;
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = "token"
            };
        }

        public async Task<int> Signup(UserCreateDTO userCreateDTO)
        {
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                DateOfBirth = userCreateDTO.DateOfBirth,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password,
                Country = userCreateDTO.Country,
                Address = userCreateDTO.Address,
                Type = userCreateDTO.Type,
                IsActive = true
            };
            return await _userRepository.Sigup(user);
        }
    }
}
