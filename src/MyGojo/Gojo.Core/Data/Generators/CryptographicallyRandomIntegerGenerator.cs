using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Gojo.Core.Data.Generators
{
    public class CryptographicallyRandomIntegerGenerator :  ICryptographicallyRandomIntegerGenerator
    {
        public static int GetCryptographicallyRandomInt32Number()
        {
            return GenerateCryptographicallyRandomPositiveInt32();
        }

        int ICryptographicallyRandomIntegerGenerator.GetCryptographicallyRandomInt32Number()
        {
            return GetCryptographicallyRandomInt32Number();
        }

        public IList<int> GetCryptographicallyRandomInt32NumberSet(int howManyInts)
        {
            List<int> set = new List<int>();

            for (int i = 0; i < howManyInts; i++)
            {
                var result = GenerateCryptographicallyRandomPositiveInt32();
                set.Add(result);
            }

            return set;
        }


        private static int GenerateCryptographicallyRandomPositiveInt32()
        {
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            Int32 randomInt = BitConverter.ToInt32(randomBytes, 0);
            return Math.Abs(randomInt);
        }
    }
}