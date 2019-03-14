using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace CryptoCore.Algoritmi
{
    public class RC4 : ICryptoAlgorithm
    {
        private byte[] key;
        private ulong counter;
        private uint[] box;
        private uint[] keystream;
        private byte[] IV;
        private uint num_rounds;

        public RC4()
        {
            num_rounds = 256;
            //key = new byte[8] { 156, 74, 250, 30, 64, 176, 99, 14 };
            counter = 0;
            box = new uint[256];
            keystream = new uint[256];
            //IV = new byte[8] { 22, 87, 102, 242, 42, 83, 15, 99 };
            //this.GenerateRandomProperties();
        }

        public RC4(byte[] key)
        {
            num_rounds = 256;
            counter = 0;
            box = new uint[256];
            keystream = new uint[256];

            this.key = key;
        }

        public RC4(byte[] key, byte[] IV)
        {
            num_rounds = 256;
            counter = 0;
            box = new uint[256];
            keystream = new uint[256];

            this.key = key;
            this.IV = IV;
        }

        public byte[] Crypt(byte[] input)
        {
            uint a, i, j, k, tmp;
            byte[] cipher;
            cipher = new byte[input.Length];

            for (i = 0; i < num_rounds; i++)
            {
                keystream[i] = key[i % key.Length];
                box[i] = i;
            }
            for (j = i = 0; i < num_rounds; i++)
            {
                j = (j + box[i] + keystream[i]) % num_rounds;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < input.Length; i++)
            {
                a++;
                a %= num_rounds;
                j += box[a];
                j %= num_rounds;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % num_rounds)];
                cipher[i] = (byte)(input[i] ^ k);
            }
            return cipher;
        }

        public byte[] Decrypt(byte[] output)
        {
            return Crypt(output);
        }

        public byte[] CryptWithCTR(byte[] input)
        {
            byte[] cipher = new byte[input.Length];
            byte[] mod;

            for (int i = 0; i < (input.Length / 8) * 8; i += 8)
            {
                mod = this.Crypt(this.ExclusiveOR(this.IV, BitConverter.GetBytes(this.counter)));
                for (int j = i; j < i + 8; j++)
                {
                    cipher[j] = (byte)(input[j] ^ mod[j % 8]);
                }

                if (counter == ulong.MaxValue)
                    counter = 0;
                else
                    counter++;
            }

            if (input.Length % 8 == 0)
            {
                counter = 0;
                return cipher;
            }
            else
            {
                mod = this.Crypt(this.ExclusiveOR(this.IV, BitConverter.GetBytes(this.counter)));
                for (int i = (input.Length / 8) * 8; i < input.Length; i++)
                {
                    cipher[i] = (byte)(input[i] ^ mod[i % 8]);
                }

                counter = 0;
                return cipher;
            }
        }

        public byte[] DecryptWithCTR(byte[] output)
        {
            return CryptWithCTR(output);
        }

        public void GenerateRandomProperties()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            this.key = new byte[8];
            this.IV = new byte[8];

            rng.GetBytes(this.key);
            rng.GetBytes(this.IV);          
        }

        public byte[] ExclusiveOR(byte[] array1, byte[] array2)
        {
            if (array1.Length == array2.Length)
            {
                byte[] result = new byte[array1.Length];

                for (int i = 0; i < array1.Length; i++)
                {
                    result[i] = (byte)(array1[i] ^ array2[i]);
                }
                return result;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
