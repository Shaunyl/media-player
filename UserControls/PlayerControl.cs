using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Shauni.Database;
using System.IO;

namespace Shauni.UserControls
{
    using VideoPlayer = Microsoft.DirectX.AudioVideoPlayback.Video;
    using AudioPlayer = Microsoft.DirectX.AudioVideoPlayback.Audio;

    public partial class PlayerControl : UserControl
    {
        [Description("Occurs before the playback starts. Supports cancellation.")]
        public event EventHandler<InvocationEventArgs> PlaybackStarting;
        [Description("Occurs before the playback pauses. Supports cancellation.")]
        public event EventHandler<InvocationEventArgs> PlaybackPausing;
        [Description("Occurs before the playback stops. Supports cancellation.")]
        public event EventHandler<InvocationEventArgs> PlaybackStopping;
        [Description("Occurs after the LoopEnabled property has changed.")]
        public event EventHandler LoopEnabledChanged;
        [Description("Occurs when the Random button is clicked. The event handler should load a random media file in the player and start the playback.")]
        public event EventHandler RandomMediaRequired;
        [Description("Occurs after a file is selected through an openfile dialog window and reports which file is going to be loaded.")]
        public event EventHandler<FileBrowsedEventArgs> FileBrowsed;
        //[Description("Occurs when the user clicks on the 'Show Lyrics' button. The event handler should display the song lyric in some way.")]
        //public event EventHandler LyricRequired;
        [Description("Occurs when media currently in playing ends.")]
        public event EventHandler<MediaPlayingEndedEventArgs> MediaPlayingEnded;

        //private System.Timers.Timer timer = new System.Timers.Timer(100);

        private bool loopEnabled = false;
        private bool alreadyPlayed = false;
        private bool firstFileLoaded = false;
        private bool continueToPlay = true;

        private int timeToCount = 0;
        private double secondsPlayed = 0;
        private double posTemp = -1;

        private AudioPlayer audio = null;
        private VideoPlayer video = null;

        //public Double Seconds { get { if (audio != null) return trkPosition.Value; else return 0; } }
        /// <summary>
        /// Gets the current Media object previously loaded with LoadMedia method. This field is null
        /// if LoadFile is used instead.
        /// </summary>
        public IMedia CurrentMedia { get; private set; }
        /// <summary>
        /// Gets the path to the media file loaded.
        /// </summary>
        public string CurrentFilename { get; private set; }
        /// <summary>
        /// Returns true if the media file loaded is an audio file.
        /// </summary>
        public bool ContainsAudio { get; private set; }
        /// <summary>
        /// Returns true if the media file is scrobbled.
        /// </summary>
        public bool CurrentMediaScrobbled { get; private set; }
        /// <summary>
        /// Gets or sets the time taking the last song you played through Shauni and filing away info about its 'play count'.
        /// </summary>
        public Int32 TimeToCount
        {
            get
            {
                if (audio != null)
                {
                    var duration = (int)audio.Duration;

                    if (duration == -1 || duration == 0)
                        duration = ((Song)(CurrentMedia)).Duration.HasValue ? (int)((Song)(CurrentMedia)).Duration : 180;

                    return (((int)duration * PercentageToCount) / 100);
                }
                else return 0;
            }
        }

        public Int32 PercentageToCount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the text displayed in the player's label.
        /// </summary>
        public new string Text
        {
            get { return lblCurrentFile.Text; }
            set { lblCurrentFile.Text = value; }
        }

        /// <summary>
        /// Determines whether the playback is going on.
        /// </summary>
        public bool IsPlaying
        {
            get { return this.IsMediaNull ? false : (ContainsAudio ? audio.Playing : video.Playing); }
        }

        /// <summary>
        /// Determines whether the playback is paused.
        /// </summary>
        public bool IsPaused
        {
            get { return this.IsMediaNull ? false : (ContainsAudio ? audio.Paused : video.Paused); }
        }

