using PersonalBrand.Domain.Entities;

namespace Identity.API.Services.AuthService
{
    public interface IAuthService
    {
        public string GenerateToken(UserModel user);
    }
}
