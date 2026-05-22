using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Settings;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}