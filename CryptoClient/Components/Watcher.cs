using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CryptoClient.Components
{
    public class Watcher
    {
        private FileSystemWatcher watcher;
        private CryptoQueue cryptoQueue;
        private DateTime lastRead = DateTime.MinValue;  // Da FSW ne bi vise puta raisovao event
        private string lastFile;

        public Watcher(string path)
        {
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter =
                NotifyFilters.FileName |
                NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            // Ukoliko je promenjen fajl
            watcher.Changed += OnChanged;
            watcher.EnableRaisingEvents = true;

            cryptoQueue = new CryptoQueue();
            //SynchronizeFiles();
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            SynchronizeFiles();
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void SynchronizeFiles()
        {
            string[] files = Directory.GetFiles(Crypto.SrcDir);
            for (int i = 0; i < files.Length; i++) cryptoQueue.Enqueue(files[i]);
        }

        // Kada se promeni nesto u folderu onda se dodaje u queue
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var now = DateTime.Now;
            var lastWriteTime = File.GetLastWriteTime(e.FullPath);

            // Po imenu
            var lastWriteName = e.Name;

            if (now == lastWriteTime || e.Name == lastFile)
                return;

            if (lastWriteTime != lastRead && lastWriteName != lastFile)
            {
                lastRead = lastWriteTime;

                lastFile = lastWriteName;

                // Queue se dodati fajl
                cryptoQueue.Enqueue(e.FullPath);
            }
        }

        public FileSystemWatcher FSWatcher { get { return this.watcher; } }
    }
}
