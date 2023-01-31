using MinhaDistribuidora.Data;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;
using System.Security.Cryptography;
using System.Text;

namespace MinhaDistribuidora.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }
        public User? ValidateCredentials(UserVO user)
        {
            var pass = ComputerHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u =>
                                 (u.UserName == user.UserName) && (u.Password == pass));
        }
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;
           
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }
        private string ComputerHash(string input, HashAlgorithm hashAlgorithm)
        {
            Byte[] hashedBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            foreach (var item in hashedBytes)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