        /// <summary>
        /// Determines whether the playback is currently halted.
        /// </summary>
        public bool IsStopped
        {
            get { return this.IsMediaNull ? false : (ContainsAudio ? audio.Stopped : video.Stopped); }
        }

        /// <summary>
        /// Gets or sets whether the Loop flag is enabled. When enabled, the current media file being played
        /// will restart when it reaches the end.
        /// </summary>
        public bool LoopEnabled
        {
            get { return loopEnabled; }
            set
            {
                loopEnabled = value;
                btnRepeat.IdleTileIndex = loopEnabled ? 2 : 0;
                btnRepeat.PressedTileIndex = 4;
                this.OnLoopEnabledChanged();
            }
        }

        private bool IsMediaNull
        {
            get { return ContainsAudio ? (audio == null) : (video == null); }
        }

        public PlayerControl()
        {
            InitializeComponent();
            trkPosition.FormatValue = (songPosition) => string.Format("{0:00}:{1:00}", (int)Math.Floor(songPosition / 60), (int)Math.Floor(songPosition) % 60);
            trkVolume.FormatValue = (percentage) => string.Format("{0}%", (int)percentage);
            alreadyPlayed = false;
        }

        /// <summary>
        /// Loads a Song object into the player. Playback won't start until Play is invoked.
        /// </summary>
        public void LoadMedia(IMedia media)
        {
            if (string.IsNullOrEmpty(media.Filename))
            {
                this.Text = "Missing file for " + media.Name.ToProperCase();
                this.CurrentMedia = null;
                this.CurrentFilename = null;
                return;
            }

            if (!this.IsStopped)
                if (!this.IsPlaying)
                    this.LoadFile(media.Filename, false);

            this.CurrentMedia = media;
            this.CurrentMediaScrobbled = false;
            this.secondsPlayed = 0;
            posTemp = -1;
            alreadyPlayed = false;
            this.Text = media.Name.ToProperCase();
            if (((IDurationable)media).Duration != null)
            if (Properties.Settings.Default.VisibleMainTime)
            {
                this.UpdateTiming("00:00 / " + Utility.ParseDuration((int)((IDurationable)media).Duration), 72, null);
            }
        }

        public void SetCurrentTime(string current)
        {
            string text = this.lblTrackPos.Text;
            text = text.Remove(0, 5);
            text = text.Insert(0, current);

            this.lblTrackPos.Text = text;
        }

        /// <summary>
        /// Sets the control that serves as video container.
        /// </summary>
        public void SetVideoContainer(Control container)
        {
            if (this.IsMediaNull || ContainsAudio)
                return;
            video.Owner = container;
        }

        /// <summary>
        /// Loads a media file directly from its persistent storage.
        /// </summary>
        /// <param name="showName">If true, the file name will be showed on the player's label.</param>
        public void LoadFile(string filename, bool showName = true)
        {
            try
            {
                string extension = Path.GetExtension(filename).ToLower();
                if (SharedData.AudioFormats.Contains(extension))
                    this.OpenAudioFile(filename);
                else if (SharedData.VideoFormats.Contains(extension))
                    this.OpenVideoFile(filename);
                else
                    throw new ArgumentException(String.Format("The '{0}' file format is not supported.", extension));

                if (showName)
                    this.Text = Path.GetFileNameWithoutExtension(filename).ToProperCase();
                //this.CurrentMedia = null;
                this.CurrentFilename = filename;
            }
            catch (Exception ex)
            {
                if (firstFileLoaded)
                    MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    firstFileLoaded = true;
                    this.LoadFile(filename, showName);
                }
            }
        }

