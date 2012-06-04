using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Gojo.Core.Data.Generators
{
    public class CryptographicallyRandomIntegerGenerator
    {

        public static int GenerateCryptographicallyRandomPositiveInt32()
        {
            byte[] randomBytes = new byte[4];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            Int32 randomInt = BitConverter.ToInt32(randomBytes, 0);
            return Math.Abs(randomInt);
        }

        public static int GenerateCryptographicallyRandomPositiveInt32InRange(int min, int max)
        {
            byte[] randomBytes = new byte[4];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            Int32 randomInt = BitConverter.ToInt32(randomBytes, 0);
            return new Random(randomInt).Next(min, max);
        }

        public static ICollection<int> GetCryptographicallyRandomInt32NumberSet(int howManyInts)
        {
            List<int> set = new List<int>();

            for (int i = 0; i < howManyInts; i++)
            {
                var result = GenerateCryptographicallyRandomPositiveInt32();
                set.Add(result);
            }

            return set;
        }
        
        public static ICollection<int> GetCryptographicallyRandomInt32NumberSetInRange(int howManyInts, int min, int max)
        {
            // To do....
            throw new NotImplementedException();
        }


    }
}