using CryptoClient.Components;
using CryptoClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoClient.Forme
{
    public partial class CloudClient : Form
    {
        private ServiceReference.ServiceClient csClient;
        private List<string> serviceFiles;

        public CloudClient()
        {
            serviceFiles = new List<string>();
            csClient = ServiceDriver.Instance;
            GetCloudFilesList();
            
            InitializeComponent();
            listBox.DataSource = serviceFiles;


        }

        private void GetCloudFilesList()
        {
            try
            {
                // Asinhrono se pozove metoda za pribavljanje liste fajlova koji se nalaze na server cloudu
                // Task<string[]> listTask = Task.Run(() => csClient.ListFiles());
                // this.FillCollection(await listTask);
                // listBox.DataSource = serviceFiles;
                string[] lista = csClient.ListFiles();
                FillCollection(lista);
            }
            catch (Exception e)
            {
                // Ako server nije ukljucen 
                MessageBox.Show("Problem sa konekcijom.");
            }
        }

        private void FillCollection(string[] list)
        {
            foreach (string s in list)
            {
                this.serviceFiles.Add(s);
            }
        }

        private void CloudClient_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Upload file to cloud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileMetaData metaData = new FileMetaData()
                {
                    fileName = System.IO.Path.GetFileName(ofd.FileName)
                };
                try
                {
                    FileStream fstream = File.OpenRead(ofd.FileName);
                    if (fstream.Length > Crypto.MaxMessageSize) throw new MaxSizeException("Velicina fajla prelazi maksimalnu dozvoljednu velicinu.");

                    Task<bool> uploadTask = Task.Run(() => csClient.UploadFile(metaData, fstream));
                    var success = await uploadTask;

                    if (success)
                    {
                        MessageBox.Show(String.Format("Fajl: {0} je uploadovan na server cloud.", metaData.fileName), "Cloud Upload");
                        serviceFiles.Add(metaData.fileName);
                        listBox.DataSource = null;
                        listBox.DataSource = serviceFiles;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Fajl: {0} nije uspesno uploadovan na server cloud.", metaData.fileName), "Cloud Upload");
                    }
                }
                
                catch (MaxSizeException me)
                {
                    MessageBox.Show(me.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri uploadovanju fajla.");
                }
                
            }
        }
        /// <summary>
        /// Download file from cloud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            if(this.listBox.SelectedIndex != -1)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFile = (string)listBox.SelectedItem;
                        // Asinhrono se pozove metoda
                        Task<Stream> task = Task.Run(() => csClient.DownloadFile(selectedFile));
                        Stream stream = await task;

                        using (var fileStream = File.Create(System.IO.Path.Combine(fbd.SelectedPath, selectedFile)))
                        {
                            stream.CopyTo(fileStream);
                            MessageBox.Show(String.Format("Fajl {0} je uspesno downloadovan.", selectedFile), "Cloud Download");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Doslo je do greske pri downloadovanju.");
                    }
                }
            }
        }
        /// <summary>
        /// Delete file from cloud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            if(this.listBox.SelectedIndex != -1)
            {
                try
                {
                    // Asinhrono se pozove metoda
                    string selectedFile = (string)listBox.SelectedItem;
                    Task<bool> task = Task.Run(() => csClient.DeleteFile(selectedFile));
                    var success = await task;
                    if (success)
                    {
                        serviceFiles.Remove(selectedFile);
                        listBox.DataSource = null;
                        listBox.DataSource = serviceFiles;
                        MessageBox.Show(String.Format("Fajl {0} je uspesno obrisan sa clouda.", selectedFile), "Cloud Delete");
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Fajl {0} nije uspesno obrisan.", selectedFile), "Cloud Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske pri brisanju.");
                }
               
            }
        }

        
    }
}