        private void OpenAudioFile(string filename)
        {
            if (File.Exists(filename))
                if (audio == null)
                {
                    audio = AudioPlayer.FromFile(filename);
                    audio.Ending += Audio_Ending;
                }
                else
                    audio.Open(filename);
            else
                if (audio == null)
                {
                    audio = AudioPlayer.FromUrl(new Uri(filename));
                    audio.Ending += Audio_Ending;
                }
                else
                    audio.Open(new Uri(filename));

            ContainsAudio = true;
            trkPosition.Value = 0;
            trkPosition.Minimum = 0;
            trkPosition.Maximum = audio.Duration;
            audio.Volume = (int)((trkVolume.Value - 100) * 30);
        }

        private void OpenVideoFile(string filename)
        {
            if (File.Exists(filename))
                if (video == null)
                {
                    video = VideoPlayer.FromFile(filename);
                    video.Ending += Video_Ending;
                }
                else
                    video.Open(filename);
            else
                if (video == null)
                {
                    video = VideoPlayer.FromUrl(new Uri(filename));
                    video.Ending += Video_Ending;
                }
                else
                    video.Open(new Uri(filename));

            ContainsAudio = false;
            trkPosition.Minimum = 0;
            trkPosition.Maximum = video.Duration;
            trkPosition.Value = 0;
        }

        /// <summary>
        /// If any media file has been loaded with LoadMedia or LoadFile, starts the playback. Fires the PlaybackStarting event.
        /// </summary>
        public void Play()
        {
            this.Play(false);
        }

        public void Play(bool userGenerated)
        {
            InvocationEventArgs e = new InvocationEventArgs(false, userGenerated);
            this.OnPlaybackStarting(e);

            if (e.Cancel || this.IsMediaNull)
                return;

            if (!alreadyPlayed && this.CurrentMedia != null)
                alreadyPlayed = true;

            if (this.ContainsAudio)
            {
                if (!audio.Stopped & !audio.Paused) { this.OpenAudioFile(this.CurrentMedia.Filename); audio.Play(); }

                if (!audio.Playing) audio.Play();
            }
            else
            { if (!video.Playing) video.Play(); }

            this.btnPlay.Enabled = false;
            this.btnPause.Enabled = true;
            this.btnStop.Enabled = true;
            this.timeToCount = this.TimeToCount;
        }

        /// <summary>
        /// If the media file is currently playing, pauses the playback. Fires the PlaybackPausing event.
        /// </summary>
        public void Pause()
        {
            this.Pause(false);
        }

        private void Pause(bool userGenerated)
        {
            InvocationEventArgs e = new InvocationEventArgs(false, userGenerated);
            this.OnPlaybackPausing(e);

            if (e.Cancel || this.IsMediaNull)
                return;

            if (ContainsAudio)
            { if (!audio.Paused) audio.Pause(); }
            else
            { if (!video.Paused) video.Pause(); }


            this.btnPlay.Enabled = true;
            this.btnPause.Enabled = false;
            this.btnStop.Enabled = true;
        }

        /// <summary>
        /// If the media file is currently playing or is paused, stops the playback and returns it to the start. Fires the PlaybackStopping event.
        /// </summary>
        public void Stop()
        {
            this.Stop(false);
        }

        private void Stop(bool userGenerated)
        {
            InvocationEventArgs e = new InvocationEventArgs(false, userGenerated);
            this.OnPlaybackStopping(e);

            if (e.Cancel || this.IsMediaNull)
                return;

            if (ContainsAudio)
            { if (!audio.Stopped) audio.Stop(); }
            else
            { if (!video.Stopped) video.Stop(); }

            this.secondsPlayed = 0;
            posTemp = -1;
            this.btnPlay.Enabled = true;
            this.btnPause.Enabled = false;
            this.btnStop.Enabled = false;
            this.CurrentMediaScrobbled = false;

            this.trkPosition.Value = 0;
        }

