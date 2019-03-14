using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoClient.Components;
using System.IO;
using CryptoClient.Forme;
using CryptoClient.ServiceReference;
using System.Numerics;
using CryptoCore.Algoritmi;



namespace CryptoClient
{
    public partial class Form1 : Form
    {
        public Crypto CryptoComponent { get; set; }
        public Watcher WatcherComponent { get; set; }
        private Random rng;

        public Form1()
        {
            Crypto.SrcDir = "D:\\Faks\\Zastita projekat Vladan\\CryptoService\\CryptoClient\\SourceFolder";
            Crypto.DstDir = "D:\\Faks\\Zastita projekat Vladan\\CryptoService\\CryptoClient\\DestinationFolder";
            WatcherComponent = new Watcher(Crypto.SrcDir);
            InitializeComponent();

            string key = "dh13km8v";
            string iv = "mueq239z";
            string p_key = "61";
            string q_key = "53";
            string e_key = "17";
            string poruka = "The quick brown fox jumps over the lazy dog";

            A52KeyTxtBox.Text = key;
            A52IVtxtBox.Text = iv;
            f22TxtBox.Text = Crypto.GenerateRandomBitString(22);
            rc4KeyTxtBox.Text = key;
            rc4IVTxtBox.Text = iv;
            PTxtBox.Text = p_key;
            QTxtBox.Text = q_key;
            ETxtBox.Text = e_key;

            A52inputTxt.Text = poruka;
            rc4InputTxtBox.Text = poruka;
            tigerInputTxtBox.Text = poruka;
            //rsaInputTxtBox.Text = "651786481734681746";
            rsaInputTxtBox.Text = poruka;
            rng = new Random();

            this.fswOffBtn.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region MainForm

        private void srcBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                //Promeni ulazni folder
                Crypto.SrcDir = fbd.SelectedPath;
                MessageBox.Show("Source folder has been changed to: " + Crypto.SrcDir);

                //Promeni se folder koji nadgleda FSW
                WatcherComponent.FSWatcher.Path = Crypto.SrcDir;
                MessageBox.Show("File System Watcher is now monitoring new source folder.");
            }
            this.FocusLbl.Focus();
        }

