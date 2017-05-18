using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shauni.UserControls
{
    public partial class LyricsTab : UserControl
    {
        /// <summary>
        /// Gets or sets the text displayed in the lyrics panel.
        /// </summary>
        public new string Text
        {
            get { return this.richTextBox.Text; }
            set { richTextBox.Text = value;
            }
        }

        public void UpdateRichTextBoxSelection(int start, int length, Font selectionFont, Color selectiorColor)
        {
            this.richTextBox.Select(start, length);
            this.richTextBox.SelectionFont = selectionFont;
            this.richTextBox.SelectionColor = selectiorColor;
            this.richTextBox.DeselectAll();
        }

        public LyricsTab()
        {
            InitializeComponent();
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}
