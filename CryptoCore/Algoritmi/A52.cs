using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace CryptoCore.Algoritmi
{
    public class A52 : ICryptoAlgorithm
    {
        #region Members
        private BitArray R1;
        private BitArray R2;
        private BitArray R3;
        private BitArray R4;       
        private BitArray Key;
        private BitArray f;
        private byte[] IV;
        private ulong counter;
        private Random rand;
        #endregion

        public A52()
        {
            R1 = new BitArray(19);
            R2 = new BitArray(22);
            R3 = new BitArray(23);
            R4 = new BitArray(17);
        
            //this.GenerateRandomProperties();

            counter = 0;
        }

        public void KeySetup()
        {
            R1.SetAll(false);
            R2.SetAll(false);
            R3.SetAll(false);
            R4.SetAll(false);

            for (int i = 0; i < 64; i++)
            {
                ClockRegisters();
                R1[0] = R1[0] ^ Key[i];
                R2[0] = R2[0] ^ Key[i];
                R3.Set(0, R3[0] ^ Key[i]);
                R4.Set(0, R4[0] ^ Key[i]);
            }
            for (int i = 0; i < 22; i++)
            {
                ClockRegisters();
                R1[0] = R1[0] ^ f[i];
                R2[0] = R2[0] ^ f[i];
                R3.Set(0, R3[0] ^ f[i]);
                R4.Set(0, R4[0] ^ f[i]);
            }

            R1.Set(15, true);
            R2.Set(16, true);
            R3.Set(18, true);
            R4.Set(10, true);
        }

        public void ClockRegisters()
        {
            RotateRight(R1);
            RotateRight(R2);
            RotateRight(R3);
            RotateRight(R4);
        }

        public void RotateRight(BitArray register)
        {
            bool pom = register[register.Length - 1];
            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }

            register[0] = pom;
        }

        public void Cycle()
        {
            bool majorityR4 = Majority(R4.Get(3), R4.Get(7), R4.Get(10));
            bool r0;

            if (R4.Get(10) == majorityR4)
            {
                RotateRight(R1);
                r0 = R1.Get(18) ^ R1.Get(17) ^ R1.Get(16) ^ R1.Get(13);
                R1.Set(0, r0);
            }
            if (R4.Get(3) == majorityR4)
            {
                RotateRight(R2);
                r0 = R2.Get(21) ^ R2.Get(20);
                R2.Set(0, r0);
            }
            if (R4.Get(7) == majorityR4)
            {
                RotateRight(R3);
                r0 = R3.Get(22) ^ R3.Get(21) ^ R3.Get(20) ^ R3.Get(7);
                R3.Set(0, r0);
            }

            RotateRight(R4);
            r0 = R4.Get(16) ^ R4.Get(11);
            R4.Set(0, r0);
        }

        public bool Majority(bool b1, bool b2, bool b3)
        {
            return (b1 & b2) ^ (b2 & b3) ^ (b3 & b1);            
        }

        public bool GenerateOutputBit()
        {
            bool output;
            bool majorityR1 = Majority(R1.Get(15), R1.Get(14) ^ true, R1.Get(12));
            bool majorityR2 = Majority(R2.Get(16) ^ true, R2.Get(13), R2.Get(9));
            bool majorityR3 = Majority(R3.Get(18), R3.Get(16), R3.Get(13) ^ true);

            output = majorityR1 ^ R1.Get(R1.Length - 1) ^ majorityR2 ^ R2.Get(R2.Length - 1) ^ majorityR3 ^ R3.Get(R3.Length - 1);
            return output;
        }

        public byte[] ToByteArray(BitArray bits)
        {
            const int BYTE = 8;
            int length = (bits.Count / BYTE) + ((bits.Count % BYTE == 0) ? 0 : 1);
            var bytes = new byte[length];

            for (int i = 0; i < bits.Length; i++)
            {

                int bitIndex = i % BYTE;
                int byteIndex = i / BYTE;

                int mask = (bits[i] ? 1 : 0) << bitIndex;
                bytes[byteIndex] |= (byte)mask;

            }

            return bytes;
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

        public byte[] Crypt(byte[] input)
        {
            BitArray inputBits = new BitArray(input);
            BitArray outputBits = new BitArray(inputBits.Length);
            KeySetup();

            bool outputBit;
            bool result;
            for (int i = 0; i < inputBits.Length; i++)
            {
                Cycle();
                outputBit = GenerateOutputBit();
                result = outputBit ^ inputBits.Get(i);
                outputBits.Set(i, result);
            }
            return ToByteArray(outputBits);
        }

        public byte[] Decrypt(byte[] output)
        {
            return Crypt(output);
        }

        public void GenerateRandomProperties()
        {
            this.rand = new Random();

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            this.IV = new byte[8];
            rng.GetBytes(IV);

            byte[] key = new byte[8];
            rng.GetBytes(key);
            this.Key = new BitArray(key);

            this.f = new BitArray(22);
            for (int i = 0; i < f.Length; i++)
            {
                if (rand.NextDouble() <= 0.5)
                    f[i] = false;
                else
                    f[i] = true;
            }           
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

        public void SetKey(byte[] key)
        {
            this.Key = new BitArray(key);
        }

        public void SetIV(byte[] iv)
        {
            this.IV = iv;
        }

        public void SetF(string bitString)
        {
            this.f = new BitArray(22);
            for (int i = 0; i < this.f.Length; i++)
            {
                if (bitString[i] == '1')
                    this.f[i] = true;
                else
                    this.f[i] = false;
            }
        }
    }
}
