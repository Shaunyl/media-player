//#define DEBUG

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;

using Shauni.UserControls;
using Shauni.Database;
using Shauni.Playlist;
using Shauni.Properties;
using Shauni.Learning;
using Shauni.Services;
using Shauni.Graphic;
using Shauni;

using Maths;
using Maths.Graphs;
using Maths.Learning;

namespace Shauni.Forms
{
    public partial class MainForm : Form
    {
        internal PlayerControl PlayerControl { get { return this.playerControl; } }

        private LearningContext learning = new LearningContext();
        private SynchronizationContext context;
        private IconPackManager iconPackManager = null;
        private KeyBoardHook hook = null;
        private BusinessLogicLayer bal = null;
        private Cache<string, byte[]> cacheCovers = new Cache<string, byte[]>();
        private int currentMediaSelectedIndex = -1;

        public MainForm()
            : base()
        {

#if DEBUG
            Stopwatch stop = new Stopwatch();
            stop.Start();
#endif

            InitializeComponent();

            //SharedData.Logger.Append("New instance started.", 0);

            this.playerControl.PercentageToCount = Shauni.Properties.Settings.Default.TimeToCount;
            this.iconPackManager = new IconPackManager(this.mainToolStrip);

            this.LoadSatelliteAssembly();
            this.BuildToolStrip();

            if (Settings.Default.IconPackName.Length > 0)
                iconPackManager.LoadIconPack(Settings.Default.IconPackName);

            if (Settings.Default.PluginsEnabled)
                Utility.LoadPlugins(this);

#if DEBUG
            stop.Stop();
            var lon = stop.ElapsedMilliseconds;
            stop = null;
#endif
            bal = new BusinessLogicLayer();

           /* SharedData.Database.Genre.UpdateFromEnum(typeof(Tagger.MusicalGenres));
            SharedData.Database.SaveChanges();*/

           /* string bestGenre = bal.GetBestGenre();

            SharedData.EchoNestManager.UpdateTestSetByGenre(bestGenre);*/
            //SharedData.EchoNestManager.UpdateTestSetFromUserDemand();

            //SharedData.Database.Genre.UpdateFromEnum(typeof(Tagger.MusicalGenres));
            //SharedData.Database.SaveChanges();
            //SharedData.EchoNestManager.FindRandomly(EchoNest.Song.SongBucket.AudioSummary);
        }

        private void LoadSatelliteAssembly()
        {
            ResourceManager resourceManager = new ResourceManager("Shauni.Languages.Culture", typeof(MainForm).Assembly);
            CultureInfo culture = Utility.DetectLanguage(true); //bag not the arg please..

            if (resourceManager.GetResourceSet(culture, true, false) == null)
            {
                SharedData.Logger.Append("The culture " + culture.ToString() + " was not found. Will be loaded the English language.", 1);
                return;
            }

            string value = Settings.Default.AutoLangDetection ? "detected." : "loaded.";
            SharedData.Logger.Append("The language " + culture.EnglishName + " has been " + value, 0);

            this.Translate(resourceManager, culture);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            this.IntializeData();
            this.LoadPlaylist();
            this.RegisterHotKey();

            this.SelectFlagImageOnMenuVoice();

            context = SynchronizationContext.Current;
        }

        private void RegisterHotKey()
        {
            this.hook = new KeyBoardHook();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(Shauni.ModifierKeys.None, Keys.MediaPlayPause);
            hook.RegisterHotKey(Shauni.ModifierKeys.None, Keys.MediaNextTrack);
            hook.RegisterHotKey(Shauni.ModifierKeys.None, Keys.MediaPreviousTrack);
            hook.RegisterHotKey(Shauni.ModifierKeys.None, Keys.MediaStop);
        }

        private void UnregisterHotKey()
        {
            this.hook.Dispose();
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 177: // previous
                    {
                        this.PlayPreviousMedia();
                    } break;
                case 176: // next
                    {
                        this.PlayNextMedia();
                    } break;
                case 178: // stop
                    {
                        if (playerControl.IsPlaying)
                            playerControl.Stop();
                    } break;
                case 179: // play/pause
                    {
                        if (playerControl.IsPlaying)
                            playerControl.Pause();
                        else if (playerControl.IsPaused)
                            playerControl.Play(true);
                    } break;
            }
        }

        private void IntializeData()
        {
            SharedData.Database.TimeLine.FindByDate(DateTime.Now);
            SharedData.Database.SaveChanges();
        }

