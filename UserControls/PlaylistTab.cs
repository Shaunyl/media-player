using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Shauni.Forms;
using Shauni.Database;
using Shauni.Playlist;
using Shauni.Properties;
using Shauni.Graphic;

namespace Shauni.UserControls
{
    public partial class PlaylistTab : UserControl
    {
        private List<IPlaylist<Song>> savedPlaylists;
        private IPlaylist<Song> iPlaylist;

        [Description("Occurs after an item of the tree view is selected through the mouse interaction and reports which playlist is going to be loaded into the media list box.")]
        public event EventHandler<PlaylistSelectedEventArgs> PlaylistSelected;
        [Description("Occurs after an item of the tree view is imported through the mouse interaction and reports which playlist is going to be imported into the media list box.")]
        public event EventHandler<PlaylistImportedEventArgs> PlaylistImported;
        [Description("Occurs after a media contained in a playlist is loaded through the mouse interaction and reports which media is going to be loaded.")]
        public event EventHandler<PlaylistMediaLoadedEventArgs> PlaylistMediaLoaded;
        [Description("Occurs after the main node of the playlist treeview is clicked.")]
        public event EventHandler PlaylistNodeSelected;
        [Description("Occurs after the allow drop property of the media list box changes.")]
        public event EventHandler<AllowDropChangedEventArgs> AllowDropChanged;

        public IPlaylist<Song> CurrentPlaylist
        {
            get { return iPlaylist; }
            set
            {
                if (iPlaylist != null)
                    iPlaylist.PlaylistSaved -= iPlaylist_PlaylistSaved;

                if (value != null)
                {
                    iPlaylist = value;
                    iPlaylist.PlaylistSaved += new EventHandler(iPlaylist_PlaylistSaved);
                }
                else
                    iPlaylist = null;
            }
        }

        public bool SaveButtonEnabled { get { return this.saveBtn.Enabled; }
            set { this.saveBtn.Enabled = value; }
        }

        public PlaylistTab()
        {
            InitializeComponent();
            this.BuildToolStrip();
        }

        private void BuildToolStrip()
        {
            this.cntMnStrpAutomaticPlaylist.Renderer = new ToolStripOwnRenderer();
            this.cntMnStrpMain.Renderer = new ToolStripOwnRenderer();
            this.cntMnStrpSimplePlaylist.Renderer = new ToolStripOwnRenderer();
        }

        private void SetLabel()
        {
            this.lblPlaylistName.Text = "'" + this.CurrentPlaylist.Name + "' saved successfully.";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.CurrentPlaylist.SaveToFile(Paths.PlaylistFolder);
            this.saveBtn.Enabled = false;
        }

