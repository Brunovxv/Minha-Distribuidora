using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;

namespace MinhaDistribuidora.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