        private void LoadPlaylist()
        {
            SimplePlaylist<Song> simpleplaylist = SimplePlaylist<Song>.LoadFromFile(Paths.CurrentPlaylist + "currentPLaudio.txt");
            var mediaList = simpleplaylist.Media.ToArray();

            this.audioListBox.BeginUpdate();

            for (int i = 0; i < simpleplaylist.Count; i++)
            {
                Song media = mediaList[i];
                Song song = this.bal.GetSongByFilename(media.Filename);
                this.audioListBox.Items.Add(song);
            }

            this.audioListBox.EndUpdate();

            SimplePlaylist<Picture> simpleplaylist1 = SimplePlaylist<Picture>.LoadFromFile(Paths.CurrentPlaylist + "currentPLpicture.txt");
            this.imageListBox.BeginUpdate();
            var mediaList1 = simpleplaylist1.Media.ToArray();

            for (int i = 0; i < simpleplaylist1.Count; i++)
            {
                var media = mediaList1[i];
                Picture p = SharedData.Database.Picture.FindByFilename(media.Filename);

                if (p != null)
                    this.imageListBox.Items.Add(p);
            }

            this.imageListBox.EndUpdate();

            if (Settings.Default.PlayAtStartUp && audioListBox.Items.Count > 0)
            {
                audioListBox.SelectedIndex = 0;
                this.PlaySelectedMedia();

                Settings.Default.PlayAtStartUp = false;
                Settings.Default.Save();
            }
        }

        private void audioListBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void audioListBox_FileDragged(object sender, FileDraggedEventArgs e)
        {
            foreach (var filename in e.Filenames)
            {
                if (SharedData.AudioFormats.Contains(Path.GetExtension(filename).ToLower()))
                {
                    Song song = this.bal.GetSongByFilename(filename);
                    e.Media = song;

                    if (!this.tsBtnPlaylist.Checked)
                        this.audioListBox.Items.Add(song);
                    else
                    {
                        if (this.playlistTab.CurrentPlaylist != null)
                        {
                            this.playlistTab.SaveButtonEnabled = true;
                            ((SimplePlaylist<Song>)this.playlistTab.CurrentPlaylist).AddMedia(song);
                            this.audioListBox.Items.Insert(1, song);
                        }
                    }
                    SharedData.EchoNestManager.FindBySong(song, EchoNest.Song.SongBucket.AudioSummary);//FetchEchoNest(song);
                }
            }
        }

        public Thread FetchEchoNest(Song song)
        {
            var t = new Thread(() => SharedData.EchoNestManager.FindBySong(song, EchoNest.Song.SongBucket.AudioSummary));
            t.IsBackground = true;
            t.Start();
            return t;
        }

        private void imageListBox_DragEnter(object sender, DragEventArgs e)
        {
            this.audioListBox_DragEnter(sender, e);
        }

        private void imageListBox_FileDragged(object sender, FileDraggedEventArgs e)
        {
            var count = this.imageListBox.Items.Count;

            if (e.Filenames == null) return;

            foreach (var filename in e.Filenames)
            {
                if (SharedData.ImageFormats.Contains(Path.GetExtension(filename).ToLower()))
                {
                    Picture picture = SharedData.Database.Picture.FindByName(Path.GetFileNameWithoutExtension(filename));
                    picture.Filename = filename;

                    SharedData.Database.SaveChanges();

                    if (!this.tsBtnPlaylist.Checked)
                        this.imageListBox.Items.Add(picture);
                }
            }
        }

        private void audioListBox_ItemDoubleClicked(object sender, ItemDoubleClickedEventArgs e)
        {
            int index = audioListBox.IndexFromPoint(e.X, e.Y);

            if (index != -1)
                this.PlaySelectedMedia();
        }

        private IMedia UpdateMediaInformation(IMedia media)
        {
            this.mediaInfo.StarsRate = media.Stars != null ? Convert.ToSingle(media.Stars) : 0;
            this.mediaInfo.FavouriteRate = media.Favourite != null ? media.Favourite : false;

            if (media is Picture)
            {
                var p = SharedData.Database.Picture.Where(picture => picture.Filename == media.Filename).FirstOrDefault();
                this.mediaInfo.Text = p != null ? p.Name.ToProperCase() : "Unknown";
                return p;
            }
            else if (media is Song)
            {
                var s = SharedData.Database.Song.Where(song => song.Filename == media.Filename).FirstOrDefault();
                this.mediaInfo.Text = s != null ? '-'.Halve(Space.Around, s.Artist.Name.ToProperCase(), s.Name.ToProperCase()) : "Unknown";
                return s;
            }
            else return null;
        }

