using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Wissance.Pacman.WebAPI.Utils.Hash
{
    public static class Sha256Hasher
    {
        public static string HashToHexStr(StringValues stringValues)
        {
            if (stringValues.Count == 0)
            {
                return string.Empty;
            }

            // Initialize an incremental SHA256 accumulator
            using IncrementalHash incrementalHash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
    
            for (int i = 0; i < stringValues.Count; i++)
            {
                string? currentStr = stringValues[i];
                if (!string.IsNullOrEmpty(currentStr))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(currentStr);
                    incrementalHash.AppendData(bytes);
                }

                // Mimic StringValues default string comma behavior between multiple items
                if (i < stringValues.Count - 1)
                {
                    incrementalHash.AppendData(Encoding.UTF8.GetBytes(","));
                }
            }

            byte[] hashBytes = incrementalHash.GetHashAndReset();
            return Convert.ToHexString(hashBytes);
        }
    }
}