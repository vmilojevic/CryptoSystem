using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using CryptoClient.ServiceReference;

namespace CryptoClient.Components
{
    public class CryptoQueue: Queue
    {
        private object cryptBlock;
        public static List<string> AlreadyEncrypted { get; set; }

        public CryptoQueue()
            : base()
        {
            cryptBlock = new object();

            // Vec enkriptovani fajlovi
            AlreadyEncrypted = new List<string>();
            ReadFromCfg(Crypto.EncryptedFilesCfg);
        }

        // Napuni AlreadyEncripted svim fajlovima koji su vec enkriptovani
        // pre zatvaranja aplikacije
        private void ReadFromCfg(string cfg)
        {
            using (var sr = new StreamReader(File.OpenRead(cfg)))
            {
                string f;
                while ((f = sr.ReadLine()) != null)
                {
                    AlreadyEncrypted.Add(f);
                }
            }
        }

        // Procesira queue
        public async void ProcessQueue()
        {
            string fullName = this.Peek().ToString();
            Task t = Task.Run(() =>
            {
                try
                {
                    using (var stream = File.OpenRead(fullName))
                    {
                        if (stream.Length > Crypto.MaxMessageSize) throw new MaxSizeException("Enqueued file is too large.");
                        AlgorithmProperties metaData = new AlgorithmProperties()
                        {
                            FileName = Path.GetFileName(fullName),
                            AlgorithmType = AlgorithmType.RC4,
                            Key = Crypto.KeyRC4
                        };
                        // Pozove se funkcija za kriptovanje
                        MessageBox.Show(String.Format("File {0} is being crypted by FSW.", fullName));
                        bool finished = ServiceDriver.Instance.Encrypt(metaData, stream);

                        if (finished)
                        {
                            // Ukoliko su ulazni i izlazni folderi isti proveri se da li postoji fajl sa tim imenom
                            string path = Crypto.GenerateFileName(Crypto.DstDir, metaData.FileName);
                            Stream encryptedData = ServiceDriver.Instance.DownloadFile(metaData.FileName);

                            if (Crypto.SrcDir == Crypto.DstDir) AlreadyEncrypted.Add(path);

                            using (var fileStream = File.Create(path))
                            {
                                encryptedData.CopyTo(fileStream);
                                MessageBox.Show(String.Format("File {0} has been successfully crypted.", metaData.FileName), "File System Watcher");
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Error while crypting {0} ", metaData.FileName), "File System Watcher");
                        }
                    }
                }
                catch (MaxSizeException me)
                {
                    MessageBox.Show(me.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("There has been an error while processing queue.");
                }
            });
            await t;
            AlreadyEncrypted.Add(fullName);
            this.Dequeue();
            if (this.Count != 0)
                ProcessQueue();
        }

        public override void Enqueue(object obj)
        {
            // Ako nije tacno jedan onda ce samo da radi enqueue
            // Ako je neki drugi count onda ce ProcessQueue da serijalizuje to
            // Za slucaj kad je ulazni i izlazni direktorijum isti, ispituje se bafer da se proveri
            // da li je mozda taj fajl vec enkriptovan
            if (!AlreadyEncrypted.Exists(f => f == (string)obj))
            {
                base.Enqueue(obj);

                MessageBox.Show(String.Format("File: {0} has been enqueued.", (string)obj));

                if (this.Count == 1)
                    ProcessQueue();
            }
        }

        public override object Dequeue()
        {
            return base.Dequeue();
        }
    }
}