        private void Scrobble(double currentPos)
        {
            if (this.secondsPlayed >= this.timeToCount)
            {
                this.CurrentMedia.Counter += 1;

                Song currentSong = SharedData.Database.Song.Where(song => song.Filename == this.CurrentMedia.Filename).FirstOrDefault();

                int artistID = currentSong.ArtistID;

                var match = SharedData.Database.AudioStatistic.Where(stat => stat.ArtistID == artistID);

                var match2 = match.Where(stat => stat.TimeLine.Date.Day == DateTime.Now.Day).FirstOrDefault();

                if (match2 != null)
                    match2.Counter++;
                else
                {
                    SharedData.Database.AudioStatistic.AddValue(1, artistID, SharedData.Database.TimeLine
                        .Where(date => date.Date.Day == DateTime.Now.Day).FirstOrDefault().ID);
                }

                SharedData.Database.SaveChanges();

                this.CurrentMediaScrobbled = true;
            }
        }

        #region Event handlers

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Play(true);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.Pause(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Stop(true);
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            this.LoopEnabled = !this.LoopEnabled;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            this.OnRandomMediaRequired();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.btnBrowse.CurrentTileIndex = 4;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileBrowsedEventArgs fbe = new FileBrowsedEventArgs(openFileDialog.FileName);
                this.OnFileBrowsed(fbe);
                if (fbe.Media != null)
                {
                    this.CurrentMedia = fbe.Media;
                    lblCurrentFile.Text = fbe.Media.Name.ToProperCase();
                    this.CurrentMediaScrobbled = false;
                }

                if (this.IsPlaying)
                    this.Stop();

                this.LoadFile(openFileDialog.FileName, fbe.Media == null);
                this.btnBrowse.CurrentTileIndex = 4;
            }
        }

        /*private void btnShowLyrics_Click(object sender, EventArgs e)
        {
            this.OnLyricRequired();
        }*/

        private void trkVolume_ValueChanged(object sender, EventArgs e)
        {
            if (this.IsMediaNull)
                return;

            if (ContainsAudio)
                audio.Volume = (int)((trkVolume.Value - 100) * 30);
            else
                video.Audio.Volume = (int)((trkVolume.Value - 100) * 30);
        }

        private void tmrPositionUpdate_Tick(object sender, EventArgs e)
        {
            if (this.IsMediaNull || trkPosition.IsThumbMoving)
                return;

            if (ContainsAudio)
            {
                if (!audio.Playing)
                    return;

                if (Properties.Settings.Default.VisibleMainTime)
                    this.SetCurrentTime(Utility.ParseDuration((int)audio.CurrentPosition, "D2"));

                if (posTemp == -1)
                    secondsPlayed = audio.CurrentPosition;
                else
                {
                    secondsPlayed += audio.CurrentPosition - posTemp;
                    posTemp = audio.CurrentPosition;
                }

                double currentPos = audio.CurrentPosition;
                this.trkPosition.Value = currentPos;

                if (!this.CurrentMediaScrobbled && Shauni.Properties.Settings.Default.ScrobblingEnabled)
                    this.Scrobble(currentPos);
            }
            else
            {
                if (!video.Playing)
                    return;

                this.trkPosition.Value = video.CurrentPosition;
            }
        }

        private void trkPosition_ThumbMouseUp(object sender, EventArgs e)
        {
            if (this.IsMediaNull)
                return;

            if (ContainsAudio)
            {
                posTemp = this.trkPosition.Value;
                audio.CurrentPosition = trkPosition.Value;
                if (!audio.Playing) audio.Play();
            }
            else
            {
                video.CurrentPosition = trkPosition.Value;
                if (!video.Playing) video.Play();
            }
        }

        private void Audio_Ending(object sender, EventArgs e)
        {
            if (loopEnabled)
                audio.CurrentPosition = 0;
            else
            {
                MediaPlayingEndedEventArgs mpee = new MediaPlayingEndedEventArgs();
                this.OnMediaPlayingEnded(mpee);
                if (mpee.Media != null)
                {
                    this.CurrentMedia = mpee.Media;
                    this.Text = mpee.Media.Name.ToProperCase();
                    this.CurrentMediaScrobbled = false;
                }

                if (this.IsPlaying)
                    this.Stop();

                this.LoadFile(mpee.Media.Filename, mpee.Media == null);
                if (Properties.Settings.Default.VisibleMainTime)
                {
                    this.UpdateTiming("00:00 / " + Utility.ParseDuration((int)((IDurationable)mpee.Media).Duration, "D2"), 72, null);
                }
                if(continueToPlay)
                    this.Play();
            }
        }

        private void Video_Ending(object sender, EventArgs e)
        {
            if (loopEnabled)
                video.CurrentPosition = 0;
        }

        /*private void PlayLoop()
        {
            audio.Stop();
            audio.Play();

            var timer = new System.Timers.Timer(audio.Duration * 1000);
            timer.Elapsed += (sender, arg) =>
            {
                audio.SeekCurrentPosition(0, Microsoft.DirectX.AudioVideoPlayback.SeekPositionFlags.AbsolutePositioning);
            };
            timer.Start();
        }*/

        #endregion

        #region Event mediators

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            pnlStandardControls.Left = (this.Width - pnlStandardControls.Width) / 2;
        }

        protected void OnPlaybackStarting(InvocationEventArgs e)
        {
            if (PlaybackStarting != null)
                PlaybackStarting(this, e);
        }

        protected void OnPlaybackPausing(InvocationEventArgs e)
        {
            if (PlaybackPausing != null)
                PlaybackPausing(this, e);
        }

        protected void OnPlaybackStopping(InvocationEventArgs e)
        {
            if (PlaybackStopping != null)
                PlaybackStopping(this, e);
        }

        protected void OnLoopEnabledChanged()
        {
            if (LoopEnabledChanged != null) LoopEnabledChanged(this, EventArgs.Empty);
        }

        protected void OnRandomMediaRequired()
        {
            if (RandomMediaRequired != null) RandomMediaRequired(this, EventArgs.Empty);
        }

        protected void OnFileBrowsed(FileBrowsedEventArgs e)
        {
            if (FileBrowsed != null)
                FileBrowsed(this, e);
        }

        /*protected void OnLyricRequired()
        {
            if (LyricRequired != null) LyricRequired(this, EventArgs.Empty);
        }*/

        protected void OnMediaPlayingEnded(MediaPlayingEndedEventArgs e)
        {
            if (MediaPlayingEnded != null)
                MediaPlayingEnded(this, e);
        }

        #endregion

        private void lblTrackPos_Click(object sender, EventArgs e)
        {
            if (this.CurrentMedia != null)
            {
                Properties.Settings.Default.VisibleMainTime = Properties.Settings.Default.VisibleMainTime == true ? false : true;

                if (Properties.Settings.Default.VisibleMainTime)
                    UpdateTiming("00:00 / " + Utility.ParseDuration((int)((IDurationable)this.CurrentMedia).Duration), 72, null);
                else
                    UpdateTiming("", 16, Properties.Resources.sound_grey);
                Properties.Settings.Default.Save();
            }
        }

        private void UpdateTiming(string text, int width, System.Drawing.Image image)
        {
            this.lblTrackPos.Text = text;
            this.lblTrackPos.Size = new System.Drawing.Size(width, 15);
            this.lblTrackPos.Image = image;
        }
    }

    public class InvocationEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Determines whether this event was fired because of an user-interface interaction or a method invocation.
        /// </summary>
        public bool UserGenerated { get; private set; }

        public InvocationEventArgs(bool cancel, bool userGenerated)
            : base(cancel)
        {
            this.UserGenerated = userGenerated;
        }
    }

    public class FileBrowsedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the path to the file beign loaded by the browse dialog.
        /// </summary>
        public string Filename { get; private set; }
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public FileBrowsedEventArgs(string filename)
        {
            this.Filename = filename;
        }
    }

    public class MediaPlayingEndedEventArgs : EventArgs
    {
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public MediaPlayingEndedEventArgs() { }
    }
}
