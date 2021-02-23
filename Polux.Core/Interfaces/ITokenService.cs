using Polux.Core.Entities.Identity;

namespace Polux.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
