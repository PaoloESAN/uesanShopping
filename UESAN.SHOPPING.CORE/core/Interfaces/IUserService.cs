using UESAN.SHOPPING.CORE.core.DTOs;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> SignIn(string email, string password);
        Task<int> Signup(UserCreateDTO userCreateDTO);
    }
}