        private void dstBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                //Promeni odredisni folder
                Crypto.DstDir = fbd.SelectedPath;
                MessageBox.Show("Destination folder has been changed to: " + Crypto.DstDir);
            }
            this.FocusLbl.Focus();
        }

        private void cloudBtn_Click(object sender, EventArgs e)
        {
            CloudClient cc = new CloudClient();
            cc.ShowDialog();

            this.FocusLbl.Focus();
        }

        //Ukljuci FSW
        private void fswOnBtn_Click(object sender, EventArgs e)
        {
            WatcherComponent.Start();
            MessageBox.Show("FileSystemWatcher has been turned ON.");
        }

        //Iskljuci FSW
        private void fswOffBtn_Click(object sender, EventArgs e)
        {
            WatcherComponent.Stop();
            MessageBox.Show("FileSystemWatcher has been turned OFF.");
        }

        //Kada se ugasi aplikacija, FSW upisuje u tekstualni fajl sve fajlove koje je enkriptovao
        //Kako bi sledeci put kad se pokrene mogao da u queue ubaci samo one koji su dodani dok je aplikacija bila zatvorena
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var sw = new StreamWriter(File.OpenWrite(Crypto.EncryptedFilesCfg)))
            {
                CryptoQueue.AlreadyEncrypted.ForEach(f => sw.WriteLine(f));
            }
        }


        #endregion             

        #region TigerHash      

        private async void computeHashBtn_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(this.tigerInputTxtBox.Text);
            EncryptTextMessage msg = new EncryptTextMessage()
            {
                Data = data,
                Algorithm = AlgorithmType.TigerHash
            };

            byte[] response = await Task.Run(() => Crypto.EncryptText(msg));

            //byte[] response = Crypto.EncryptText(msg);

            StringBuilder hex = new StringBuilder(response.Length * 2);
            foreach (byte b in response)
                hex.AppendFormat("{0:x2}", b);

            if (response != null)
            {
                this.hashValueTxtBox.Text = hex.ToString();
            }
        }

        #endregion

        #region RSA

        private async void rsaCryptTxtBtn_Click(object sender, EventArgs e)
        {
            if ((PTxtBox.Text != "") && (QTxtBox.Text != "") && (ETxtBox.Text != "") && (rsaInputTxtBox.Text != ""))
            {
                RSA rsa = new RSA();
                rsa.P = BigInteger.Parse(PTxtBox.Text);
                rsa.Q = BigInteger.Parse(QTxtBox.Text);
                rsa.E = BigInteger.Parse(ETxtBox.Text);
                //BigInteger data = BigInteger.Parse(rsaInputTxtBox.Text);
                BigInteger data = new BigInteger(Encoding.ASCII.GetBytes(rsaInputTxtBox.Text));

                if (!rsa.MillerRabinTest(rsa.P, 10))
                {
                    MessageBox.Show("P mora biti prost broj. Izgenerisan je prost broj koji je najblizi unetom broju.");
                    rsa.P = rsa.GenerateNearestPrime(rsa.P);
                    PTxtBox.Text = rsa.P.ToString();
                }
                if (!rsa.MillerRabinTest(rsa.Q, 10))
                {
                    MessageBox.Show("Q mora biti prost broj. Izgenerisan je prost broj koji je najblizi unetom broju.");
                    rsa.Q = rsa.GenerateNearestPrime(rsa.Q);
                    QTxtBox.Text = rsa.Q.ToString();
                }
                rsa.CalculateN();
                //if (data > rsa.N)
                //{
                //    MessageBox.Show("P i Q moraju biti veci brojevi kako bi N bilo vece ili jednako od podatka.");

                //    BigInteger pom = data / 2;
                //    PTxtBox.Text = pom.ToString();

                //    pom = data / 3;
                //    QTxtBox.Text = pom.ToString();
                //    return;
                //}
                rsa.CalculatePhi();
                if (BigInteger.GreatestCommonDivisor(rsa.Phi, rsa.E) != 1)
                {
                    MessageBox.Show("E mora biti uzajamno prosto sa Phi. Izgenerisano je najblize E koje ispunjava uslov.");
                    rsa.GeneratePublicKey();    // trazi se prvo E koje ispunjava uslov
                    ETxtBox.Text = rsa.E.ToString();
                }
                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data.ToByteArray(),
                    P = rsa.P.ToByteArray(),
                    Q = rsa.Q.ToByteArray(),
                    Key = rsa.E.ToByteArray(),
                    Algorithm = AlgorithmType.RSA
                };
                byte[] response = await Crypto.EncryptText(msg);
                if (response != null)
                {
                    rsaCryptedTxtBox.Text = Convert.ToBase64String(response);  
                    //rsaCryptedTxtBox.Text = new BigInteger(response).ToString();
                }
            }
            else
            {
                MessageBox.Show("Potrebna polja nisu popunjena.");
            }
        }

        private async void rsaDecryptTxtBtn_Click(object sender, EventArgs e)
        {
            if ((PTxtBox.Text != "") && (QTxtBox.Text != "") && (ETxtBox.Text != "") && (rsaCryptedTxtBox.Text != ""))
            {
                RSA rsa = new RSA();
                rsa.P = BigInteger.Parse(PTxtBox.Text);
                rsa.Q = BigInteger.Parse(QTxtBox.Text);
                rsa.E = BigInteger.Parse(ETxtBox.Text);
                //BigInteger data = BigInteger.Parse(rsaCryptedTxtBox.Text);
                BigInteger data = new BigInteger(Convert.FromBase64String(rsaCryptedTxtBox.Text));

                if (!rsa.MillerRabinTest(rsa.P, 10))
                {
                    MessageBox.Show("P mora biti prost broj. Izgenerisan je prost broj koji je najblizi unetom broju.");
                    rsa.P = rsa.GenerateNearestPrime(rsa.P);
                    PTxtBox.Text = rsa.P.ToString();
                }
                if (!rsa.MillerRabinTest(rsa.Q, 10))
                {
                    MessageBox.Show("Q mora biti prost broj. Izgenerisan je prost broj koji je najblizi unetom broju.");
                    rsa.Q = rsa.GenerateNearestPrime(rsa.Q);
                    QTxtBox.Text = rsa.Q.ToString();
                }
                rsa.CalculateN();
                //if (data > rsa.N)
                //{
                //    MessageBox.Show("P i Q moraju biti veci brojevi kako bi N bilo vece ili jednako od podatka.");
                //    return;
                //}
                rsa.CalculatePhi();
                if (BigInteger.GreatestCommonDivisor(rsa.Phi, rsa.E) != 1)
                {
                    MessageBox.Show("E mora biti uzajamno prosto sa Phi. Izgenerisano je najblize E koje ispunjava uslov.");
                    rsa.GeneratePublicKey();    // trazi se prvo E koje ispunjava uslov
                    ETxtBox.Text = rsa.E.ToString();
                }
                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data.ToByteArray(),
                    P = rsa.P.ToByteArray(),
                    Q = rsa.Q.ToByteArray(),
                    Key = rsa.E.ToByteArray(),
                    Algorithm = AlgorithmType.RSA
                };
                byte[] response = await Crypto.DecryptText(msg);
                if (response != null)
                {
                    rsaDecryptedTxtBox.Text = Encoding.ASCII.GetString(response);
                    //rsaDecryptedTxtBox.Text = new BigInteger(response).ToString();
                }
            }
            else
            {
                MessageBox.Show("Potrebna polja nisu popunjena.");
            }
        }

        

        private void PTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void QTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ETxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void rsaInputTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            //if (!Char.IsDigit(ch) && ch != 8)
            //{
            //    e.Handled = true;
            //}
        }

        #endregion

        #region RC4

        private async void rc4CryptTxtBtn_Click(object sender, EventArgs e)
        {
            if (((this.rc4CtrCbx.Checked != true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4InputTxtBox.Text != "")) ||
                ((this.rc4CtrCbx.Checked == true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4InputTxtBox.Text != "") && (this.rc4IVTxtBox.Text != "")))
            {
                byte[] data = Encoding.ASCII.GetBytes(this.rc4InputTxtBox.Text);
                byte[] key = Encoding.ASCII.GetBytes(this.rc4KeyTxtBox.Text);

                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data,
                    Key = key,
                };

                if (this.rc4CtrCbx.Checked == true)
                {
                    msg.Algorithm = AlgorithmType.RC4CTR;
                    byte[] iv = Encoding.ASCII.GetBytes(this.rc4IVTxtBox.Text);
                    msg.IV = iv;
                }
                else
                {
                    msg.Algorithm = AlgorithmType.RC4;
                }

                byte[] response = await Task.Run(() => Crypto.EncryptText(msg));

                if (response != null)
                {
                    this.rc4CryptedTxtBox.Text = Convert.ToBase64String(response);
                }
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena.");
            }
        }

        private async void rc4DecryptTxtBtn_Click(object sender, EventArgs e)
        {
            if (((this.rc4CtrCbx.Checked != true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4CryptedTxtBox.Text != "")) ||
                ((this.rc4CtrCbx.Checked == true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4CryptedTxtBox.Text != "") && (this.rc4IVTxtBox.Text != "")))
            {
                byte[] data = Convert.FromBase64String(this.rc4CryptedTxtBox.Text);
                byte[] key = Encoding.ASCII.GetBytes(this.rc4KeyTxtBox.Text);

                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data,
                    Key = key,
                };

                if (this.rc4CtrCbx.Checked == true)
                {
                    msg.Algorithm = AlgorithmType.RC4CTR;
                    byte[] iv = Encoding.ASCII.GetBytes(this.rc4IVTxtBox.Text);
                    msg.IV = iv;
                }
                else
                {
                    msg.Algorithm = AlgorithmType.RC4;
                }

                byte[] response = await Task.Run(() => Crypto.DecryptText(msg));

                if (response != null)
                {
                    this.rc4DecrytedTxtBox.Text = Encoding.ASCII.GetString(response);
                }
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena.");
            }
        }

        private void rc4CryptFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if (((this.rc4CtrCbx.Checked != true) && (this.rc4KeyTxtBox.Text != "")) ||
                ((this.rc4CtrCbx.Checked == true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4IVTxtBox.Text != "")))
                {
                    AlgorithmProperties metaData = new AlgorithmProperties()
                    {
                        Key = Encoding.ASCII.GetBytes(rc4KeyTxtBox.Text),
                        FileName = System.IO.Path.GetFileName(ofd.FileName)
                    };
                    if (rc4CtrCbx.Checked == true)
                    {
                        metaData.AlgorithmType = AlgorithmType.RC4CTR;
                        metaData.IV = Encoding.ASCII.GetBytes(rc4IVTxtBox.Text);
                    }
                    else
                    {
                        metaData.AlgorithmType = AlgorithmType.RC4;
                    }
                    Crypto.EncryptFile(ofd.FileName, metaData);
                }
                else
                {
                    MessageBox.Show("Polja nisu popunjena.");
                }
            }
        }

        private void rc4DecryptFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (((this.rc4CtrCbx.Checked != true) && (this.rc4KeyTxtBox.Text != "")) ||
                ((this.rc4CtrCbx.Checked == true) && (this.rc4KeyTxtBox.Text != "") && (this.rc4IVTxtBox.Text != "")))
                {
                    AlgorithmProperties metaData = new AlgorithmProperties()
                    {
                        Key = Encoding.ASCII.GetBytes(rc4KeyTxtBox.Text),
                        FileName = System.IO.Path.GetFileName(ofd.FileName)
                    };
                    if (rc4CtrCbx.Checked == true)
                    {
                        metaData.AlgorithmType = AlgorithmType.RC4CTR;
                        metaData.IV = Encoding.ASCII.GetBytes(rc4IVTxtBox.Text);
                    }
                    else
                    {
                        metaData.AlgorithmType = AlgorithmType.RC4;
                    }
                    Crypto.DecryptFile(ofd.FileName, metaData);
                }
                else
                {
                    MessageBox.Show("Polja nisu popunjena.");
                }
            }
        }

        #endregion

        #region A52

        /// <summary>
        /// Kriptovanje teksta A52
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void A52cryptBtn_Click(object sender, EventArgs e)
        {
            if (((this.A52CtrModeCbox.Checked != true) && (this.A52KeyTxtBox.Text != "") && (this.A52inputTxt.Text != "") && (this.f22TxtBox.Text != "")) ||
               ((this.A52CtrModeCbox.Checked == true) && (this.A52KeyTxtBox.Text != "") && (this.A52inputTxt.Text != "") && (this.A52IVtxtBox.Text != "") && (this.f22TxtBox.Text != "")))
            {
                byte[] data = Encoding.ASCII.GetBytes(this.A52inputTxt.Text);
                byte[] key = Encoding.ASCII.GetBytes(this.A52KeyTxtBox.Text);
                string f = this.f22TxtBox.Text;

                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data,
                    Key = key,
                    FKeyA52 = f
                };

                if (this.A52CtrModeCbox.Checked == true)
                {
                    msg.Algorithm = AlgorithmType.A52CTR;
                    byte[] iv = Encoding.ASCII.GetBytes(this.A52IVtxtBox.Text);
                    msg.IV = iv;
                }
                else
                {
                    msg.Algorithm = AlgorithmType.A52;
                }

                byte[] response = await Task.Run(() => Crypto.EncryptText(msg));

                if (response != null)
                {
                    this.A52cryptedTxt.Text = Convert.ToBase64String(response);                    
                }
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena.");
            }
        }

        /// <summary>
        /// Dekriptovanje teksta A52
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void A52decryptBtn_Click(object sender, EventArgs e)
        {
            if (((this.A52CtrModeCbox.Checked != true) && (this.A52KeyTxtBox.Text != "") && (this.A52cryptedTxt.Text != "") && (this.f22TxtBox.Text != "")) ||
               ((this.A52CtrModeCbox.Checked == true) && (this.A52KeyTxtBox.Text != "") && (this.A52cryptedTxt.Text != "") && (this.A52IVtxtBox.Text != "") && (this.f22TxtBox.Text != "")))
            {
                byte[] data = Convert.FromBase64String(this.A52cryptedTxt.Text);
                byte[] key = Encoding.ASCII.GetBytes(this.A52KeyTxtBox.Text);
                string f = this.f22TxtBox.Text;

                EncryptTextMessage msg = new EncryptTextMessage()
                {
                    Data = data,
                    Key = key,
                    FKeyA52 = f
                };

                if (this.A52CtrModeCbox.Checked == true)
                {
                    msg.Algorithm = AlgorithmType.A52CTR;
                    byte[] iv = Encoding.ASCII.GetBytes(this.A52IVtxtBox.Text);
                    msg.IV = iv;
                }
                else
                {
                    msg.Algorithm = AlgorithmType.A52;
                }

                byte[] response = await Task.Run(() => Crypto.DecryptText(msg));

                if (response != null)
                {
                    this.A52decryptedTxt.Text = Encoding.ASCII.GetString(response);
                }
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena.");
            }
        }

        /// <summary>
        /// Kriptovanje fajla A52
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void A52FileCryptBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (((this.A52CtrModeCbox.Checked != true) && (this.A52KeyTxtBox.Text != "") && (this.f22TxtBox.Text != "")) ||
                ((this.A52CtrModeCbox.Checked == true) && (this.A52KeyTxtBox.Text != "") && (this.A52IVtxtBox.Text != "") && (this.f22TxtBox.Text != "")))
                {
                    AlgorithmProperties metaData = new AlgorithmProperties()
                    {
                        Key = Encoding.ASCII.GetBytes(A52KeyTxtBox.Text),
                        FileName = System.IO.Path.GetFileName(ofd.FileName),
                        FKeyA52 = f22TxtBox.Text
                    };
                    if (A52CtrModeCbox.Checked == true)
                    {
                        metaData.AlgorithmType = AlgorithmType.A52CTR;
                        metaData.IV = Encoding.ASCII.GetBytes(A52IVtxtBox.Text);
                    }
                    else
                    {
                        metaData.AlgorithmType = AlgorithmType.A52;
                    }
                    Crypto.EncryptFile(ofd.FileName, metaData);
                }
                else
                {
                    MessageBox.Show("Polja nisu popunjena.");
                }
            }
        }

        /// <summary>
        /// Dekriptovanje fajla A52
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void A52FileDecryptBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (((this.A52CtrModeCbox.Checked != true) && (this.A52KeyTxtBox.Text != "") && (this.f22TxtBox.Text != "")) ||
                ((this.A52CtrModeCbox.Checked == true) && (this.A52KeyTxtBox.Text != "") && (this.A52IVtxtBox.Text != "") && (this.f22TxtBox.Text != "")))
                {
                    AlgorithmProperties metaData = new AlgorithmProperties()
                    {
                        Key = Encoding.ASCII.GetBytes(A52KeyTxtBox.Text),
                        FileName = System.IO.Path.GetFileName(ofd.FileName),
                        FKeyA52 = f22TxtBox.Text
                    };
                    if (A52CtrModeCbox.Checked == true)
                    {
                        metaData.AlgorithmType = AlgorithmType.A52CTR;
                        metaData.IV = Encoding.ASCII.GetBytes(A52IVtxtBox.Text);
                    }
                    else
                    {
                        metaData.AlgorithmType = AlgorithmType.A52;
                    }
                    Crypto.DecryptFile(ofd.FileName, metaData);
                }
                else
                {
                    MessageBox.Show("Polja nisu popunjena.");
                }
            }
        }

        #endregion
    }
}
