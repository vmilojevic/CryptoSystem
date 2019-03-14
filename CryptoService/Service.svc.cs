using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CryptoCore.Algoritmi;
using System.Numerics;

namespace CryptoService
{
    [ServiceBehavior]
    public class Service : IService
    {
        // Lokacija cloud-a
        private string fileCloudPath;
        private string decryptedFilePath;
        // Lista fajlova koji se nalaze u cloudu
        private List<string> cloudFiles;

        public Service()
        {
            fileCloudPath = "D:\\Faks\\Zastita projekat Vladan\\CryptoService\\CryptoService\\Cloud";
            decryptedFilePath = "D:\\Faks\\Zastita projekat Vladan\\CryptoService\\CryptoService\\Decrypted Files";
            cloudFiles = new List<string>();
            GetFilesFromCloud();
        }

        #region MiniCloud

        // Brisanje fajla sa clouda
        public bool DeleteFile(string filename)
        {
            try
            {
                string file = Path.Combine(fileCloudPath, filename);
                // Ako fajl sa ovim imenom ne postoji na cloudu
                if (File.Exists(file))
                {
                    File.Delete(file);
                    cloudFiles.Remove(filename);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Stream DownloadFile(string name)
        {
            try
            {
                string file = Path.Combine(fileCloudPath, name);
                FileStream fstream = File.OpenRead(file);
                return fstream;
            }
            catch (IOException ex)
            {
                Console.WriteLine(String.Format("An exception was thrown while trying to open file"));
                Console.WriteLine("Exception is: ");
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        // Vraca listu fajlova sa service clouda
        public List<string> ListFiles()
        {
            return cloudFiles;
        }

        public UploadFileResponse UploadFile(FileUploadMessage file)
        {
            // Snima se fajl u FileCloud-u
            string fileName = Path.Combine(fileCloudPath, file.Metadata.fileName);
            UploadFileResponse response = new UploadFileResponse();
            try
            {
                using (var fstream = new FileStream(fileName, FileMode.Create))
                {
                    file.Data.CopyTo(fstream);
                    response.Finished = true;
                }
                return response;
            }
            catch (IOException ex)
            {
                response.Finished = false;
                return response;
            }
        }

        private void GetFilesFromCloud()
        {
            DirectoryInfo cloudDir = new DirectoryInfo(fileCloudPath);
            foreach (FileInfo f in cloudDir.GetFiles())
            {
                cloudFiles.Add(f.Name);
            }
        }

        #endregion

        #region Cypher

        public EncryptFileResponse Encrypt(EncryptFileMessage cryptMessage)
        {
            EncryptFileResponse response = new EncryptFileResponse();

            //Odradi se enkripcija
            if (cryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4 || cryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4CTR)
            {
                try
                {
                    using (var bw = new BinaryWriter(File.Open
                        (Path.Combine(fileCloudPath, cryptMessage.MetaData.FileName), FileMode.Create, FileAccess.Write, FileShare.None)))
                    {
                        try
                        {
                            BinaryReader br = new BinaryReader(cryptMessage.Data);
                            RC4 rc4;
                            bool ctr;
                            if (cryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4)
                            {
                                ctr = false;
                                rc4 = new RC4(cryptMessage.MetaData.Key);
                            }
                            else
                            {
                                ctr = true;
                                rc4 = new RC4(cryptMessage.MetaData.Key, cryptMessage.MetaData.IV);
                            }

                            int buffSize = 2048;
                            byte[] buff = new byte[buffSize];
                            int bytesRead;
                            while ((bytesRead = br.Read(buff, 0, buff.Length)) > 0)
                            {
                                if (bytesRead < buffSize)
                                {
                                    byte[] tmp_buff = new byte[bytesRead];
                                    Buffer.BlockCopy(buff, 0, tmp_buff, 0, bytesRead);
                                    byte[] output;
                                    if (ctr)
                                        output = rc4.CryptWithCTR(tmp_buff);
                                    else
                                        output = rc4.Crypt(tmp_buff);
                                    bw.Write(output);
                                }
                                else
                                {
                                    byte[] output;
                                    if (ctr)
                                        output = rc4.CryptWithCTR(buff);
                                    else
                                        output = rc4.Crypt(buff);
                                    bw.Write(output);
                                }
                            }
                            response.Finished = true;
                        }
                        catch (Exception ex)
                        {
                            Console.Write("asd");
                            response.Finished = false;
                        }
                    }
                }
                catch(Exception e)
                {

                }
            }
            else if (cryptMessage.MetaData.AlgorithmType == AlgorithmType.A52 || cryptMessage.MetaData.AlgorithmType == AlgorithmType.A52CTR)
            {
                try
                {
                    using (var bw = new BinaryWriter(File.Open
                       (Path.Combine(fileCloudPath, cryptMessage.MetaData.FileName), FileMode.Create, FileAccess.Write, FileShare.None)))
                    {
                        try
                        {
                            BinaryReader br = new BinaryReader(cryptMessage.Data);

                            A52 a52 = new A52();
                            a52.SetKey(cryptMessage.MetaData.Key);
                            a52.SetF(cryptMessage.MetaData.FKeyA52);
                            bool ctr = false;

                            if (cryptMessage.MetaData.AlgorithmType == AlgorithmType.A52CTR)
                            {
                                a52.SetIV(cryptMessage.MetaData.IV);
                                ctr = true;
                            }

                            int buffSize = 2048;
                            byte[] buff = new byte[buffSize];
                            int bytesRead;
                            while ((bytesRead = br.Read(buff, 0, buff.Length)) > 0)
                            {
                                if (bytesRead < buffSize)
                                {
                                    byte[] tmp_buff = new byte[bytesRead];
                                    Buffer.BlockCopy(buff, 0, tmp_buff, 0, bytesRead);
                                    byte[] output;
                                    if (ctr)
                                        output = a52.CryptWithCTR(tmp_buff);
                                    else
                                        output = a52.Crypt(tmp_buff);
                                    bw.Write(output);
                                }
                                else
                                {
                                    byte[] output;
                                    if (ctr)
                                        output = a52.CryptWithCTR(buff);
                                    else
                                        output = a52.Crypt(buff);
                                    bw.Write(output);
                                }
                            }
                            response.Finished = true;
                        }
                        catch (Exception ex)
                        {
                            response.Finished = false;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }                      
            else
            {
                response.Finished = false;
            }
            return response;
        }

        // Dekriptovanje fajl
        public EncryptFileResponse Decrypt(EncryptFileMessage decryptMessage)
        {
            EncryptFileResponse response = new EncryptFileResponse();

            //Odradi se enkripcija
            if (decryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4 || decryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4CTR)
            {
                try
                {
                    using (var bw = new BinaryWriter(File.Open
                        (Path.Combine(decryptedFilePath, decryptMessage.MetaData.FileName), FileMode.Create, FileAccess.Write, FileShare.None)))
                    {
                        try
                        {
                            BinaryReader br = new BinaryReader(decryptMessage.Data);
                            RC4 rc4;
                            bool ctr;
                            if (decryptMessage.MetaData.AlgorithmType == AlgorithmType.RC4)
                            {
                                ctr = false;
                                rc4 = new RC4(decryptMessage.MetaData.Key);
                            }
                            else
                            {
                                ctr = true;
                                rc4 = new RC4(decryptMessage.MetaData.Key, decryptMessage.MetaData.IV);
                            }

                            int buffSize = 2048;
                            byte[] buff = new byte[buffSize];
                            int bytesRead;
                            while ((bytesRead = br.Read(buff, 0, buff.Length)) > 0)
                            {
                                if (bytesRead < buffSize)
                                {
                                    byte[] tmp_buff = new byte[bytesRead];
                                    Buffer.BlockCopy(buff, 0, tmp_buff, 0, bytesRead);
                                    byte[] output;

                                    if (ctr)
                                        output = rc4.DecryptWithCTR(tmp_buff);
                                    else
                                        output = rc4.Decrypt(tmp_buff);

                                    bw.Write(output);
                                }
                                else
                                {
                                    byte[] output;

                                    if (ctr)
                                        output = rc4.DecryptWithCTR(buff);
                                    else
                                        output = rc4.Decrypt(buff);

                                    bw.Write(output);
                                }
                            }
                            response.Finished = true;
                        }
                        catch (Exception ex)
                        {
                            //Console.Write("Exception");
                        }
                    }
                }
                catch(Exception ex)
                {
                    
                }
                
            }
            else if (decryptMessage.MetaData.AlgorithmType == AlgorithmType.A52 || decryptMessage.MetaData.AlgorithmType == AlgorithmType.A52CTR)
            {
                try
                {
                    using (var bw = new BinaryWriter(File.Open
                        (Path.Combine(decryptedFilePath, decryptMessage.MetaData.FileName), FileMode.Create, FileAccess.Write, FileShare.None)))
                    {
                        try
                        {
                            BinaryReader br = new BinaryReader(decryptMessage.Data);

                            A52 a52 = new A52();
                            a52.SetKey(decryptMessage.MetaData.Key);
                            a52.SetF(decryptMessage.MetaData.FKeyA52);
                            bool ctr = false;

                            if (decryptMessage.MetaData.AlgorithmType == AlgorithmType.A52CTR)
                            {
                                a52.SetIV(decryptMessage.MetaData.IV);
                                ctr = true;
                            }

                            int buffSize = 2048;
                            byte[] buff = new byte[buffSize];
                            int bytesRead;
                            while ((bytesRead = br.Read(buff, 0, buff.Length)) > 0)
                            {
                                if (bytesRead < buffSize)
                                {
                                    byte[] tmp_buff = new byte[bytesRead];
                                    Buffer.BlockCopy(buff, 0, tmp_buff, 0, bytesRead);
                                    byte[] output;

                                    if (ctr)
                                        output = a52.DecryptWithCTR(tmp_buff);
                                    else
                                        output = a52.Decrypt(tmp_buff);

                                    bw.Write(output);
                                }
                                else
                                {
                                    byte[] output;

                                    if (ctr)
                                        output = a52.DecryptWithCTR(buff);
                                    else
                                        output = a52.Decrypt(buff);

                                    bw.Write(output);
                                }
                            }
                            response.Finished = true;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            else
            {
                response.Finished = false;
            }
            return response;
        }

        public byte[] EncryptText(EncryptTextMessage message)
        {
            byte[] encryptedText = null;
            //Odradi se enkripcija
            if (message.Algorithm == AlgorithmType.RC4)
            {
                RC4 rc = new RC4(message.Key, message.IV);
                encryptedText = rc.Crypt(message.Data);
            }
            else if (message.Algorithm == AlgorithmType.RC4CTR)
            {
                RC4 rc = new RC4(message.Key, message.IV);
                encryptedText = rc.CryptWithCTR(message.Data);
            }
            else if (message.Algorithm == AlgorithmType.A52 || message.Algorithm == AlgorithmType.A52CTR)
            {
                A52 alg = new A52();
                alg.SetKey(message.Key);
                alg.SetF(message.FKeyA52);

                if (message.Algorithm == AlgorithmType.A52)
                {
                    encryptedText = alg.Crypt(message.Data);
                }
                else
                {
                    alg.SetIV(message.IV);
                    encryptedText = alg.CryptWithCTR(message.Data);
                }
            }
            else if (message.Algorithm == AlgorithmType.RSA)
            {
                RSA rsa = new RSA();
                rsa.E = new BigInteger(message.Key);
                rsa.P = new BigInteger(message.P);
                rsa.Q = new BigInteger(message.Q);
                rsa.GenerateRSA();
                //BigInteger result = rsa.Crypt(new BigInteger(message.Data));
                //encryptedText = result.ToByteArray();
                encryptedText = rsa.Crypt(message.Data);

            }
            else if (message.Algorithm == AlgorithmType.TigerHash)
            {
                TigerHash th = new TigerHash();
                byte[] msg = message.Data;
                encryptedText = th.ComputeHash(message.Data);
            }
            return encryptedText;
        }

        public byte[] DecryptText(EncryptTextMessage message)
        {
            byte[] decryptedText = null;
            //Odradi se enkripcija
            if (message.Algorithm == AlgorithmType.RC4)
            {
                RC4 rc = new RC4(message.Key, message.IV);
                decryptedText = rc.Decrypt(message.Data);
            }
            else if (message.Algorithm == AlgorithmType.RC4CTR)
            {
                RC4 rc = new RC4(message.Key, message.IV);
                decryptedText = rc.DecryptWithCTR(message.Data);
            }
            else if (message.Algorithm == AlgorithmType.A52 || message.Algorithm == AlgorithmType.A52CTR)
            {
                A52 alg = new A52();
                alg.SetKey(message.Key);
                alg.SetF(message.FKeyA52);

                if (message.Algorithm == AlgorithmType.A52)
                {
                    decryptedText = alg.Decrypt(message.Data);
                }
                else
                {
                    alg.SetIV(message.IV);
                    decryptedText = alg.DecryptWithCTR(message.Data);
                }
            }
            else if (message.Algorithm == AlgorithmType.RSA)
            {
                RSA rsa = new RSA();
                rsa.E = new BigInteger(message.Key);
                rsa.P = new BigInteger(message.P);
                rsa.Q = new BigInteger(message.Q);
                rsa.GenerateRSA();
                //BigInteger result = rsa.Decrypt(new BigInteger(message.Data));
                //decryptedText = result.ToByteArray();
                decryptedText = rsa.Decrypt(message.Data);
            }

            return decryptedText;
        }

        #endregion

    }
}
