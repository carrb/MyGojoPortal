using System.Collections.Generic;

namespace Gojo.Core.Data.Generators
{
    public interface ICryptographicallyRandomIntegerGenerator
    {
        int GetCryptographicallyRandomInt32Number();
        IList<int> GetCryptographicallyRandomInt32NumberSet(int howManyInts);
    }
}
