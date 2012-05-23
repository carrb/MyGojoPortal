using System;
using System.Security.Cryptography;

namespace Gojo.Core.Data.Generators
{
    public class EntityRandomIdGenerator
    {
        private const int _min = 1;
        private const int _max = 999999;

        public EntityRandomIdGenerator()
        {
                      
        }

        public static int GetRandomId()
        {
            Random random = new Random();
            return random.Next(_min, _max);
        }

        public static int GenerateCryptographicallyRandomInt32()
        {
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            Int32 randomInt = BitConverter.ToInt32(randomBytes, 0);
            return randomInt;
        }
    }
}
