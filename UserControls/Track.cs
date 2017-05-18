using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Shauni.UserControls
{
    public partial class Track : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private static int WasValue = 0;

        private double value = 50;
        private double minimum = 0;
        private double maximum = 100;
        private double crucial;
        // previousValue contains the value shown in the tooltip the last time it was updated. 
        // Storing values between frames serves as a performance saver, since refreshing the tooltip
        // every time the control is drawn causes an annoying flickering effect
        private int previousValue;
        private bool thumbMoving = false;

        [Category("Action"), Description("Occurs when the slider is moved.")]
        public event EventHandler ValueChanged;

        public event EventHandler ThumbMouseUp;

        public double Val
        {
            get { return (crucial); }
        }

        public double Minimum
        {
            get
            {
                return (minimum);
            }
            set
            {
                double minimumBackup = minimum;
                minimum = value;
                ShowThumbPos();
            }
        }

        public double Maximum
        {
            get
            {
                return (maximum);
            }
            set
            {
                double maximumBackup = maximum;
                maximum = value;
                ShowThumbPos();
            }
        }

        public double Value
        {
            get
            {
                return (value);
            }
            set
            {
                double valueBackup = this.value;
                if (minimum > maximum)
                {
                    this.value = Math.Max(Math.Min(value, minimum), maximum);
                }
                else
                {
                    this.value = Math.Max(Math.Min(value, maximum), minimum);
                }
                ShowThumbPos();
            }
        }

        public bool IsThumbMoving
        {
            get { return thumbMoving; }
        }

        private bool IsHorizontal
        {
            get { return (this.Width > this.Height); }
        }

        /// <summary>
        /// Contains a reference to a function used to format the numeric value of the slider
        /// into an intelligible string.
        /// </summary>
        public Func<double, string> FormatValue { get; set; }

        public Track()
        {
            InitializeComponent();
        }

        private void TRACK_Load(object sender, EventArgs e)
        {
            if (minimum == 0 && maximum == 0)
            {
                // Set default value
                value = 50;
                if (this.IsHorizontal)
                { minimum = 0; maximum = 100; }
                else
                { minimum = 100; maximum = 0; }
            }
        }

        private void THUMB_MouseDown(object sender, MouseEventArgs e)
        {
            thumbMoving = true;
        }

        private void THUMB_MouseMove(object sender, MouseEventArgs e)
        {
            if (thumbMoving) SetThumbLocation();

            int currentValue = (int)value;
            if (currentValue != previousValue)
            {
                previousValue = currentValue;
                if (this.FormatValue == null)
                    ttVolumeValue.SetToolTip(this, currentValue.ToString());
                else
                    ttVolumeValue.SetToolTip(this, this.FormatValue(currentValue));
            }

            // BUG in Vista: the animation stops while the tooltip is being shown!
            if (CheckOverThumb(e.X, e.Y) == false)
                ttVolumeValue.SetToolTip(this, "");
        }

        private void TRACK_MouseDown(object sender, MouseEventArgs e)
        {
            thumbMoving = true;
            SetThumbLocation();
        }

        private void THUMB_MouseUp(object sender, MouseEventArgs e)
        {
            thumbMoving = false;
            if (ThumbMouseUp != null)
                ThumbMouseUp(this, EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x14: // Erase background
                    Bitmap bmp;
                    Rectangle srceRect;
                    Rectangle destRect;

                    // Create a memory bitmap to use as double buffer
                    Bitmap offScreenBmp = new Bitmap(this.Width, this.Height);

                    using (Graphics g = Graphics.FromImage(offScreenBmp))
                    {
                        if (this.BackgroundImage != null)
                        {
                            bmp = new Bitmap(this.BackgroundImage);
                            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                            destRect = new Rectangle(0, 0, this.Width, this.Height);
                            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                            bmp.Dispose();
                        }
                        else
                        {
                            SolidBrush myBrush = new SolidBrush(this.BackColor);
                            g.FillRectangle(myBrush, 0, 0, this.Width, this.Height);
                            myBrush.Dispose();
                        }

                        /*Pen MIDDLEdark = new Pen(Color.Transparent);
                        Pen LEFTorTOPdark = new Pen(Color.Transparent);
                        Pen RIGHTorBOTTOMdark = new Pen(Color.Transparent);*/

                        Pen LEFTorTOPblue = new Pen(Color.FromArgb(148, 207, 247));
                        Pen MIDDLEblue = new Pen(Color.FromArgb(49, 105, 183));
                        Pen RIGHTorBOTTOMblue = new Pen(Color.FromArgb(127, 175, 237));

                        if (this.IsHorizontal)
                        {
                            int y = ClientRectangle.Height / 2;
                            if (y * 2 < ClientRectangle.Height) y -= 1;

                            if (Minimum > Maximum)
                            {
                                //g.DrawLine(LEFTorTOPdark, new Point(0, y - 1), new Point(blueCursor.Left + blueCursor.Width / 2, y - 1));
                                g.DrawLine(LEFTorTOPblue, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y - 1), new Point(ClientRectangle.Width, y - 1));
                                //g.DrawLine(MIDDLEdark, new Point(0, y), new Point(blueCursor.Left + blueCursor.Width / 2, y));
                                g.DrawLine(MIDDLEblue, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y), new Point(ClientRectangle.Width, y));
                                //g.DrawLine(RIGHTorBOTTOMdark, new Point(0, y + 1), new Point(blueCursor.Left + blueCursor.Width / 2, y + 1));
                                g.DrawLine(RIGHTorBOTTOMblue, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y + 1), new Point(ClientRectangle.Width, y + 1));
                            }
                            else
                            {
                                g.DrawLine(LEFTorTOPblue, new Point(0, y - 1), new Point(blueCursor.Left + blueCursor.Width / 2, y - 1));
                                //g.DrawLine(LEFTorTOPdark, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y - 1), new Point(ClientRectangle.Width, y - 1));
                                g.DrawLine(MIDDLEblue, new Point(0, y), new Point(blueCursor.Left + blueCursor.Width / 2, y));
                                //g.DrawLine(MIDDLEdark, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y), new Point(ClientRectangle.Width, y));
                                g.DrawLine(RIGHTorBOTTOMblue, new Point(0, y + 1), new Point(blueCursor.Left + blueCursor.Width / 2, y + 1));
                                //g.DrawLine(RIGHTorBOTTOMdark, new Point(blueCursor.Left + 1 + blueCursor.Width / 2, y + 1), new Point(ClientRectangle.Width, y + 1));
                            }
                        }
                        else
                        {
                            int x = ClientRectangle.Width / 2;

                            if (Minimum > Maximum)
                            {
                                //g.DrawLine(LEFTorTOPdark, new Point(x - 1, 0), new Point(x - 1, blueCursor.Top + blueCursor.Width / 2));
                                g.DrawLine(LEFTorTOPblue, new Point(x - 1, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x - 1, ClientRectangle.Height));
                                //g.DrawLine(MIDDLEdark, new Point(x, 0), new Point(x, blueCursor.Top + blueCursor.Width / 2));
                                g.DrawLine(MIDDLEblue, new Point(x, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x, ClientRectangle.Height));
                                //g.DrawLine(RIGHTorBOTTOMdark, new Point(x + 1, 0), new Point(x + 1, blueCursor.Top + blueCursor.Width / 2));
                                g.DrawLine(RIGHTorBOTTOMblue, new Point(x + 1, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x + 1, ClientRectangle.Height));
                            }
                            else
                            {
                                g.DrawLine(LEFTorTOPblue, new Point(x - 1, 0), new Point(x - 1, blueCursor.Top + blueCursor.Width / 2));
                                //g.DrawLine(LEFTorTOPdark, new Point(x - 1, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x - 1, ClientRectangle.Height));
                                g.DrawLine(MIDDLEblue, new Point(x, 0), new Point(x, blueCursor.Top + blueCursor.Width / 2));
                                //g.DrawLine(MIDDLEdark, new Point(x, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x, ClientRectangle.Height));
                                g.DrawLine(RIGHTorBOTTOMblue, new Point(x + 1, 0), new Point(x + 1, blueCursor.Top + blueCursor.Width / 2));
                                //g.DrawLine(RIGHTorBOTTOMdark, new Point(x + 1, blueCursor.Top + 1 + blueCursor.Width / 2), new Point(x + 1, ClientRectangle.Height));
                            }
                        }

                        // Draw thumb tracker
                        bmp = new Bitmap(blueCursor.BackgroundImage);
                        bmp.MakeTransparent(Color.FromArgb(255, 0, 255));
                        srceRect = new Rectangle(0, 0, blueCursor.Width, blueCursor.Height);
                        destRect = new Rectangle(blueCursor.Left, blueCursor.Top, blueCursor.Width, blueCursor.Height);
                        g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                        bmp.Dispose();

                        // Release pen resources
                        LEFTorTOPblue.Dispose();
                        //LEFTorTOPdark.Dispose();
                        MIDDLEblue.Dispose();
                        //MIDDLEdark.Dispose();
                        RIGHTorBOTTOMblue.Dispose();
                        //RIGHTorBOTTOMdark.Dispose();

                    } // Release graphics

                    // Swap memory bitmap (End double buffer)
                    Graphics gr = Graphics.FromHdc(m.WParam);
                    gr.DrawImage(offScreenBmp, 0, 0);
                    gr.Dispose();
                    offScreenBmp.Dispose();

                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private bool CheckOverThumb(int x, int y)
        {
            return blueCursor.Bounds.Contains(x, y);
        }

        private void SetThumbLocation()
        {
            Point pos = PointToClient(Cursor.Position);
            int i = 0;

            if (this.IsHorizontal)
            {
                blueCursor.Left = Math.Min(Math.Max(pos.X - blueCursor.Width / 2, 0), blueCursor.Parent.Width - blueCursor.Width);
                blueCursor.Top = ((ClientRectangle.Height - blueCursor.Width) / 2);
                int range = ClientRectangle.Width - blueCursor.Width;
                double increment = (maximum - minimum) / range;
                value = (increment * blueCursor.Left) + minimum;
            }
            else
            {
                blueCursor.Left = (ClientRectangle.Width - blueCursor.Width) / 2 + 1;
                blueCursor.Top = Math.Min(Math.Max(pos.Y - blueCursor.Height / 2, 0), blueCursor.Parent.Height - blueCursor.Height);

                int range = ClientRectangle.Height - blueCursor.Height;
                double increment = (maximum - minimum) / range;
                value = (increment * blueCursor.Top) + minimum;
            }
            Value = value;

            if (WasValue != (int)value)
            {
                this.Invalidate();
                SendNotification();
                WasValue = (int)value;

                if (CheckOverThumb(pos.X, pos.Y))
                    ttVolumeValue.SetToolTip(this, ((int)value).ToString());

                if (i == 0)
                    crucial = value;

                i++;
            }
        }

        private void SendNotification()
        {
            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());
            else
                SendMessage(this.Parent.Handle, 0x111, this.Handle, this.Handle); // 0x111 = WM_COMMAND
        }

        private void ShowThumbPos()
        {
            if (this.IsHorizontal)
            {
                int range = ClientRectangle.Width - blueCursor.Width + 1;
                double increment = (maximum - minimum) / range;
                blueCursor.Top = (ClientRectangle.Height - blueCursor.Width) / 2;
                blueCursor.Left = (increment == 0) ? 0 : (int)((value - minimum) / increment);
            }
            else
            {
                int range = ClientRectangle.Height - blueCursor.Height + 1;
                double increment = (maximum - minimum) / range;
                blueCursor.Left = (ClientRectangle.Width - blueCursor.Width) / 2;
                blueCursor.Top = (increment == 0) ? 0 : (int)((value - minimum) / increment);
            }
            this.Invalidate();
        }
    }
}
