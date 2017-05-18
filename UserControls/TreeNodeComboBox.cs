using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

using Shauni.Playlist;
using Shauni.Database;

namespace Shauni.UserControls
{
    [Serializable]
    public class TreeNodeComboBox : TreeNode
    {
        public TreeNodeComboBox()
            : base() { }

        public TreeNodeComboBox(string text)
            : base(text) { }

        public TreeNodeComboBox(string text, Filter<IMedia> filter)
            : base(text) { }

        public TreeNodeComboBox(string text, TreeNode[] children)
            : base(text, children) { }

        public TreeNodeComboBox(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        public TreeNodeComboBox(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex) { }

        public TreeNodeComboBox(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children) { }

        private ComboBox m_ComboBox = new ComboBox();

        public ComboBox ComboBox
        {
            get
            {
                this.m_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                return this.m_ComboBox;
            }
            set
            {
                this.m_ComboBox = value;
                this.m_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
