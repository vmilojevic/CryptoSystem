using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCore
{
    interface ICryptoAlgorithm
    {
        void GenerateRandomProperties();
        byte[] Crypt(byte[] input);
        byte[] Decrypt(byte[] output);
    }
}