        private void playlistTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string playlistName = this.playlistTextBox.Text;
                if (playlistName.Length > 0)
                {
                    this.CurrentPlaylist = new SimplePlaylist<Song>(playlistName, null);

                    if (!savedPlaylists.Contains(this.CurrentPlaylist))
                        this.savedPlaylists.Add(this.CurrentPlaylist);

                    var node = this.treeView.Nodes["NodePlaylist"].Nodes.Add(CurrentPlaylist.Name);
                    this.playlistTextBox.Enabled = false;

                    AllowDropChangedEventArgs ea = new AllowDropChangedEventArgs(true);
                    this.OnAllowDropChanged(ea);

                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;

                    this.treeView.SelectedNode = node;
                    this.treeView.Select();
                }
            }
        }

        private void treeView_MouseUp(object sender, MouseEventArgs e)
        {
            var treeNode = treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);

            if (treeNode == null)
                return;

            if (e.Button == MouseButtons.Right)
            {
                if (treeNode != null)
                {
                    if (treeNode == this.treeView.Nodes["NodePlaylist"])
                        this.cntMnStrpMain.Show(treeView, e.Location);
                    else
                    {
                        var playlist = savedPlaylists.Where(m => m.Name == treeNode.Text).FirstOrDefault();

                        if (playlist.GetType() == typeof(AutoPlaylist<Song>))
                            this.cntMnStrpAutomaticPlaylist.Show(treeView, e.Location);
                        else
                            this.cntMnStrpSimplePlaylist.Show(treeView, e.Location);
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (treeNode != this.treeView.Nodes["NodePlaylist"])
                {
                    IPlaylist<Song> playlist = savedPlaylists.Where(m => m.Name == treeNode.Text).FirstOrDefault();

                    if (playlist != null)
                        this.CurrentPlaylist = playlist;
                    else
                        playlist = this.CurrentPlaylist;

                    if (playlist == null)
                        return;

                    PlaylistSelectedEventArgs ple = new PlaylistSelectedEventArgs(playlist.Name);
                    this.OnPlaylistSelected(ple);

                    PlaylistMediaLoadedEventArgs pmbe = new PlaylistMediaLoadedEventArgs();

                    if (ple != null)
                    {
                        foreach (IMedia path in playlist.Media)
                            if (SharedData.AudioFormats.Union(SharedData.VideoFormats).Contains(System.IO.Path.GetExtension(path.Filename)))
                            {
                                var targetSong = SharedData.Database.Song.Where(song => song.Filename == path.Filename).FirstOrDefault();

                                pmbe.Media = targetSong != null ? targetSong : SharedData.Id3SongCreator.CreateFromFile(path.Filename);

                                this.OnPlaylistMediaLoaded(pmbe);
                            }
                    }
                }
                else
                {
                    EventArgs ea = new EventArgs();
                    this.OnPlaylistNodeSelected(ea);
                }
            }
        }

        private void PlaylistTab_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.treeView.Nodes["NodePlaylist"].Nodes.Clear();
                this.imageList.Images.Clear();
                this.lblStatus.Visible = false;
                return;
            }
            else
            {
                if (System.IO.Directory.Exists(Paths.PlaylistFolder))
                    savedPlaylists = SimplePlaylist<Song>.LoadFromDirectory(Paths.PlaylistFolder).ToList();

                int count = 0;

                if (savedPlaylists != null)
                {
                    this.imageList.Images.Add(Resources.MailArr);
                    this.imageList.Images.Add(Resources.SimplePl);
                    this.imageList.Images.Add(Resources.AutoPlaylist);

                    this.treeView.ImageList = this.imageList;
                    this.treeView.Nodes["NodePlaylist"].ImageIndex = 0;

                    foreach (var playlist in savedPlaylists)
                    {
                        var node = this.treeView.Nodes["NodePlaylist"].Nodes.Add(playlist.Name);
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                    }
                    count = savedPlaylists.Count;
                }

                if (System.IO.Directory.Exists(Paths.AutomaticPlaylistFolder))
                    savedPlaylists.AddRange(AutoPlaylist<Song>.LoadFromDirectory(Paths.AutomaticPlaylistFolder));

                if (savedPlaylists != null)
                {

                    for (int i = count; i < savedPlaylists.Count; i++)
                    {
                        var node = this.treeView.Nodes["NodePlaylist"].Nodes.Add(savedPlaylists[i].Name);
                        node.ImageIndex = 2;
                        node.SelectedImageIndex = 2;
                    }
                }

                this.treeView.SelectedNode = this.treeView.Nodes["NodePlaylist"];
                this.treeView.Select();
                this.treeView.ExpandAll();
            }
        }

        private void SimplePlaylistTlStrpMnItm_Click(object sender, EventArgs e)
        {
            this.playlistTextBox.Visible = true;
            this.playlistTextBox.Text = this.writePlaylistName;
            this.playlistTextBox.Focus();
            this.playlistTextBox.SelectAll();
            this.writePlaylistMoment = true;
        }

        private bool writePlaylistMoment = false;

        protected void OnAllowDropChanged(AllowDropChangedEventArgs e)
        {
            if (AllowDropChanged != null)
                AllowDropChanged(this, e);
        }

        protected void OnPlaylistNodeSelected(EventArgs e)
        {
            if (PlaylistNodeSelected != null)
                PlaylistNodeSelected(this, e);
        }

        protected void OnPlaylistSelected(PlaylistSelectedEventArgs e)
        {
            if (PlaylistSelected != null)
                PlaylistSelected(this, e);
        }

        protected void OnPlaylistImported(PlaylistImportedEventArgs e)
        {
            if (PlaylistImported != null)
                PlaylistImported(this, e);
        }

        protected void OnPlaylistMediaLoaded(PlaylistMediaLoadedEventArgs e)
        {
            if (PlaylistMediaLoaded != null)
                PlaylistMediaLoaded(this, e);
        }

        private void AutoPlaylistTlStrpMnItm_Click(object sender, EventArgs e)
        {
            AutoPlaylistEditor ape = new AutoPlaylistEditor();
            ape.ShowDialog();
        }

        private void iPlaylist_PlaylistSaved(object sender, EventArgs e)
        {
            this.Invoke(new Action(SetLabel));
            //SharedData.Logger.Append("The " + CurrentPlaylist.Type + " '" + CurrentPlaylist.Name + "' has been saved successfully.");
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var playlist = savedPlaylists.Where(m => m.Name == treeView.SelectedNode.Text).FirstOrDefault();

            PlaylistImportedEventArgs ple = new PlaylistImportedEventArgs(playlist, playlist.Name);
            this.OnPlaylistImported(ple);

            this.lblStatus.Text = "The playlist '" + playlist.Name + "' has been imported successfully!";
            this.lblStatus.Visible = true;
        }

        public void Translate(System.Resources.ResourceManager resourceManager, System.Globalization.CultureInfo culture)
        {
            this.SimplePlaylistTlStrpMnItm.Text = resourceManager.GetString("SimplePlaylistTlStrpMnItm.Text", culture);
            this.AutoPlaylistTlStrpMnItm.Text = resourceManager.GetString("AutoPlaylistTlStrpMnItm.Text", culture);
            this.saveToFileToolStripMenuItem.Text = resourceManager.GetString("saveToFileToolStripMenuItem.Text", culture);

            this.importToolStripMenuItem.Text = resourceManager.GetString("importToolStripMenuItem.Text", culture);
            this.renameToolStripMenuItem.Text = resourceManager.GetString("renameToolStripMenuItem.Text", culture);
            this.deleteToolStripMenuItem.Text = resourceManager.GetString("deleteToolStripMenuItem.Text", culture);
            this.writePlaylistName = resourceManager.GetString("writePlaylistName", culture);

            this.saveBtn.Text = resourceManager.GetString("saveBtn.Text", culture);
            this.playlistTextBox.Text = resourceManager.GetString("saveBtn.Text", culture);
        }

        private String writePlaylistName = "Type the name of your playlist";

        private void playlistTextBox_Leave(object sender, EventArgs e)
        {
            if (this.writePlaylistMoment)
                this.playlistTextBox.Hide();
        }
    }

    public class PlaylistImportedEventArgs : PlaylistSelectedEventArgs
    {
        /// <summary>
        /// Allows the caller to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IPlaylist<Song> Playlist { get; private set; }

        public PlaylistImportedEventArgs(IPlaylist<Song> playlist, string name)
            : base(name)
        {
            this.Playlist = playlist;
        }
    }

    public class PlaylistSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the path to the file beign loaded by the browse dialog.
        /// </summary>
        public string Name { get; private set; }

        public PlaylistSelectedEventArgs(string name)
        {
            this.Name = name;
        }
    }

    public class PlaylistMediaLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the path to the file beign loaded by the browse dialog.
        /// </summary>
        public IMedia Media { get; set; }

        public PlaylistMediaLoadedEventArgs() { }
    }

    public class AllowDropChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the path to the file beign loaded by the browse dialog.
        /// </summary>
        public bool AllowDrop { get; private set; }

        public AllowDropChangedEventArgs(bool allowDrop)
        {
            this.AllowDrop = allowDrop;
        }
    }
}