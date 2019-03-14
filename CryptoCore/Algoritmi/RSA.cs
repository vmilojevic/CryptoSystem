using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;

namespace CryptoCore.Algoritmi
{
    public class RSA : ICryptoAlgorithm
    {
        #region Members

        public BigInteger P { get; set; }
        public BigInteger Q { get; set; }
        public BigInteger N { get; set; }
        public BigInteger Phi { get; set; }
        public BigInteger E { get; set; }
        public BigInteger D { get; set; }
        public int blokM;
        public int blokC;

        #endregion

        public RSA()
        {
            //this.GenerateRandomProperties();
            //this.GenerateRSA();
        }

        // Test prostih brojeva
        public bool MillerRabinTest(BigInteger number, int k)
        {
            if (number == 2 || number == 3)
                return true;
            if (number < 2 || number % 2 == 0)
                return false;

            BigInteger d = number - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            // k predstavlja preciznost sa kojom se odredjuje
            for (int i = 0; i < k; i++)
            {
                Random rand = new Random();
                byte[] _a = new byte[number.ToByteArray().LongLength];
                BigInteger a;

                do
                {
                    // izabere se random integer izmedju [2, n - 2]
                    // vrti se petlja dok se ne pronadje dati broj
                    rand.NextBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= number - 2);

                BigInteger x = BigInteger.ModPow(a, d, number);

                if (x == 1 || x == number - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);

                    if (x == 1)
                        return false;
                    if (x == number - 1)
                        break;
                }

                if (x != number - 1)
                    return false;
            }
            return true;
        }

        // Trazi najblizi prost broj
        public BigInteger GenerateNearestPrime(BigInteger number)
        {
            // Dok se ne pronadje prost broj
            while (!MillerRabinTest(number, 10))
            {
                number++;
            }
            return number;
        }

        public void CalculateN()
        {
            if (MillerRabinTest(P, 10) && MillerRabinTest(Q, 10))
            {
                // Ako su prosti brojevi izracuna se moduo N
                N = P * Q;
            }
            else
            {
                // Ako nisu prosta onda se nadju najblizi prosti
                P = GenerateNearestPrime(P);
                Q = GenerateNearestPrime(Q);
                N = P * Q;
            }
        }

        // Trazi se fi
        public void CalculatePhi()
        {
            Phi = (P - 1) * (Q - 1);
        }

        // Generisanje privatnog kljuca
        public void GeneratePrivateKey()
        {
            int k = 1;
            while (((Phi * k + 1) % E) != 0)
            {
                k++;
            }
            D = ((Phi * k) + 1) / E;
        }

        // Generisanje javnog kljuca
        public void GeneratePublicKey()
        {
            E = 2;
            while (E < Phi)
            {
                // E i Phi treba da budu uzajamno prosti
                // 1 < e < phi
                if (BigInteger.GreatestCommonDivisor(E, Phi) == 1) break;
                else E++;
            }
        }

        public void GeneratePublicKey(byte[] e)
        {
            E = new BigInteger(e);
            while (E < Phi)
            {
                // E i Phi treba da budu uzajamno prosti
                // 1 < e < phi
                if (BigInteger.GreatestCommonDivisor(E, Phi) == 1) break;
                else E++;
            }
        }

        public void GenerateRSA()
        {
            CalculateN();
            CalculatePhi();
            //GeneratePublicKey();
            GeneratePrivateKey();

            
            blokM = (int)BigInteger.Log(this.N, 256);
            
            blokC = blokM + 1;
        }

        public byte[] Crypt(byte[] input)
        {
            //BigInteger inputBigInt = new BigInteger(input);
            //BigInteger output = BigInteger.ModPow(inputBigInt, E, N);
            //return output.ToByteArray();

            List<byte> kriptovano = new List<byte>();
            byte[] blok = new byte[blokM + 1];

            for(int i = 0; i<input.Length; i++)
            {
                for (int j = 0; j < blokM; j++)
                {
                    if (i + j < input.Length)
                        blok[j] = input[i + j];
                    else
                        blok[j] = 0;
                }
                blok[blokM] = 0;
                BigInteger m = new BigInteger(blok);
                BigInteger c = BigInteger.ModPow(m, E, N);
                byte[] sifrovaniBlok = c.ToByteArray();
                for (int j = 0; j < blokC; j++)
                {
                    if (j < sifrovaniBlok.Length)
                        kriptovano.Add(sifrovaniBlok[j]);
                    else
                        kriptovano.Add(0);
                }
            }
            return kriptovano.ToArray();
        }

        public byte[] Decrypt(byte[] output)
        {
            //BigInteger outputBigInt = new BigInteger(output);
            //BigInteger result = BigInteger.ModPow(outputBigInt, D, N);
            //return result.ToByteArray();

            List<byte> dekriptovano = new List<byte>();
            byte[] blok = new byte[blokC + 1];
            for (int i = 0; i < output.Length; i += blokC)
            {
                for (int j = 0; j < blokC; j++)
                {
                    if (i + j < output.Length)
                        blok[j] = output[i + j];
                    else
                        blok[j] = 0;
                }
                blok[blokC] = 0;
                BigInteger c = new BigInteger(blok);
                BigInteger m = BigInteger.ModPow(c, D, N);
                byte[] desifrovaniBlok = m.ToByteArray();
                try
                {
                    for (int j = 0; j < blokM; j++)
                    {
                        if (j < desifrovaniBlok.Length)
                            dekriptovano.Add(desifrovaniBlok[j]);
                        else
                            dekriptovano.Add(0);
                    }
                }
                catch(Exception e)
                {

                }
            }
            return dekriptovano.ToArray();
        }

        public BigInteger Crypt(BigInteger input)
        {
            return BigInteger.ModPow(input, E, N);
        }

        public BigInteger Decrypt(BigInteger output)
        {
            return BigInteger.ModPow(output, D, N);
        }

        public void GenerateRandomProperties()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randP = new byte[256];
            byte[] randQ = new byte[256];
            rng.GetBytes(randP);
            rng.GetBytes(randQ);

            this.P = new BigInteger(randP);
            this.Q = new BigInteger(randQ);
        }

    }
}
