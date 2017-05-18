using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Windows.Forms;

using Shauni.Database;

namespace Shauni
{
    public class DataLoader
    {            
        private Boolean isLoadingFromCollection;
        private Thread workerThread;

        public event EventHandler<FileLoadedEventArgs> FileLoaded;
        public event EventHandler OperationCompleted;

        public Int64 TotalFileLoaded { get; protected set; }
        public Int64 TotalFileScanned { get; protected set; }

        protected ShauniDatabase database;

        public DataLoader(ShauniDatabase database)
        {
            this.database = database;
        }

        public void LoadAsync(String path)
        {
            if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                throw new ThreadStateException("LoadAsync is still running. To process asynchronously multiple file/directory, please consider using LoadAllAsync.");

            workerThread = new Thread(delegate() { this.Load(path); });
            workerThread.Start();
        }

        public void LoadAllAsync<V>(V paths)
            where V : IEnumerable<String>
        {
            if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                throw new ThreadStateException("LoadAllAsync is still running. To process asynchronously multiple file/directory, please include all elements as the input of this method.");

            workerThread = new Thread(delegate() { this.LoadAll(paths); });
            workerThread.Start();
        }

        private void LoadAll<V>(V pathCollection)
            where V : IEnumerable<String>
        {
            this.isLoadingFromCollection = true;

            foreach (String path in pathCollection)
                this.Load(path);

            this.FinalizeLoading();
            this.isLoadingFromCollection = false;
        }

        private void Load(string path)
        {
            if (!File.Exists(path))
            {
                if (Directory.Exists(path))
                    this.LoadDirectory(path);
                else
                    throw new FileNotFoundException(path);
            }
            else
                this.LoadFile(path);

            if (!this.isLoadingFromCollection)
                this.FinalizeLoading();
        }

        private void LoadDirectory(String directoryPath)
        {
            foreach (String fileName in Directory.EnumerateFiles(directoryPath))
                this.LoadFile(directoryPath);

            foreach (String directoryName in Directory.GetDirectories(directoryPath))
                this.LoadDirectory(directoryName);
        }

        private void LoadFile(String path)
        {
            if (SharedData.AudioFormats.Contains(Path.GetExtension(path).ToLower()))
            {
                this.TotalFileScanned++;

                //var media = SharedData.Database.Song.FindByFilename(path);
                Song media = SharedData.Database.Song.Where(song => song.Filename == path).FirstOrDefault();

                if (media == null)
                {
                    media = SharedData.Id3SongCreator.CreateFromFile(path);

                    if (media.Artist == null) //temporarly
                        return;

                    //SharedData.Downloader.FindSong(media.Name, , med => UpdateInformation(artistName, med));
                    SharedData.EchoNestManager.FindBySong(media, EchoNest.Song.SongBucket.AudioSummary);
                }
                else
                    return;

                if (media != null)
                {
                    this.TotalFileLoaded++;
                    FileLoadedEventArgs fbe = new FileLoadedEventArgs(media);

                    if (FileLoaded != null)
                        FileLoaded(this, fbe);
                }
            }
        }

        private void FinalizeLoading()
        {
            if (OperationCompleted != null)
                OperationCompleted(this, EventArgs.Empty);
        }
    }

    public class FileLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; private set; }

        public FileLoadedEventArgs(IMedia media)
        {
            this.Media = media;
        }
    }
}
