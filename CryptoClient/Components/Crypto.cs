using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoClient.ServiceReference;
using System.Security.Cryptography;

namespace CryptoClient.Components
{
    public class Crypto
    {        
        public static string EncryptedFilesCfg =
            "D:\\Faks\\Zastita projekat Vladan\\CryptoService\\CryptoClient\\EncryptedByFSW.txt";

        // Ulazni i izlazni direktorijum za kriptovane i dekriptovane fajlove
        public static string SrcDir { get; set; }
        public static string DstDir { get; set; }
        public static long MaxMessageSize = 2000000000;

        public static byte[] KeyRC4 = Encoding.ASCII.GetBytes("dj139k8t");

        // Pomocna funkcija ukoliko postoje fajlovi sa istim imenom
        public static string GenerateFileName(string dir, string fname)
        {
            int count = 0;
            String path = Path.Combine(dir, fname);
            String fileName = Path.GetFileNameWithoutExtension(path);
            String save = path;
            String ext = Path.GetExtension(path);
            while (File.Exists(save))
            {
                String name = fileName + count + ext;
                save = Path.Combine(dir, name);
                count++;
            }
            return save;
        }

        //Funkcije za kriptovanje da stavim ovde da bi svi mogli da ih pozivaju
        public static async Task<byte[]> EncryptText(EncryptTextMessage msg)
        {
            byte[] encryptedText = null;
            try
            {
                encryptedText = await Task.Run(() => ServiceDriver.Instance.EncryptText(msg));
            }
            catch (Exception e)
            {
                MessageBox.Show("Doslo je do greske pri kriptovanju teksta.");
            }

            return encryptedText;
        }



        // Dekriptovanje teksta
        public static async Task<byte[]> DecryptText(EncryptTextMessage msg)
        {
            byte[] decryptedText = null;
            try
            {
                decryptedText = await Task.Run(() => ServiceDriver.Instance.DecryptText(msg));
            }
            catch (Exception e)
            {
                MessageBox.Show("Doslo je do greske pri dekriptovanju teksta.");
            }

            return decryptedText;
        }

        // Kriptovanje fajla
        public static async void EncryptFile(string fileName, AlgorithmProperties props)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        if (stream.Length > Crypto.MaxMessageSize) throw new MaxSizeException("Velicina fajla prelazi maksimalnu dozvoljednu velicinu.");
                        // Pozove se funkcija za kriptovanje
                        MessageBox.Show(String.Format("Fajl {0} se kriptuje od strane FSW-a.", fileName));
                        bool finished = ServiceDriver.Instance.Encrypt(props, stream);

                        if (finished)
                        {
                            // Ukoliko su ulazni i izlazni folderi isti proveri se da li postoji fajl sa tim imenom
                            string path = Crypto.GenerateFileName(Crypto.DstDir, props.FileName);
                            Stream encryptedData = ServiceDriver.Instance.DownloadFile(props.FileName);
                            using (var fileStream = File.Create(path))
                            {
                                encryptedData.CopyTo(fileStream);
                                MessageBox.Show(String.Format("Fajl {0} je uspesno kriptovan.", props.FileName), "File System Watcher");
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Fajl {0} nije uspesno kriptovan.", props.FileName), "File System Watcher");
                        }
                    }
                }
                catch (MaxSizeException me)
                {
                    MessageBox.Show(me.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Doslo je do greske pri radu buffering queue-a FSW-a.");
                }
            });
        }

        public static async void DecryptFile(string fileName, AlgorithmProperties props)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        if (stream.Length > Crypto.MaxMessageSize) throw new MaxSizeException("Velicina fajla prelazi maksimalnu dozvoljednu velicinu.");
                        props.FileName = Path.GetFileName(fileName);
                        // Pozove se funkcija za kriptovanje
                        MessageBox.Show(String.Format("Fajl {0} se kriptuje od strane FSW-a.", fileName));
                        bool finished = ServiceDriver.Instance.Decrypt(props, stream);

                        if (finished)
                        {
                            // Ukoliko su ulazni i izlazni folderi isti proveri se da li postoji fajl sa tim imenom
                            string path = Crypto.GenerateFileName(Crypto.DstDir, props.FileName);
                            Stream encryptedData = ServiceDriver.Instance.DownloadFile(props.FileName);
                            using (var fileStream = File.Create(path))
                            {
                                encryptedData.CopyTo(fileStream);
                                MessageBox.Show(String.Format("Fajl {0} je uspesno kriptovan.", props.FileName), "File System Watcher");
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Fajl {0} nije uspesno kriptovan.", props.FileName), "File System Watcher");
                        }
                    }
                }
                catch (MaxSizeException me)
                {
                    MessageBox.Show(me.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Doslo je do greske pri radu buffering queue-a FSW-a.");
                }
            });
        }

        public static byte[] GenerateRandomKey(int n)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] result = new byte[n];
            rng.GetBytes(result);
            return result;
        }

        public static string GenerateRandomBitString(int n)
        {
            char[] result = new char[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                if (r.NextDouble() >= 0.5)
                    result[i] = '1';
                else
                    result[i] = '0';
            }
            return new string(result);
        }
    }

    public class MaxSizeException : Exception
    {
        public MaxSizeException()
        {

        }

        public MaxSizeException(string message)
            : base(message)
        {

        }
    }
}
