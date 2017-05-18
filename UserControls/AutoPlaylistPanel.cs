using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Shauni.Database;
using Shauni.Playlist;

namespace Shauni.UserControls
{
    public partial class AutoPlaylistPanel : UserControl
    {
        private TreeNodeComboBox criteria = null, condition = null;
        private TreeNodeTextBox text_Value = null;
        private TreeNode RootNode = null;

        private TreeNode filter = null;

        public AutoPlaylistPanel()
        {
            InitializeComponent();
        }

        private void AutoPlaylistPanel_Load(object sender, EventArgs e)
        {
            this.Initialize();
            this.AddCriteriaNode();

            this.imageList.Images.Add(global::Shauni.Properties.Resources.MailArr);
            this.imageList.Images.Add(global::Shauni.Properties.Resources.Filter);

            this.autoPlaylistTreeView.ImageList = this.imageList;
            this.autoPlaylistTreeView.Nodes[0].ImageIndex = 0;
        }

        private void Initialize()
        {
            ArrayList names = new ArrayList();
            names.AddRange(Enum.GetValues(typeof(FilterType)));

            RootNode = this.autoPlaylistTreeView.Nodes.Find("Root", false).FirstOrDefault();

            RootNode.NodeFont = new Font("Miramonte", 11, FontStyle.Bold);

            criteria = new TreeNodeComboBox("Click here to add a new filter..");
            ComboBox imageCombo = criteria.ComboBox;
            imageCombo.Name = "Criteria";
            imageCombo.Items.AddRange(names.ToArray());
            imageCombo.SelectedIndex = 0;

            condition = new TreeNodeComboBox("Click here to add a new condition..");
            condition.ComboBox.Name = "Condition";

            text_Value = new TreeNodeTextBox("Click here to set a new value..");
            TextBox valueText = text_Value.TextBox;
            text_Value.TextBox.Name = "Value";
        }

        private void AddConditions(String value)
        {
            condition.ComboBox.Items.Clear();

            if (value.Equals("Favourite") | value.Equals("Stars"))
                condition.ComboBox.Items.AddRange(new string[]{ "EqualTo" });
            else
                condition.ComboBox.Items.AddRange(Enum.GetNames(typeof(Comparison)));

            condition.ComboBox.SelectedIndex = 0;
        }

        private void AddValues(String value)
        {
            condition.ComboBox.Items.Clear();

            if (value.Contains("Favourite"))
                condition.ComboBox.Items.AddRange(new object[] { true, false });
            else if (value.Contains("Stars"))
                condition.ComboBox.Items.AddRange(Enumerable.Range(0, 11).Select(x => x / 2f).Cast<object>().ToArray());

            condition.ComboBox.SelectedIndex = 0;
        }

        private void AddCriteriaNode()
        {
            criteria.Text = "Click here to add a new filter..";
            this.autoPlaylistTreeView.Nodes[0].Nodes.Add(criteria);
            this.autoPlaylistTreeView.SelectedNode = criteria;
            this.autoPlaylistTreeView.Select();
        }

        private void autoPlaylistTreeView_ValueModified(object sender, AutoPlaylistTreeView.TreeViewUpdatedEventArgs e)
        {
            string root = e.Root;
            string value = e.Value;

            switch (root)
            {
                case "Criteria":
                    {
                        filter = RootNode.Nodes.Add("Filter: " + value + "; ");
                        filter.NodeFont = new Font("Miramonte", 9, FontStyle.Underline);
                        filter.ImageIndex = 1;
                        filter.SelectedImageIndex = 1;
                        filter.Name = "Filter";
                        this.AddConditions(value);
                        condition.Text = "Click here to add a new condition..";
                        filter.Nodes.Add(condition);
                        this.autoPlaylistTreeView.SelectedNode = condition;

                        this.autoPlaylistTreeView.Nodes.Remove(criteria);
                    } break;
                case "Condition":
                    {
                        this.autoPlaylistTreeView.Nodes.Remove(condition);
                        double res;
                        if (value == "True" | value == "False" | Double.TryParse(value, out res))
                        {
                            filter.Text += " Value: " + value + "; ";
                            this.AddCriteriaNode();
                            break;
                        }
                        else
                            filter.Text += " Condition: " + value + "; ";

                        if (!filter.Text.Contains("Favourite") & !filter.Text.Contains("Stars"))
                        {
                            filter.Nodes.Add(text_Value);
                            this.autoPlaylistTreeView.SelectedNode = text_Value;
                        }
                        else
                        {
                            this.AddValues(filter.Text);
                            filter.Nodes.Add(condition);
                            this.autoPlaylistTreeView.SelectedNode = condition;
                        }
                    } break;
                case "Value":
                    {
                        filter.Text += " Value: " + value;
                        this.autoPlaylistTreeView.Nodes.Remove(text_Value);

                        this.AddCriteriaNode();
                    } break;
            }

            this.autoPlaylistTreeView.Select();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this.autoPlaylistTreeView.SelectedNode.Remove();
            this.condition.ComboBox.Visible = false;
            this.text_Value.TextBox.Visible = false;

            if (RootNode.Nodes.Count == 0 || !RootNode.Nodes.Contains(criteria))
                this.AddCriteriaNode();
        }

        private void autoPlaylistTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "Root")
                this.BtnRemove.Enabled = false;
            else
                this.BtnRemove.Enabled = true;
        }

        private void autoPlaylistTreeView_Leave(object sender, EventArgs e)
        {
            this.BtnRemove.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.autoPlaylistTreeView.Serialize(@"F:\prova.xml");

            TreeNodeComboBox newFilter = this.autoPlaylistTreeView.Nodes[0].Nodes[0] as TreeNodeComboBox;

            this.autoPlaylistTreeView.Nodes.Clear();
            var nodes = this.autoPlaylistTreeView.Deserialize(@"F:\prova.xml");
            this.RootNode = nodes[0];
            this.autoPlaylistTreeView.Nodes.Add(RootNode);

            nodes.Skip(1).ToList().ForEach(node => {
                node.NodeFont = new Font("Miramonte", 9, FontStyle.Underline);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                RootNode.Nodes.Add(node);
            });

            this.RootNode.Nodes.Add(newFilter);

            this.autoPlaylistTreeView.ExpandAll();

            /*TreeNode c = new TreeNode("Mino");

            this.autoPlaylistTreeView.Nodes.Add(c);*/

            /*if (this.text_Value.Text.Length == 0)
            {
                MessageBox.Show("First you need to named your automatic playlist.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.autoPlaylistTreeView.Serialize(@"C:\prova.xml");*/
        }

        private void tbName_Click(object sender, EventArgs e)
        {
            this.tbName.Font = new Font(this.tbName.Font.FontFamily.Name, 10, FontStyle.Regular);
            if (this.tbName.Text.Equals("Write the name of your Automatic Playlist..."))
                this.tbName.Clear();
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            if (this.tbName.Text.Length == 0)
            {
                this.tbName.Font = new Font(this.tbName.Font.FontFamily.Name, 9, FontStyle.Italic);
                tbName.Text = "Write the name of your Automatic Playlist...";
            }
        }
    }
}
