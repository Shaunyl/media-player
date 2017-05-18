using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Shauni.UserControls
{
    [Serializable]
    public class TreeNodeTextBox : TreeNode
    {
        public TreeNodeTextBox()
            : base() { }

        public TreeNodeTextBox(string text)
            : base(text) { }

        private TextBox m_TextBox = new TextBox();

        public TextBox TextBox
        {
            get { return this.m_TextBox; }
            set { this.m_TextBox = value; }
        }
    }
}