        private void imageListBox_ItemClicked(object sender, ItemClickedEventArgs e)
        {
            if (e.IsOutSide)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.cmsAudioLBnoitem.Show(this.imageListBox, e.X, e.Y);
                    IQueryable<String> query = SharedData.Database.Picture.Select(s => s.Name);
                    this.fastSearchControl.UpdateSource(query.ToArray(), MediaType.Picture);
                }
            }
            else
            {
                IMedia media = e.Media;
                Picture p = this.UpdateMediaInformation(media) as Picture;

                if (File.Exists(p.Filename))
                    this.mainPictureBox.Image = Image.FromFile(p.Filename);
                else
                {
                    SharedData.Logger.Append("The file at '" + p.Filename + "' doesn't exist.", 1);
                    e.IsItemAlive = false;
                    this.mainPictureBox.Image.Dispose();
                    this.mainPictureBox.Image = Properties.Resources.ShauniLogo;
                }

                this.ShowContextMenuOnItem(e, imageListBox);
            }

            if (this.fastSearchControl.Visible)
                this.fastSearchControl.Visible = false;

            this.currentMediaSelectedIndex = e.CurrentIndex;

            this.imageListBox.Refresh();
        }

        private void audioListBox_ItemClicked(object sender, ItemClickedEventArgs e)
        {
            if (e.IsOutSide)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.cmsAudioLBnoitem.Show(this.audioListBox, e.X, e.Y);
                    IQueryable<String> query = SharedData.Database.Song.Where(s => s.Filename != null).Select(s => s.Artist.Name + " - " + s.Name);
                    this.fastSearchControl.UpdateSource(query.ToArray(), MediaType.Song);
                }
            }
            else
            {
                IMedia media = e.Media;
                Song s = this.UpdateMediaInformation(media) as Song;

                if (this.tsBtnChart.Checked && currentMediaSelectedIndex != audioListBox.SelectedIndex)
                    this.chartTab.VisualizeChart(s);

                if (this.tsBtnTagEditor.Checked && currentMediaSelectedIndex != audioListBox.SelectedIndex)
                    this.taggerTab.Update((IMedia)this.audioListBox.SelectedItem);

                if (this.tsBtnTagLyrics.Checked && currentMediaSelectedIndex != audioListBox.SelectedIndex)
                {
                    this.EnableLoadingCircle(true);
                    if (audioListBox.SelectedItem != null)
                    {
                        Song song = (Song)audioListBox.SelectedItem;
                        DownloadLyric(song);
                    }
                }

                if (Settings.Default.ArtistImageFromInternet)
                    this.ShowCover(media);

                this.ShowContextMenuOnItem(e, audioListBox);
            }

            if (this.fastSearchControl.Visible)
                this.fastSearchControl.Visible = false;

            this.currentMediaSelectedIndex = e.CurrentIndex;

            this.audioListBox.Refresh();
        }

        private void DownloadLyric(Song song)
        {
            /* TEMPORARY
             * */
            /*var ping = new System.Net.NetworkInformation.Ping();

            var result = ping.Send("www.lyricsmania.com");

            if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
                return;*/
            if (song.Lyric == null)
            {
                this.EnableLoadingCircle(true);
                SharedData.LyricsDownloader.FindLyric(song, lyric => FetchLyrics(lyric, song)); //bug if the site is not reacheable
            }
            else
            {
                ParseLyric(song.Artist.Name, song.Name, song.Lyric.Text);
            }
        }

        private void FetchLyrics(String lyric, Song song)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ParseLyric(song.Artist.Name, song.Name, lyric);
                this.EnableLoadingCircle(false);
            });
            Lyric l = CreateLyric(lyric);
            song.Lyric = l;
            Commit();
        }

        private void Commit()
        {
            SharedData.Database.SaveChanges();
        }

        private Lyric CreateLyric(String lyric)
        {
            Lyric text = new Lyric();
            text.ID = SharedData.Database.Lyrics.GetNextID();
            text.Text = lyric;
            return text;
        }

        private void ParseLyric(String artist, String name, String lyric)
        {
            this.lyricsTab.Text = "";
            this.lyricsTab.Text = "\n\n" + artist + "\n" + name + "\n\n\n\n" + lyric + "\n\n";

            this.lyricsTab.UpdateRichTextBoxSelection(0, artist.Length + 2
                , new Font("Segoe UI Mono", 22, FontStyle.Bold), Color.SkyBlue);

            this.lyricsTab.UpdateRichTextBoxSelection(artist.Length + 3, name.Length + 4
                , new Font("Segoe UI Mono", 16, FontStyle.Bold), Color.SkyBlue);
        }

        private void ShowCover(IMedia media)
        {
            try
            {
                string artistName = ((Song)media).Artist.Name;

                if (!cacheCovers.Contains(artistName))
                {
                    this.EnableLoadingCircle(true);
                    SharedData.Downloader.PreferredImageFormat = Shauni.Services.ImageFormat.ExtraExtraLarge;
                    SharedData.Downloader.FindImageByArtist(artistName, bytes => UpdateImage(artistName, bytes));
                }
                else
                    this.mainPictureBox.Image = cacheCovers[artistName].ToImage();
            }
            catch
            {
                return;
            }
        }

        private void UpdateImage(String artist, Byte[] bytes)
        {
            Image image = bytes.ToImage();
            if (image != null)
                this.mainPictureBox.Image = image;

            cacheCovers.Add(artist, bytes);

            this.Invoke(new Action(() => this.EnableLoadingCircle(false)));
        }

        private void EnableLoadingCircle(bool enable)
        {
            this.loadingCircle.Visible = enable;
            this.loadingCircle.Active = enable;
        }

        private void ShowContextMenuOnItem(ItemClickedEventArgs e, ShauniListBox slb)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*if (Settings.Default.LearnAudio)
                    this.Learn(slb, true);
                else
                    this.cmsAudioLBitem.Items["reccomandedToolStripMenuItem"].Text = "Recommended system is disabled...";*/
                
                this.cmsAudioLBitem.Show(slb, e.X, e.Y);
                return;
            }
        }

        /*private void Learn(ShauniListBox slb, bool rebuilt)
        {
            IMedia media = slb.SelectedItem as IMedia;
            if (media == null) return;

            workerThread.Start(media, rebuilt);
            workerThread.LearningDone += new LearningDoneEventhandler(workerThread_LearningDone);
        }

        private void workerThread_LearningDone(object sender, Shauni.LearningDoneEventArgs e)
        {
            //marshal call to UI thread
            context.Post(new SendOrPostCallback(delegate(object state)
            {
                this.cmsAudioLBitem.Items["reccomandedToolStripMenuItem"].Text = e.Prediction;
            }), null);
        }*/

        private void playerControl_MediaPlayingEnded(object sender, MediaPlayingEndedEventArgs e)
        {
            IMedia media = audioListBox.SelectedItem as IMedia;
            ((Song)media).IsPlaying = false;

            if (this.audioListBox.SelectedIndex + 1 > this.audioListBox.Items.Count - 1)
                this.audioListBox.SelectedIndex = 0; //The end is reached.
            else
                this.audioListBox.SelectedIndex += 1;


            media = audioListBox.SelectedItem as IMedia;
            e.Media = media;

            ((Song)(e.Media)).IsPlaying = true;

            this.audioListBox.Refresh();
        }

        private void playerControl_FileBrowsed(object sender, FileBrowsedEventArgs e)
        {
            if (SharedData.AudioFormats.Contains(Path.GetExtension(e.Filename).ToLower()))
            {
                Song song = this.bal.GetSongByFilename(e.Filename);
                this.audioListBox.Items.Add(song);
                e.Media = song;
                SharedData.EchoNestManager.FindBySong(song, EchoNest.Song.SongBucket.AudioSummary);
            }
        }

        private void tsBtnAbout_Click(object sender, EventArgs e)
        {
            this.tsBtnAbout.Checked = true;
            AboutForm aboutform = new AboutForm();
            aboutform.ShowDialog();

            this.tsBtnAbout.Checked = false;
        }

        private void ShowPopup(String type, String message)
        {
            AdvisePopup popup = new AdvisePopup();
            splitContainer.Panel1.Controls.Add(popup);
            popup.SetText(type, message);
            popup.Show();
            popup.Dock = DockStyle.Top;
            popup.BringToFront();
        }

        private void playlistTab_TreeViewItemClicked(object sender, PlaylistSelectedEventArgs e)
        {
            if (!this.audioListBox.Items.Contains(nowPlaying))
                this.audioListBox.Items.Clear();
            else
                this.RemoveMediaUntil(nowPlaying);

            this.audioListBox.Items.Insert(0, e.Name);
        }

        private void playlistTab_PlaylistMediaLoaded(object sender, PlaylistMediaLoadedEventArgs e)
        {
            this.audioListBox.Items.Insert(1, e.Media);
        }

        private void playlistTab_PlaylistNodeSelected(object sender, EventArgs e)
        {
            this.RemoveMediaUntil(nowPlaying);
            this.audioListBox.Items.Insert(0, this.playlistCreationText);
        }

        private void playlistTab_AllowDropChanged(object sender, AllowDropChangedEventArgs e)
        {
            this.audioListBox.AllowDrop = e.AllowDrop;
        }

        private void tsBtnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RemoveMediaUntil(nowPlaying, true);

            new SimplePlaylist<Song>().SavePlaylist("currentPLaudio", this.audioListBox.Items.Cast<Song>().ToArray());
            new SimplePlaylist<Picture>().SavePlaylist("currentPLpicture", this.imageListBox.Items.Cast<Picture>().ToArray());

            this.UnregisterHotKey();
        }

        private void RemoveMediaUntil(String upperBound, bool inclusive = false)
        {
            if (!this.audioListBox.Items.Contains(nowPlaying))
                return;

            var count = this.audioListBox.Items.Count;

            for (int i = 0; i < count; i++)
                if (this.audioListBox.Items[0].ToString() == upperBound)
                    break;
                else
                    this.audioListBox.Items.Remove(this.audioListBox.Items[0]);

            if (inclusive)
                this.audioListBox.Items.Remove(this.audioListBox.Items[0]);
        }

        private void BuildToolStrip()
        {
            ToolStripOwnRenderer renderer = new ToolStripOwnRenderer();
            renderer.Art = true;
            renderer.ArtString = ' '.Halve(Space.Right, Application.ProductName, SharedData.AssemblyVersion, "Alpha");
            this.mainToolStrip.Renderer = renderer;
            renderer.UseCustomToolTips(this.mainToolStrip);
            renderer.ToolTipDelayTime = 0;
            renderer.ToolTipGradientBegin = Color.GhostWhite;
            renderer.ToolTipGradientEnd = Color.Lavender;
            renderer.ToolTipVisibleTime = 3000;

            this.cmsAudioLBnoitem.Renderer = new ToolStripOwnRenderer();
            this.cmsAudioLBitem.Renderer = new ToolStripOwnRenderer();
        }

        private void CheckStripButton(Object sender)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items.OfType<ToolStripButton>())
            {
                if (item == sender) item.Checked = item.Checked == true ? false : true;
                if ((item != null) && (item != sender))
                    item.Checked = false;
            }
        }

        private void HideOtherTabs(Object sender)
        {
            foreach (Control item in this.splitContainer.Panel1.Controls.Cast<Control>().Where(c => c.Visible))
                item.Visible = false;
        }


        private void tsBtnTagEditor_Click(object sender, EventArgs e)
        {
            if (this.tsBtnPlaylist.Checked)
            {
                this.mainPictureBox.Visible = false;
                this.RemoveMediaUntil(nowPlaying, true);
            }

            this.CheckStripButton(sender);
            this.HideOtherTabs(sender);

            if (this.tsBtnTagEditor.Checked)
            {
                this.mainPictureBox.Visible = false;
                this.taggerTab.Visible = true;
            }
            else
            {
                this.mainPictureBox.Visible = true;
                this.taggerTab.Visible = false;
            }

            foreach (ToolStripMenuItem dropItem in this.tssBtnDataSetting.DropDownItems)
            {
                if (dropItem.Checked)
                    dropItem.Checked = false;
            }
        }

        private void tsBtnChart_Click(object sender, EventArgs e)
        {
            if (this.tsBtnPlaylist.Checked)
            {
                this.mainPictureBox.Visible = false;
                this.RemoveMediaUntil(nowPlaying, true);
            }

            this.CheckStripButton(sender);
            this.HideOtherTabs(sender);

            if (this.tsBtnChart.Checked)
            {
                this.mainPictureBox.Visible = false;

                this.chartTab.Visible = true;

                if (audioListBox.SelectedItem != null)
                    this.chartTab.VisualizeChart((Song)audioListBox.SelectedItem);
            }
            else
            {
                this.mainPictureBox.Visible = true;
                this.chartTab.Visible = false;
            }

            foreach (ToolStripMenuItem dropItem in this.tssBtnDataSetting.DropDownItems)
            {
                if (dropItem.Checked)
                    dropItem.Checked = false;
            }
        }

        private void tsBtnPlaylist_Click(object sender, EventArgs e)
        {
            if (this.fastSearchControl.Visible)
                this.fastSearchControl.Visible = false;

            if (this.tsBtnChart.Checked)
                this.mainPictureBox.Visible = false;

            this.CheckStripButton(sender);
            this.HideOtherTabs(sender);

            if (this.tsBtnPlaylist.Checked)
            {
                if (this.audioListBox.Items.Count > 0)
                    this.audioListBox.Items.Insert(0, nowPlaying);

                this.mainPictureBox.Visible = false;
                this.playlistTab.Visible = true;
                this.AllowDrop = false;
                this.audioListBox.Items.Insert(0, this.playlistCreationText);
            }
            else
            {
                this.mainPictureBox.Visible = true;
                this.playlistTab.Visible = false;
                this.RemoveMediaUntil(nowPlaying, true);
            }

            foreach (ToolStripMenuItem dropItem in this.tssBtnDataSetting.DropDownItems)
            {
                if (dropItem.Checked)
                    dropItem.Checked = false;
            }
        }

        private void playlistTab_PlaylistImported(object sender, PlaylistImportedEventArgs e)
        {
            this.audioListBox.Items.Clear();
            this.audioListBox.BeginUpdate();
            //IMedia s = null;
            var mediaList = e.Playlist.Media.ToArray();

            for (int i = 0; i < e.Playlist.Media.Count(); i++)
            {
                var media = mediaList[i];
                Song song = this.bal.GetSongByFilename(media.Filename);
                this.audioListBox.Items.Add(song);
            }

            this.audioListBox.EndUpdate();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image ip = (iconPackManager.IconPack == null) ? Shauni.Properties.Resources.Shauni : iconPackManager.IconPack.Image;

            ToolsForm toolsform = new ToolsForm(ip, this);
            toolsform.UpdateIcons += new UpdateIconsHandler(toolsform_UpdateIcons);
            toolsform.ShowDialog();
        }

        private void toolsform_UpdateIcons(string iconPackName)
        {
            if (iconPackName != "Shauni")
                iconPackManager.LoadIconPack(iconPackName);
            else
            {
                this.tsBtnEsc.Image = global::Shauni.Properties.Resources.Esc;
                this.tsBtnPlaylist.Image = global::Shauni.Properties.Resources.MailArr;
                this.tsBtnTagLyrics.Image = global::Shauni.Properties.Resources.Lyric;
                this.tsBtnTagEditor.Image = global::Shauni.Properties.Resources.Settings;
                this.toolStripSplitButton1.Image = global::Shauni.Properties.Resources.Networkoff;
                this.tsBtnStatistics.Image = global::Shauni.Properties.Resources.Database;
                this.tsBtnLearning.Image = global::Shauni.Properties.Resources.email;
                this.tsBtnChart.Image = global::Shauni.Properties.Resources.Statistics;
                this.tssBtnDataSetting.Image = global::Shauni.Properties.Resources.MyMusic;
                this.tsBtnAbout.Image = global::Shauni.Properties.Resources.Home16;
            }
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationForm configform = new ConfigurationForm(this);
            configform.ShowDialog();

            this.playerControl.PercentageToCount = Settings.Default.TimeToCount;
           // NewConfig n = new NewConfig();
            //n.ShowDialog();


            /*if(Settings.Default.UpdateDTauto)
                this.Learn(audioListBox, true);*/
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchform = new SearchForm();
            searchform.ShowDialog();
        }

        private void fastSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastSearchDialog dialog = new FastSearchDialog();
            dialog.Show();
            /*this.fastSearchControl.Visible = true;
            this.fastSearchControl.BringToFront();
            this.fastSearchControl.Focus();*/
        }

        private void fastSearchControl_FileSearched(object sender, UserControls.MediaSearchedEventArgs e)
        {
            if (e.MediaType == MediaType.Song)
            {
                IMedia media = SharedData.Database.Song.Where(s => s.Artist.Name + " - " + s.Name == e.Media && s.Filename != null).FirstOrDefault();
                if (media != null) this.audioListBox.Items.Add(media);
            }
            else
            {
                IMedia media = SharedData.Database.Picture.Where(s => s.Name == e.Media).FirstOrDefault();
                if (media != null) this.imageListBox.Items.Add(media);
            }

            this.fastSearchControl.Visible = false;
        }

        private void audioListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.audioListBox.Items.Count == 0 || this.audioListBox.SelectedIndex == -1)
                return;

            if (e.KeyCode == Keys.Delete)
                this.audioListBox.Items.RemoveAt(this.audioListBox.SelectedIndex);
        }

        private void imageListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.imageListBox.Items.Count == 0 || this.imageListBox.SelectedIndex == -1)
                return;

            if (e.KeyCode == Keys.Delete)
                this.imageListBox.Items.RemoveAt(this.imageListBox.SelectedIndex);
        }

        private void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguagesForm languagesform = new LanguagesForm();
            languagesform.ShowDialog(this);

            this.SelectFlagImageOnMenuVoice();
        }

        private void SelectFlagImageOnMenuVoice()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.FlagImage))
                this.selectLanguageToolStripMenuItem.Image = System.Convert.FromBase64String(Settings.Default.FlagImage).ToImage();
        }

        private void taggerTab_MediaLoaded(object sender, MediaTagsLoadedEventArgs e)
        {
            e.Media = (IMedia)this.audioListBox.SelectedItem;
        }

        private void Translate(ResourceManager resourceManager, CultureInfo culture)
        {
            this.tsBtnEsc.ToolTipText = resourceManager.GetString("tsBtnEsc.Text", culture);
            this.tsBtnPlaylist.ToolTipText = resourceManager.GetString("tsBtnPlaylist.Text", culture);
            this.tssBtnDataSetting.ToolTipText = resourceManager.GetString("tssBtnDataSetting.Text", culture);
            this.tsBtnChart.ToolTipText = resourceManager.GetString("tsBtnChart.Text", culture);
            this.tsBtnAbout.ToolTipText = resourceManager.GetString("tsBtnAbout.Text", culture);
            this.tsBtnTagEditor.ToolTipText = resourceManager.GetString("tsBtnTagEditor.Text", culture);
            this.fastSearchToolStripMenuItem.Text = resourceManager.GetString("fastSearchToolStripMenuItem.Text", culture);
            this.toolsToolStripMenuItem.Text = resourceManager.GetString("toolsToolStripMenuItem.Text", culture);
            this.configurationToolStripMenuItem.Text = resourceManager.GetString("configurationToolStripMenuItem.Text", culture);
            this.searchToolStripMenuItem.Text = resourceManager.GetString("searchToolStripMenuItem.Text", culture);
            this.selectLanguageToolStripMenuItem.Text = resourceManager.GetString("selectLanguageToolStripMenuItem.Text", culture);

            this.playlistCreationText = resourceManager.GetString("playlistCreationText", culture);
            this.nowPlaying = resourceManager.GetString("nowPlaying", culture);
            this.taggerTab.Translate(resourceManager, culture);
            this.playlistTab.Translate(resourceManager, culture);
        }

        private String playlistCreationText = "Create or edit your personal playlist.";
        private String nowPlaying = "Now playing";

        private void changeListPanel_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.Scrolling == Scrolling.ToTheLeft)
            {
                this.audioListBox.BringToFront();
                lastSelectedPicture = imageListBox.SelectedIndex;

                this.mainPictureBox.Image.Dispose();
                this.mainPictureBox.Image = null;
                this.mainPictureBox.Image = Properties.Resources.ShauniLogo; //BUG
            }
            else
            {
                //this.mainPictureBox.Image = imageListBox.Sel
                if (lastSelectedPicture != -1)
                {
                    this.imageListBox.SelectedIndex = lastSelectedPicture;

                    Picture picture = (Picture)this.imageListBox.SelectedItem;

                    if(mainPictureBox.Image != null)
                        this.mainPictureBox.Image.Dispose();
                    this.mainPictureBox.Image = null;
                    this.mainPictureBox.Image = Image.FromFile(picture.Filename);
                }

                this.imageListBox.BringToFront();
            }
        }

        private int lastSelectedPicture = -1;

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMedia media = audioListBox.SelectedItem as IMedia;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Path.GetDirectoryName(media.Filename);
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    if (SharedData.AudioFormats.Contains(Path.GetExtension(media.Filename)))
                    {
                        Song song = this.bal.GetSongByFilename(media.Filename);
                        this.audioListBox.Items.Add(song);
                    }
                }
            }
        }

        private void PlayPreviousMedia()
        {
            if (playerControl.IsPlaying)
                playerControl.Stop();

            if (this.audioListBox.SelectedIndex == 0)
                this.audioListBox.SelectedIndex = this.audioListBox.Items.Count - 1;
            else
                this.audioListBox.SelectedIndex -= 1;

            this.PlaySelectedMedia();
        }

        private void PlaySelectedMedia()
        {
            IMedia media = this.audioListBox.SelectedItem as IMedia;

            foreach (var m in this.audioListBox.Items)
                ((Song)m).IsPlaying = false;

            if (media == null)
                return;

            this.playerControl.LoadMedia(media);
            this.playerControl.Play(true);
            ((Song)(media)).IsPlaying = true;

            this.audioListBox.Refresh();
        }

        private void PlayNextMedia()
        {
            if (playerControl.IsPlaying)
                playerControl.Stop();

            if (this.audioListBox.SelectedIndex == this.audioListBox.Items.Count - 1)
                this.audioListBox.SelectedIndex = 0;
            else
                this.audioListBox.SelectedIndex += 1;

            this.PlaySelectedMedia();
        }

        private void tsBtnTagLyrics_Click(object sender, EventArgs e)
        {
            if (this.tsBtnPlaylist.Checked)
            {
                this.mainPictureBox.Visible = false;
                this.RemoveMediaUntil(nowPlaying, true);
            }

            this.CheckStripButton(sender);
            this.HideOtherTabs(sender);

            if (this.tsBtnTagLyrics.Checked)
            {
                this.mainPictureBox.Visible = false;
                this.lyricsTab.Visible = true;

                if (audioListBox.SelectedItem != null)
                {
                    Song song = (Song)audioListBox.SelectedItem;
                    DownloadLyric(song);
                }
            }
            else
            {
                this.mainPictureBox.Visible = true;
                this.lyricsTab.Visible = false;
            }

            foreach (ToolStripMenuItem dropItem in this.tssBtnDataSetting.DropDownItems)
            {
                if (dropItem.Checked)
                    dropItem.Checked = false;
            }
        }

        private void Predict(IEnumerable<TrainingSetRecord> data, Song media)
        {
            if (media == null)
            {
                //this.lblSuggestion.Text = "no songs in the local database! Impossible to make predictions.";
                this.EnableLoadingCircle(false);
                return;
            }

            learning.InitializeAlgorithm(data);
            learning.PredictionDone += learning_AlgorithmDone;
            learning.Predict(media);
        }

        private void learning_AlgorithmDone(object sender, PredictionDoneEventArgs e)
        {
            context.Post(new SendOrPostCallback(delegate(object state)
            {
                if (e.Media != null)
                {
                    Song media = ((Song)e.Media);
                    this.ShowInformationPanel('-'.Halve(Space.Around, media.Artist.Name, media.Name));
                    this.EnableLoadingCircle(false);
                    learning.PredictionDone -= learning_AlgorithmDone;
                }
                else
                {
                    this.songss.RemoveAt(random);
                    //Song media = bal.ExtractSongRandomly();
                    if (songss.Count > 0)
                    {
                        random = new Random().Next(songss.Count() - 1);
                        learning.Predict(songss[random]);
                    }
                    else
                    {
                        this.ShowInformationPanel("nothing to advice.");
                        this.EnableLoadingCircle(false);
                        learning.PredictionDone -= learning_AlgorithmDone;
                    }
                }

            }), null);
        }

        private void ShowInformationPanel(string text)
        {
            //this.learningPanel.Visible = true;
            //this.lblSuggestion.Text = text;
        }

        List<Song> songss;// = SharedData.Database.Song.Where(f => f.Filename == null).ToList();
        IEnumerable<TrainingSetRecord> data;

        private void tsBtnLearning_Click(object sender, EventArgs e)
        {
            //this.learningPanel.Visible = false;
            this.EnableLoadingCircle(true);
            //this.learningPanel.Visible = true;

            //SharedData.EchoNestManager.FindRandomly(EchoNest.Song.SongBucket.AudioSummary);

            //Song media = bal.ExtractSongRandomly();

            songss = SharedData.Database.Song.Where(f => f.Filename == null).ToList();
            if (songss.Count == 0)
            {
                ShowInformationPanel("The test set is empty.");
                this.EnableLoadingCircle(false);
                //this.lblLearningMessage.Text = "Error: ";
                return;
            }

            data = bal.ExtractDataForLearning();
            if (data.Count() == 0)
            {
                ShowInformationPanel("There are no songs with audio summary attributes not null in the local database.");
                songss.Clear();
                this.EnableLoadingCircle(false);
                return;
            }

            random = new Random().Next(songss.Count() - 1);
            this.Predict(data, songss[random]);
        }

        int random = 0;

        private void splitContainer_Panel1_Resize(object sender, EventArgs e)
        {

        }
    }
}

//se la varianza è nulla, Bayes da un risultato sbagliato.
//se la categoria è solo una, il risultato è errato.