using SF.Services.Interfaces.CustomExceptions;
using System.Text;

namespace SF.Services.Helpers
{
    public static class PasswordHashHelper
    {
        private static readonly int _expectedHashLength = 64;
        private static readonly int _expectedSaltLength = 128;

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new BadArgumentException("Password cannot be null or whitespace.");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new BadArgumentException("Password cannot be null or whitespace.");
            }

            if (storedHash.Length != _expectedHashLength)
            {
                throw new BadArgumentException("Invalid lenght of password hash.");
            }

            if (storedSalt.Length != _expectedSaltLength)
            {
                throw new BadArgumentException("Invalid lenght of password sailt.");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
