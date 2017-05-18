using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using Shauni.Playlist;
using Shauni.Database;

namespace Shauni.UserControls
{
    public class AutoPlaylistTreeView : TreeView
    {
        [Description("Occurs after a value of the node is modified.")]
        public event EventHandler<TreeViewUpdatedEventArgs> ValueModified;

        private TreeNodeComboBox m_CurrentNode = null;
        private TreeNodeTextBox textbox_node = null;
        private XmlTextWriter writer = null;

        public AutoPlaylistTreeView()
            : base() { }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is TreeNodeComboBox)
            {
                this.m_CurrentNode = e.Node as TreeNodeComboBox;

                this.Controls.Add(this.m_CurrentNode.ComboBox);

                this.m_CurrentNode.ComboBox.SetBounds(
                    this.m_CurrentNode.Bounds.X - 1,
                    this.m_CurrentNode.Bounds.Y - 2,
                    this.m_CurrentNode.Bounds.Width * 2,
                    this.m_CurrentNode.Bounds.Height);

                this.m_CurrentNode.ComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);
                this.m_CurrentNode.ComboBox.Show();
                this.m_CurrentNode.ComboBox.DroppedDown = true;
            }
            else if (e.Node is TreeNodeTextBox)
            {
                this.textbox_node = (TreeNodeTextBox)e.Node;
                this.Controls.Add(this.textbox_node.TextBox);

                this.textbox_node.TextBox.SetBounds(
                    this.textbox_node.Bounds.X - 1,
                    this.textbox_node.Bounds.Y - 2,
                    this.textbox_node.Bounds.Width,
                    this.textbox_node.Bounds.Height);

                this.textbox_node.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                this.textbox_node.TextBox.Show();
                SendKeys.Send("{TAB}");
            }

            base.OnNodeMouseClick(e);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                String value = string.Empty;
                String root = string.Empty;
                if (this.textbox_node != null)
                {
                    value = this.textbox_node.TextBox.Text;
                    root = this.textbox_node.TextBox.Name;
                }

                this.HideTextBox();

                TreeViewUpdatedEventArgs fbe = new TreeViewUpdatedEventArgs(value, root);
                this.OnValueModified(fbe);
            }
        }
        
        public class TreeViewUpdatedEventArgs : EventArgs
        {
            public string Value { get; private set; }

            public string Root { get; private set; }

            public TreeViewUpdatedEventArgs(string value, string root)
            {
                this.Value = value;
                this.Root = root;
            }
        }

        protected void OnValueModified(TreeViewUpdatedEventArgs e)
        {
            if (ValueModified != null)
                ValueModified(this, e);
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            String value = string.Empty, root = string.Empty;

            if(this.m_CurrentNode != null)
            {
                value = this.m_CurrentNode.ComboBox.SelectedItem.ToString();
                root = this.m_CurrentNode.ComboBox.Name;
            }

            this.HideComboBox();

            TreeViewUpdatedEventArgs fbe = new TreeViewUpdatedEventArgs(value, root);
            this.OnValueModified(fbe);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HideComboBox();
            base.OnMouseWheel(e);
        }

        private void HideComboBox()
        {
            if (this.m_CurrentNode != null)
            {
                this.m_CurrentNode.ComboBox.SelectedValueChanged -= ComboBox_SelectedValueChanged;

                this.m_CurrentNode.Text = this.m_CurrentNode.ComboBox.Text;
                this.m_CurrentNode.ComboBox.Hide();
                this.m_CurrentNode.ComboBox.DroppedDown = false;

                this.Controls.Remove(this.m_CurrentNode.ComboBox);

                this.m_CurrentNode = null;
            }
        }

        private void HideTextBox()
        {
            if (this.textbox_node != null)
            {
                this.textbox_node.TextBox.KeyPress -= TextBox_KeyPress;
                this.textbox_node.Text = this.textbox_node.Text;
                this.textbox_node.TextBox.Hide();

                this.Controls.Remove(this.textbox_node.TextBox);

                this.textbox_node = null;
            }
        }

        public String[] Serialize(String filename)
        {
            return this.Serialize(filename, n => n.ToString());
        }

        public String[] Serialize(String filename, Func<TreeNode, String> nodeToString)
        {
            writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("AutomaticPlaylist");
            writer.WriteAttributeString("name", System.IO.Path.GetFileNameWithoutExtension(filename));

            var doc = this.BuildNodes();

            writer.WriteEndElement();
            writer.Close();

            return doc;
        }

        /*private String[] BuildNodes(AutoPlaylist<Song> autoPlaylist)
        {
            int nodesCount = this.Nodes[0].Nodes.Count - 1;
            string[] filters = new string[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                TreeNode node = this.Nodes[0].Nodes[i];
                if (string.IsNullOrWhiteSpace(node.Name))
                    break;

                var keys = this.ParseFilter(node.Text);

                //Filter<Song> filter = new Filter<Song>();
                //filter.Parse(keys[0], keys[1], keys[2]);
                //Filter: Title; Condition: GreatherThan; Value: S
                //autoPlaylist.FilterMap.Add(filter);

                if (node.Nodes.Count > 0)
                    this.BuildNodes(autoPlaylist);

                writer.WriteEndElement();
            }

            return filters;
        }*/

        private String[] BuildNodes()
        {
            int nodesCount = this.Nodes[0].Nodes.Count - 1;
            string[] filters = new string[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                TreeNode node = this.Nodes[0].Nodes[i];
                if (string.IsNullOrWhiteSpace(node.Name))
                    break;

                writer.WriteStartElement(node.Name);
                filters[i] = node.Text;

                this.ParseFilter(node.Text);

                if (node.Nodes.Count > 0)
                    this.BuildNodes();

                writer.WriteEndElement();
            }

            return filters;
        }

        private string[] ParseFilter(String text)
        {
            string[] keys = text.Split(new string[] { "Filter: ", "Condition: ", "Value: " }, 3, StringSplitOptions.RemoveEmptyEntries);

            keys[0] = keys[0].Replace("; ", "").Trim();
            keys[1] = keys[1].Replace("; ", "").Trim();

            return keys;
        }

        /*private void ParseFilter(String text)
        {
            string[] keys = text.Split(new string[] { "Filter: ", "Condition: ", "Value: " }, 3, StringSplitOptions.RemoveEmptyEntries);

            writer.WriteAttributeString("name", keys[0].Replace("; ", "").Trim());
            writer.WriteAttributeString("condition", keys[1].Replace("; ", "").Trim());
            writer.WriteString(keys[2]);
        }*/

        public List<TreeNode> Deserialize(String filename)
        {
            return Deserialize(filename
                , str => (TreeNode)Convert.ChangeType(str, typeof(TreeNode)));
        }

        public List<TreeNode> Deserialize(String filename, Func<String, TreeNode> TreeNode)
        {
            XmlReader reader = XmlReader.Create(filename);
            List<TreeNode> treeView = new List<TreeNode>();

            treeView.Add(new TreeNode("Create an automatic list that includes the following:") { Name = "Root",
                NodeFont = new System.Drawing.Font("Miramonte", 11, System.Drawing.FontStyle.Bold)});
            try
            {
                reader.ReadToFollowing("Filter");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    TreeNode newNode = new TreeNode();
                    //reader.MoveToAttribute(0);
                    newNode.Text = "Filter: " + reader.Value;
                    reader.MoveToAttribute(1);
                    newNode.Text += "; Condition: " + reader.Value + "; Value: ";
                    newNode.Text += reader.ReadString();

                    treeView.Add(newNode);
                }
            }
            catch
            {
                throw new ArgumentException("Some of the data in the graph are invalid or corrupted.");
            }
            finally
            {
                reader.Close();
            }

            return treeView;
        }
    }
}
