using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[]passwordHash,out byte[]passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[]passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computed.Length; i++)
                {
                    if (computed[i]!=passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
