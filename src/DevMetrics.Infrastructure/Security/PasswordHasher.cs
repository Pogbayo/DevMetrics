using System.Security.Cryptography;


namespace DevMetrics.Infrastructure.Security
{
    public static class PasswordHasher
    {
        //  How many times the hashing algorithm runs.
        // Higher number = harder for hackers to brute-force.
        // 100,000 is considered secure and modern.
        private const int Iterations = 100_000;

        //  Salt size in bytes.
        // Salt is random data added to the password before hashing.
        // This prevents rainbow table attacks.
        private const int SaltSize = 16;

        //  Final hash size in bytes.
        // 32 bytes = 256 bits.
        private const int KeySize = 32;

        public static string HashPassword(string password)
        {
            //  Generate a random salt
            // This creates 16 random bytes using a secure random generator.
            // Every password gets a different salt.
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            //  Create PBKDF2 hashing object
            // PBKDF2 repeatedly hashes the password many times (Iterations)
            // It combines:
            // - The password
            // - The random salt
            // - The iteration count
            // - SHA256 algorithm
            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,              // The user's plain password
                salt,                  // Random salt
                Iterations,            // How many times to hash
                HashAlgorithmName.SHA256 // Hashing algorithm
            );

            // Generate the final hash bytes
            byte[] hash = pbkdf2.GetBytes(KeySize);

            //  Combine salt + hash into one byte array
            // We store them together because we need the salt later for verification.
            byte[] hashBytes = new byte[SaltSize + KeySize];

            // Copy salt into first part
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);

            // Copy hash into second part
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            //  Convert to Base64 string for storage in database
            // Databases store strings easily.
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            // Convert stored Base64 string back to bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            //  Extract the salt from the stored value
            // The first 16 bytes are the salt (because we saved it that way)
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            //  Recreate PBKDF2 using the extracted salt
            // This ensures we hash the incoming password the exact same way
            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256
            );

            //  Generate hash from the incoming password
            byte[] computedHash = pbkdf2.GetBytes(KeySize);

            //  Compare stored hash with newly computed hash
            // If they match, password is correct.
            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != computedHash[i])
                    return false;
            }

            return true;
        }
    }
}
