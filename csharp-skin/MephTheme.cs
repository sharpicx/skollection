using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CS_ClassLibraryTester
{
    //--------------------- [ Theme ] --------------------
    //Creator: Mephobia
    //Contact: Mephobia.HF (Skype)
    //Created: 4.20.2013
    //Changed: 4.20.2013
    //-------------------- [ /Theme ] ---------------------

    //PLEASE LEAVE CREDITS IN SOURCE, DO NOT REDISTRIBUTE!

    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    static class Draw
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static void InnerGlow(Graphics G, Rectangle Rectangle, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c_loopVariable in Colors)
            {
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(c_loopVariable.R, c_loopVariable.B, c_loopVariable.G))), Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo);
                SubtractTwo += 2;
                AddOne += 1;
            }
        }
        public static void InnerGlowRounded(Graphics G, Rectangle Rectangle, int Degree, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c in Colors)
            {
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Draw.RoundRect(Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo, Degree));
                SubtractTwo += 2;
                AddOne += 1;
            }
        }
    }
    public class MephTheme : ContainerControl
    {

        private string _subHeader;
        public string SubHeader
        {
            get { return _subHeader; }
            set
            {
                _subHeader = value;
                Invalidate();
            }
        }

        private Color _accentColor;
        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                Invalidate();
            }
        }

        public MephTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(28, 28, 28);
            _subHeader = "Insert Sub Header";
            _accentColor = Color.DarkRed;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            Rectangle mainRect = new Rectangle(0, 0, Width, Height);

            base.OnPaint(e);


            G.Clear(Color.Fuchsia);
            //G.SetClip(Draw.RoundRect(New Rectangle(0, 0, Width, Height), 9))

            Color[] c = new Color[] {
            Color.FromArgb(10, 10, 10),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), mainRect);
            Draw.InnerGlow(G, mainRect, c);

            Color[] c2 = new Color[] {
            Color.FromArgb(5, 5, 5),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(41, 41, 41),
            Color.FromArgb(42, 42, 42),
            Color.FromArgb(43, 43, 43),
            Color.FromArgb(44, 44, 44),
            Color.FromArgb(45, 45, 45)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 45)), new Rectangle(0, 35, Width, 23));
            Draw.InnerGlow(G, new Rectangle(0, 35, Width, 23), c2);

            LinearGradientBrush accentGradient = new LinearGradientBrush(new Rectangle(0, 36, 11, 21), _accentColor, Color.FromArgb((_accentColor.R >= 10 ? _accentColor.R - 10 : _accentColor.R + 10), (_accentColor.G >= 10 ? _accentColor.G - 10 : _accentColor.G + 10), (_accentColor.B >= 10 ? _accentColor.B - 10 : _accentColor.B + 10)), 90);
            G.FillRectangle(accentGradient, new Rectangle(0, 36, 11, 21));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), new Rectangle(0, 35, 11, 22));
            G.FillRectangle(accentGradient, new Rectangle(Width - 12, 36, 11, 21));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), new Rectangle(Width - 12, 35, 11, 22));

            LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(1, 0, Width - 1, 35 / 2), Color.FromArgb(255, Color.FromArgb(90, 90, 90)), Color.FromArgb(255, 71, 71, 71), 90);
            G.FillRectangle(gloss, new Rectangle(1, 0, Width - 2, 35 / 2));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1, 1, Width - 2, 1);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(85, 85, 85))), 1, 34, Width - 2, 34);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 1, 58, Width - 2, 58);

            Font drawFont = new Font("Verdana", 10, FontStyle.Regular);
            G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(225, 225, 225)), new Rectangle(0, 0, Width, 35), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            Font subFont = new Font("Verdana", 8, FontStyle.Regular);
            G.DrawString(_subHeader, subFont, new SolidBrush(Color.FromArgb(225, 225, 225)), new Rectangle(0, 35, Width, 23), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            Font controlFont = new Font("Marlett", 10, FontStyle.Regular);
            switch (State)
            {
                case MouseState.None:
                    G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    if (X > Width - 18 & X < Width - 10 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else if (X > Width - 36 & X < Width - 25 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else if (X > Width - 52 & X < Width - 44 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Down:
                    G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

        }
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
     //   private Height = 35;
	    //private pos = 0;
	    MouseState State = MouseState.None;
        int X;
        int Y;
        Rectangle MinBtn = new Rectangle(0, 0, 32, 25);
        Rectangle CloseBtn = new Rectangle(33, 0, 65, 25);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, Height).Contains(e.Location) & X < Width - 53)
            {
                Cap = true;
                MouseP = e.Location;
            }
            else {
                if (X > Width - 18 & X < Width - 8 & Y < 18 & Y > 8)
                {
                    FindForm().Close();
                }
                else if (X > Width - 36 & X < Width - 25 & Y < 18 & Y > 8)
                {
                    if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Normal;
                    }
                    else {
                        FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
                else if (X > Width - 52 & X < Width - 44 & Y < 18 & Y > 8)
                {
                    FindForm().WindowState = FormWindowState.Minimized;
                }
            }
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //if (Cap)
            //{
            //    Parent.Location = MousePosition - MouseP;
            //}
            X = e.Location.X;
            Y = e.Location.Y;
            Invalidate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
        }
    }
    public class MephButton : Control
    {
        #region " MouseStates "
        MouseState State = MouseState.None;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        #endregion

        public MephButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Verdana", 8, FontStyle.Regular);

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(new SolidBrush(Color.FromArgb(40, 40, 40)), Draw.RoundRect(ClientRectangle, 3));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(15, 15, 15))), Draw.RoundRect(ClientRectangle, 3));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(55, 55, 55))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 3));

            switch (State)
            {
                case MouseState.None:
                    G.DrawString(Text, drawFont, Brushes.Silver, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    G.DrawString(Text, drawFont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    G.DrawString(Text, drawFont, Brushes.Gray, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    public class MephGroupBox : ContainerControl
    {

        public enum HeaderLine
        {
            Enabled,
            Disabled
        }
        private HeaderLine _HeaderLine;
        public HeaderLine Header_Line
        {
            get { return _HeaderLine; }
            set
            {
                _HeaderLine = value;
                Invalidate();
            }
        }

        public MephGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(174, 115);
            _HeaderLine = HeaderLine.Enabled;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);


            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Verdana", 8, FontStyle.Regular);

            G.SmoothingMode = SmoothingMode.HighQuality;

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), ClientRectangle);
            Draw.InnerGlow(G, ClientRectangle, c);

            switch (_HeaderLine)
            {
                case HeaderLine.Enabled:
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 16, 29, Width - 17, 29);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), 15, 30, Width - 16, 30);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 16, 31, Width - 17, 31);
                    break;
                case HeaderLine.Disabled:
                    break;
            }

            G.DrawString(Text, drawFont, Brushes.Silver, new Rectangle(0, 3, Width - 1, 27), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    [DefaultEvent("CheckedChanged")]
    public class MephToggleSwitch : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 24;
            Width = 50;
        }
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        #endregion

        public MephToggleSwitch() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(50, 24);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle onoffRect = new Rectangle(0, 0, Width - 1, Height - 1);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            G.Clear(Color.Transparent);

            LinearGradientBrush bodyGrad = new LinearGradientBrush(onoffRect, Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(bodyGrad, Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(15, 15, 15)), Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(50, 50, 50)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4));

            if (Checked)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(80, Color.Green)), Draw.RoundRect(new Rectangle(4, 2, 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }
            else {
                G.FillPath(new SolidBrush(Color.FromArgb(60, Color.Red)), Draw.RoundRect(new Rectangle((Width / 2) - 7, 2, Width - 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    public class MephTextBox : Control
    {
        private TextBox withEventsField_txtbox = new TextBox();
        public TextBox txtbox
        {
            get { return withEventsField_txtbox; }
            set
            {
                if (withEventsField_txtbox != null)
                {
                    //withEventsField_txtbox.TextChanged -= TextChngTxtBox;
                }
                withEventsField_txtbox = value;
                if (withEventsField_txtbox != null)
                {
                    //withEventsField_txtbox.TextChanged += TextChngTxtBox;
                }
            }

        }
        #region " Control Help - Properties & Flicker Control "
        private bool _passmask = false;
        public bool UseSystemPasswordChar
        {
            get { return _passmask; }
            set
            {
                txtbox.UseSystemPasswordChar = UseSystemPasswordChar;
                _passmask = value;
                Invalidate();
            }
        }
        private int _maxchars = 32767;
        public int MaxLength
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                txtbox.MaxLength = MaxLength;
                Invalidate();
            }
        }
        private HorizontalAlignment _align;
        public HorizontalAlignment TextAlignment
        {
            get { return _align; }
            set
            {
                _align = value;
                Invalidate();
            }
        }
        private bool _multiline = false;
        public bool MultiLine
        {
            get { return _multiline; }
            set
            {
                _multiline = value;
                Invalidate();
            }
        }
        private bool _wordwrap = false;
        public bool WordWrap
        {
            get { return _wordwrap; }
            set
            {
                _wordwrap = value;
                Invalidate();
            }
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            txtbox.BackColor = BackColor;
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            txtbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            txtbox.Font = Font;
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            txtbox.Focus();
        }
        public void TextChngTxtBox()
        {
            Text = txtbox.Text;
        }
        public void TextChng()
        {
            txtbox.Text = Text;
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (MultiLine == false)
            {
                Height = 24;
            }
        }
        public void NewTextBox()
        {
            var _with1 = txtbox;
            _with1.Multiline = MultiLine;
            _with1.BackColor = Color.FromArgb(50, 50, 50);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 4);
            _with1.Font = new Font("Verdana", 8, FontStyle.Regular);
            if (MultiLine == true)
            {
                if (WordWrap == true)
                {
                    _with1.WordWrap = true;
                }
                else {
                    _with1.WordWrap = false;
                }
            }
            else {
                if (WordWrap == true)
                {
                    _with1.WordWrap = true;
                }
                else {
                    _with1.WordWrap = false;
                }
            }
            _with1.Size = new Size(Width - 10, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public MephTextBox() : base()
        {
            //TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);
            Text = "";
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.Silver;
            Size = new Size(135, 24);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            var _with2 = txtbox;
            _with2.Multiline = MultiLine;
            if (MultiLine == false)
            {
                Height = txtbox.Height + 11;
                if (WordWrap == true)
                {
                    _with2.WordWrap = true;
                }
                else {
                    _with2.WordWrap = false;
                }
            }
            else {
                txtbox.Height = Height - 11;
                if (WordWrap == true)
                {
                    _with2.WordWrap = true;
                }
                else {
                    _with2.WordWrap = false;
                }
            }
            _with2.Width = Width - 10;
            _with2.TextAlign = TextAlignment;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(BackColor);

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(ClientRectangle, 3));
            Draw.InnerGlowRounded(G, ClientRectangle, 3, c);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    public class MephProgressBar : Control
    {

        #region " Control Help - Properties & Flicker Control "
        private int OFS = 0;
        private int Speed = 50;

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                //switch (value)
                //{
                //    case :  // ERROR: Case labels with binary operators are unsupported : LessThan
                //        _Value = value;
                //        break;
                //}
                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value = 0;
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                    default:
                        return _Value;
                }
            }
            set
            {
    //            switch (value)
    //            {
    //               case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //_Maximum:
    //                    value = _Maximum;
    //                    break;
    //            }
                _Value = value;
                Invalidate();
            }
        }
        private bool _ShowPercentage = false;
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }
        public void Animate()
        {
            while (true)
            {
                if (OFS <= Width)
                {
                    OFS += 1;
                }
                else {
                    OFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(Speed);
            }
        }
        #endregion

        public MephProgressBar() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(BackColor);

            SolidBrush percentColor = new SolidBrush(Color.White);

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
            Draw.InnerGlowRounded(G, ClientRectangle, 3, c);

            ////// Bar Fill
            if (!(intValue == 0))
            {
                G.FillPath(new LinearGradientBrush(new Rectangle(1, 1, intValue, Height - 3), Color.FromArgb(30, 30, 30), Color.FromArgb(35, 35, 35), 90), Draw.RoundRect(new Rectangle(1, 1, intValue, Height - 3), 2));
                G.DrawPath(new Pen(Color.FromArgb(45, 45, 45)), Draw.RoundRect(new Rectangle(1, 1, intValue, Height - 3), 2));
                //G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(15, 15, 15))), intValue + 1, 3, intValue + 1, Height - 4)
                percentColor = new SolidBrush(Color.White);
            }



            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    [DefaultEvent("CheckedChanged")]
    public class MephRadioButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private Rectangle R1;

        private LinearGradientBrush G1;
        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 24;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is MephRadioButton)
                {
                    ((MephRadioButton)C).Checked = false;
                }
            }
        }

        private Color _accentColor;
        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                Invalidate();
            }
        }
        #endregion

        public MephRadioButton() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(150, 24);
            _accentColor = Color.Maroon;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
            Rectangle InnerRect = new Rectangle(5, 5, Height - 11, Height - 11);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            G.Clear(BackColor);

            LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), 90);
            G.FillRectangle(bgGrad, radioBtnRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), radioBtnRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(55, 55, 55)), new Rectangle(1, 1, Height - 3, Height - 3));

            if (Checked)
            {
                LinearGradientBrush fillGradient = new LinearGradientBrush(InnerRect, _accentColor, Color.FromArgb(_accentColor.R + 5, _accentColor.G + 5, _accentColor.B + 5), 90);
                G.FillRectangle(fillGradient, InnerRect);
                G.DrawRectangle(new Pen(Color.FromArgb(25, 25, 25)), InnerRect);
            }

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
            G.DrawString(Text, drawFont, nb, new Point(28, 12), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }
    public class MephComboBox : ComboBox
    {
        #region " Control Help - Properties & Flicker Control "
        private int _StartIndex = 0;
        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        public override System.Drawing.Rectangle DisplayRectangle
        {
            get { return base.DisplayRectangle; }
        }
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_highlightColor), e.Bounds);
                    LinearGradientBrush gloss = new LinearGradientBrush(e.Bounds, Color.FromArgb(30, Color.White), Color.FromArgb(0, Color.White), 90);
                    //Highlight Gloss/Color
                    e.Graphics.FillRectangle(gloss, new Rectangle(new Point(e.Bounds.X, e.Bounds.Y), new Size(e.Bounds.Width, e.Bounds.Height)));
                    //Drop Background
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, Color.Black)) { DashStyle = DashStyle.Solid }, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                }
                else {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds);
                }
                using (SolidBrush b = new SolidBrush(Color.Silver))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height));
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Point FirstPoint2, Point SecondPoint2, Point ThirdPoint2, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
            G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))), points.ToArray());

            List<Point> points2 = new List<Point>();
            points2.Add(FirstPoint2);
            points2.Add(SecondPoint2);
            points2.Add(ThirdPoint2);
            G.FillPolygon(new SolidBrush(Clr), points2.ToArray());
            G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))), points2.ToArray());
        }
        private Color _highlightColor = Color.FromArgb(55, 55, 55);
        public Color ItemHighlightColor
        {
            get { return _highlightColor; }
            set
            {
                _highlightColor = value;
                Invalidate();
            }
        }
        #endregion

        public MephComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            ForeColor = Color.Silver;
            Font = new Font("Verdana", 8, FontStyle.Regular);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Size = new Size(Width, 21);
            ItemHeight = 16;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;


            G.Clear(BackColor);
            LinearGradientBrush bodyGradNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 2), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90);
            G.FillPath(bodyGradNone, Draw.RoundRect(new Rectangle((int)bodyGradNone.Rectangle.X, (int)bodyGradNone.Rectangle.Y, (int)bodyGradNone.Rectangle.Width, (int)bodyGradNone.Rectangle.Height), 3));
            LinearGradientBrush bodyInBorderNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 3), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90);
            G.DrawPath(new Pen(bodyInBorderNone), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 4), 3));
            G.DrawPath(new Pen(Color.FromArgb(20, 20, 20)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
            //Outer Line
            G.DrawPath(new Pen(Color.FromArgb(55, 55, 55)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 3));
            //Inner Line
            DrawTriangle(Color.FromArgb(60, 60, 60), new Point(Width - 14, 12), new Point(Width - 7, 12), new Point(Width - 11, 16), new Point(Width - 14, 10), new Point(Width - 7, 10), new Point(Width - 11, 5), G);
            //Triangle Fill Color

            //Draw Separator line
            G.DrawLine(new Pen(Color.FromArgb(45, 45, 45)), new Point(Width - 21, 2), new Point(Width - 21, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(55, 55, 55)), new Point(Width - 20, 1), new Point(Width - 20, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(45, 45, 45)), new Point(Width - 19, 2), new Point(Width - 19, Height - 3));
            try
            {
                G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 20, Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            catch
            {
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    class MephTabcontrol : TabControl
    {
        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public MephTabcontrol()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(35, 85);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Font FF = new Font("Verdana", 8, FontStyle.Regular);
            try
            {
                SelectedTab.BackColor = Color.FromArgb(50, 50, 50);
            }
            catch
            {
            }
            G.Clear(Parent.FindForm().BackColor);

            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(0, 0, ItemSize.Height + 3, Height - 1));
            //Full Tab Background

            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    ColorBlend myBlend = new ColorBlend();
                    myBlend.Colors = new [] {
                    Color.FromArgb(50, 50, 50),
					Color.FromArgb(50, 50, 50),
					Color.FromArgb(50, 50, 50)
    
                };
                    //Full Tab Background Gradient Accents
                    myBlend.Positions =new [] {0f,0.5f,1f };
                    LinearGradientBrush lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f);
                    lgBrush.InterpolationColors = myBlend;
                    G.FillRectangle(lgBrush, x2);
                    //G.DrawRectangle(New Pen(Color.FromArgb(20, 20, 20)), x2) 'Full Tab Highlight Outline
                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X + 4, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11);
                    G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), RoundRect(tabRect, 4));
                    //Highlight Fill Background

                    Color[] cFull = new Color[] {
                    Color.FromArgb(20, 20, 20),
                    Color.FromArgb(40, 40, 40),
                    Color.FromArgb(45, 45, 45),
                    Color.FromArgb(46, 46, 46),
                    Color.FromArgb(47, 47, 47),
                    Color.FromArgb(48, 48, 48),
                    Color.FromArgb(49, 49, 49),
                    Color.FromArgb(50, 50, 50)
                };
                    Draw.InnerGlow(G, new Rectangle(0, 0, ItemSize.Height + 3, Height - 1), cFull);
                    // Main Left Box Outline

                    Color[] cHighlight = new Color[] {
                    Color.FromArgb(20, 20, 20),
                    Color.FromArgb(40, 40, 40),
                    Color.FromArgb(45, 45, 45),
                    Color.FromArgb(46, 46, 46),
                    Color.FromArgb(47, 47, 47),
                    Color.FromArgb(48, 48, 48),
                    Color.FromArgb(49, 49, 49),
                    Color.FromArgb(50, 50, 50)
                };
                    Draw.InnerGlowRounded(G, tabRect, 4, cHighlight);
                    // Fill HighLight Inner

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    //Dim p() As Point = {New Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 20), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 14), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)}
                    //G.FillPolygon(Brushes.White, p)

                    if (ImageList != null)
                    {
                        try
                        {

                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Regular), Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                            else {
                                G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else {
                        G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }

                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
                }
                else {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1));
                    //G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), x2) 'Tab Highlight
                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Right, x2.Top), new Point(x2.Right, x2.Bottom));
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Near,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else {
                                G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else {
                        G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(86, -1, Width - 86, Height + 1));
                //Page Fill Full

                Color[] c = new Color[] {
                Color.FromArgb(20, 20, 20),
                Color.FromArgb(40, 40, 40),
                Color.FromArgb(45, 45, 45),
                Color.FromArgb(46, 46, 46),
                Color.FromArgb(47, 47, 47),
                Color.FromArgb(48, 48, 48),
                Color.FromArgb(49, 49, 49),
                Color.FromArgb(50, 50, 50)
            };
                Draw.InnerGlowRounded(G, new Rectangle(86, 0, Width - 87, Height - 1), 3, c);
                // Fill Page
            }

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), new Rectangle(0, 0, ItemSize.Height + 4, Height - 1));
            //Full Tab Outer Outline
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), new Rectangle(1, 0, ItemSize.Height + 3, Height - 2));
            //Full Tab Inner Outline

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    [DefaultEvent("CheckedChanged")]
    public class MephCheckBox : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        private Color _accentColor;
        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                Invalidate();
            }
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 24;
        }
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        #endregion


        public MephCheckBox() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(250, 24);
            _accentColor = Color.Maroon;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
            Rectangle InnerRect = new Rectangle(5, 5, Height - 11, Height - 11);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            G.Clear(BackColor);

            LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), 90);
            G.FillRectangle(bgGrad, radioBtnRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), radioBtnRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(55, 55, 55)), new Rectangle(1, 1, Height - 3, Height - 3));

            if (Checked)
            {
                LinearGradientBrush fillGradient = new LinearGradientBrush(InnerRect, _accentColor, Color.FromArgb(_accentColor.R + 5, _accentColor.G + 5, _accentColor.B + 5), 90);
                G.FillRectangle(fillGradient, InnerRect);
                G.DrawRectangle(new Pen(Color.FromArgb(25, 25, 25)), InnerRect);
            }

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
            G.DrawString(Text, drawFont, nb, new Point(28, 12), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();

        }

    }






















    //------------------
    //Creator: aeonhack
    //Site: elitevs.net
    //Created: 08/02/2011
    //Changed: 12/06/2011
    //Version: 1.5.4
    //------------------

    abstract class ThemeContainer154 : ContainerControl
    {

        #region " Initialization "

        protected Graphics G;

        protected Bitmap B;
        public ThemeContainer154()
        {
            SetStyle((ControlStyles)139270, true);

            _ImageSize = Size.Empty;
            Font = new Font("Verdana", 8);

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            DrawRadialPath = new GraphicsPath();

            InvalidateCustimization();
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            if (DoneCreation)
                InitializeMessages();

            InvalidateCustimization();
            ColorHook();

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;
            if (!_ControlMode)
                base.Dock = DockStyle.Fill;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        private bool DoneCreation;
        protected override sealed void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent == null)
                return;
            _IsParentForm = Parent is Form;

            if (!_ControlMode)
            {
                InitializeMessages();

                if (_IsParentForm)
                {
                    ParentForm.FormBorderStyle = _BorderStyle;
                    ParentForm.TransparencyKey = _TransparencyKey;

                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;
                    }
                }

                Parent.BackColor = BackColor;
            }

            OnCreation();
            DoneCreation = true;
            InvalidateTimer();
        }

        #endregion

        private void DoAnimation(bool i)
        {
            OnAnimation();
            if (i)
                Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (_Transparent && _ControlMode)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
            else {
                G = e.Graphics;
                PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
            base.OnHandleDestroyed(e);
        }

        private bool HasShown;
        private void FormShown(object sender, EventArgs e)
        {
            if (_ControlMode || HasShown)
                return;

            if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
            {
                Rectangle SB = Screen.PrimaryScreen.Bounds;
                Rectangle CB = ParentForm.Bounds;
                ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
            }

            HasShown = true;
        }


        #region " Size Handling "

        private Rectangle Frame;
        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Movable && !_ControlMode)
            {
                Frame = new Rectangle(7, 7, Width - 14, _Header - 7);
            }

            InvalidateBitmap();
            Invalidate();

            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
            {
                if (_Sizable && !_ControlMode)
                    InvalidateMouse();
            }

            base.OnMouseMove(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetState(MouseState.None);

            if (GetChildAtPoint(PointToClient(MousePosition)) != null)
            {
                if (_Sizable && !_ControlMode)
                {
                    Cursor = Cursors.Default;
                    Previous = 0;
                }
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SetState(MouseState.Down);

            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
            {
                if (_Movable && Frame.Contains(e.Location))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[0]);
                }
                else if (_Sizable && !(Previous == 0))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[Previous]);
                }
            }

            base.OnMouseDown(e);
        }

        private bool WM_LMBUTTONDOWN;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WM_LMBUTTONDOWN && m.Msg == 513)
            {
                WM_LMBUTTONDOWN = false;

                SetState(MouseState.Over);
                if (!_SmartBounds)
                    return;

                if (IsParentMdi)
                {
                    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
                }
                else {
                    CorrectBounds(Screen.FromControl(Parent).WorkingArea);
                }
            }
        }

        private Point GetIndexPoint;
        private bool B1;
        private bool B2;
        private bool B3;
        private bool B4;
        private int GetIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1 = GetIndexPoint.X < 7;
            B2 = GetIndexPoint.X > Width - 7;
            B3 = GetIndexPoint.Y < 7;
            B4 = GetIndexPoint.Y > Height - 7;

            if (B1 && B3)
                return 4;
            if (B1 && B4)
                return 7;
            if (B2 && B3)
                return 5;
            if (B2 && B4)
                return 8;
            if (B1)
                return 1;
            if (B2)
                return 2;
            if (B3)
                return 3;
            if (B4)
                return 6;
            return 0;
        }

        private int Current;
        private int Previous;
        private void InvalidateMouse()
        {
            Current = GetIndex();
            if (Current == Previous)
                return;

            Previous = Current;
            switch (Previous)
            {
                case 0:
                    Cursor = Cursors.Default;
                    break;
                case 1:
                case 2:
                    Cursor = Cursors.SizeWE;
                    break;
                case 3:
                case 6:
                    Cursor = Cursors.SizeNS;
                    break;
                case 4:
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 5:
                case 7:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        private Message[] Messages = new Message[9];
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (Parent.Width > bounds.Width)
                Parent.Width = bounds.Width;
            if (Parent.Height > bounds.Height)
                Parent.Height = bounds.Height;

            int X = Parent.Location.X;
            int Y = Parent.Location.Y;

            if (X < bounds.X)
                X = bounds.X;
            if (Y < bounds.Y)
                Y = bounds.Y;

            int Width = bounds.X + bounds.Width;
            int Height = bounds.Y + bounds.Height;

            if (X + Parent.Width > Width)
                X = Width - Parent.Width;
            if (Y + Parent.Height > Height)
                Y = Height - Parent.Height;

            Parent.Location = new Point(X, Y);
        }

        #endregion


        #region " Base Properties "

        public override DockStyle Dock
        {
            get { return base.Dock; }
            set
            {
                if (!_ControlMode)
                    return;
                base.Dock = value;
            }
        }

        private bool _BackColor;
        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (value == base.BackColor)
                    return;

                if (!IsHandleCreated && _ControlMode && value == Color.Transparent)
                {
                    _BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (Parent != null)
                {
                    if (!_ControlMode)
                        Parent.BackColor = value;
                    ColorHook();
                }
            }
        }

        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set
            {
                base.MinimumSize = value;
                if (Parent != null)
                    Parent.MinimumSize = value;
            }
        }

        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = value;
                if (Parent != null)
                    Parent.MaximumSize = value;
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        #endregion

        #region " Public Properties "

        private bool _SmartBounds = true;
        public bool SmartBounds
        {
            get { return _SmartBounds; }
            set { _SmartBounds = value; }
        }

        private bool _Movable = true;
        public bool Movable
        {
            get { return _Movable; }
            set { _Movable = value; }
        }

        private bool _Sizable = true;
        public bool Sizable
        {
            get { return _Sizable; }
            set { _Sizable = value; }
        }

        private Color _TransparencyKey;
        public Color TransparencyKey
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.TransparencyKey;
                else
                    return _TransparencyKey;
            }
            set
            {
                if (value == _TransparencyKey)
                    return;
                _TransparencyKey = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.TransparencyKey = value;
                    ColorHook();
                }
            }
        }

        private FormBorderStyle _BorderStyle;
        public FormBorderStyle BorderStyle
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.FormBorderStyle;
                else
                    return _BorderStyle;
            }
            set
            {
                _BorderStyle = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.FormBorderStyle = value;

                    if (!(value == FormBorderStyle.None))
                    {
                        Movable = false;
                        Sizable = false;
                    }
                }
            }
        }

        private FormStartPosition _StartPosition;
        public FormStartPosition StartPosition
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.StartPosition;
                else
                    return _StartPosition;
            }
            set
            {
                _StartPosition = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.StartPosition = value;
                }
            }
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                    _ImageSize = Size.Empty;
                else
                    _ImageSize = value.Size;

                _Image = value;
                Invalidate();
            }
        }

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        private bool _Transparent;
        public bool Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (!(IsHandleCreated || _ControlMode))
                    return;

                if (!value && !(BackColor.A == 255))
                {
                    throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                }

                SetStyle(ControlStyles.Opaque, !value);
                SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                InvalidateBitmap();
                Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private Size _ImageSize;
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        private bool _IsParentForm;
        protected bool IsParentForm
        {
            get { return _IsParentForm; }
        }

        protected bool IsParentMdi
        {
            get
            {
                if (Parent == null)
                    return false;
                return Parent.Parent != null;
            }
        }

        private int _LockWidth;
        protected int LockWidth
        {
            get { return _LockWidth; }
            set
            {
                _LockWidth = value;
                if (!(LockWidth == 0) && IsHandleCreated)
                    Width = LockWidth;
            }
        }

        private int _LockHeight;
        protected int LockHeight
        {
            get { return _LockHeight; }
            set
            {
                _LockHeight = value;
                if (!(LockHeight == 0) && IsHandleCreated)
                    Height = LockHeight;
            }
        }

        private int _Header = 24;
        protected int Header
        {
            get { return _Header; }
            set
            {
                _Header = value;

                if (!_ControlMode)
                {
                    Frame = new Rectangle(7, 7, Width - 14, value - 7);
                    Invalidate();
                }
            }
        }

        private bool _ControlMode;
        protected bool ControlMode
        {
            get { return _ControlMode; }
            set
            {
                _ControlMode = value;

                Transparent = _Transparent;
                if (_Transparent && _BackColor)
                    BackColor = Color.Transparent;

                InvalidateBitmap();
                Invalidate();
            }
        }

        private bool _IsAnimated;
        protected bool IsAnimated
        {
            get { return _IsAnimated; }
            set
            {
                _IsAnimated = value;
                InvalidateTimer();
            }
        }

        #endregion


        #region " Property Helpers "

        protected Pen GetPen(string name)
        {
            return new Pen(Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(Items[name], width);
        }

        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(Items[name]);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (Items.ContainsKey(name))
                Items[name] = value;
            else
                Items.Add(name, value);
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            SetColor(name, Color.FromArgb(a, value));
        }

        private void InvalidateBitmap()
        {
            if (_Transparent && _ControlMode)
            {
                if (Width == 0 || Height == 0)
                    return;
                B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
                G = Graphics.FromImage(B);
            }
            else {
                G = null;
                B = null;
            }
        }

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (DesignMode || !DoneCreation)
                return;

            if (_IsAnimated)
            {
                ThemeShare.AddAnimationCallback(DoAnimation);
            }
            else {
                ThemeShare.RemoveAnimationCallback(DoAnimation);
            }
        }

        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        protected virtual void OnCreation()
        {
        }

        protected virtual void OnAnimation()
        {
        }

        #endregion


        #region " Offset "

        private Rectangle OffsetReturnRectangle;
        protected Rectangle Offset(Rectangle r, int amount)
        {
            OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return OffsetReturnRectangle;
        }

        private Size OffsetReturnSize;
        protected Size Offset(Size s, int amount)
        {
            OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return OffsetReturnSize;
        }

        private Point OffsetReturnPoint;
        protected Point Offset(Point p, int amount)
        {
            OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return OffsetReturnPoint;
        }

        #endregion

        #region " Center "


        private Point CenterReturn;
        protected Point Center(Rectangle p, Rectangle c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return CenterReturn;
        }

        protected Point Center(Rectangle child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return Center(Width, Height, childWidth, childHeight);
        }

        protected Point Center(Size p, Size c)
        {
            return Center(p.Width, p.Height, c.Width, c.Height);
        }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;
        protected Size Measure()
        {
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
            }
        }
        protected Size Measure(string text)
        {
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
            }
        }

        #endregion


        #region " DrawPixel "


        private SolidBrush DrawPixelBrush;
        protected void DrawPixel(Color c1, int x, int y)
        {
            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
            }
            else {
                DrawPixelBrush = new SolidBrush(c1);
                G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1, int offset)
        {
            DrawCorners(c1, 0, 0, Width, Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else {
                DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;

            DrawTextSize = Measure(text);
            DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, Header / 2 - DrawTextSize.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, p1);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = new Point(Width / 2 - image.Width / 2, Header / 2 - image.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }


        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;

        private Rectangle DrawRadialRectangle;
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            DrawRadialPath.Reset();
            DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
            DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            DrawRadialBrush1.InterpolationColors = blend;

            if (G.SmoothingMode == SmoothingMode.AntiAlias)
            {
                G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            }
            else {
                G.FillEllipse(DrawRadialBrush1, r);
            }
        }


        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawGradientRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            G.FillEllipse(DrawGradientBrush, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

    }

    abstract class ThemeControl154 : Control
    {


        #region " Initialization "

        protected Graphics G;

        protected Bitmap B;
        public ThemeControl154()
        {
            SetStyle((ControlStyles)139270, true);

            _ImageSize = Size.Empty;
            Font = new Font("Verdana", 8);

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            DrawRadialPath = new GraphicsPath();

            InvalidateCustimization();
            //Remove?
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            InvalidateCustimization();
            ColorHook();

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        private bool DoneCreation;
        protected override sealed void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                OnCreation();
                DoneCreation = true;
                InvalidateTimer();
            }

            base.OnParentChanged(e);
        }

        #endregion

        private void DoAnimation(bool i)
        {
            OnAnimation();
            if (i)
                Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (_Transparent)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
            else {
                G = e.Graphics;
                PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
            base.OnHandleDestroyed(e);
        }

        #region " Size Handling "

        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Transparent)
            {
                InvalidateBitmap();
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        private bool InPosition;
        protected override void OnMouseEnter(EventArgs e)
        {
            InPosition = true;
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (InPosition)
                SetState(MouseState.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SetState(MouseState.Down);
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            InPosition = false;
            SetState(MouseState.None);
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        #endregion


        #region " Base Properties "

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        private bool _BackColor;
        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (!IsHandleCreated && value == Color.Transparent)
                {
                    _BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (Parent != null)
                    ColorHook();
            }
        }

        #endregion

        #region " Public Properties "

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        private bool _Transparent;
        public bool Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (!IsHandleCreated)
                    return;

                if (!value && !(BackColor.A == 255))
                {
                    throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                }

                SetStyle(ControlStyles.Opaque, !value);
                SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                if (value)
                    InvalidateBitmap();
                else
                    B = null;
                Invalidate();
            }
        }

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private Size _ImageSize;
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        private int _LockWidth;
        protected int LockWidth
        {
            get { return _LockWidth; }
            set
            {
                _LockWidth = value;
                if (!(LockWidth == 0) && IsHandleCreated)
                    Width = LockWidth;
            }
        }

        private int _LockHeight;
        protected int LockHeight
        {
            get { return _LockHeight; }
            set
            {
                _LockHeight = value;
                if (!(LockHeight == 0) && IsHandleCreated)
                    Height = LockHeight;
            }
        }

        private bool _IsAnimated;
        protected bool IsAnimated
        {
            get { return _IsAnimated; }
            set
            {
                _IsAnimated = value;
                InvalidateTimer();
            }
        }

        #endregion


        #region " Property Helpers "

        protected Pen GetPen(string name)
        {
            return new Pen(Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(Items[name], width);
        }

        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(Items[name]);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (Items.ContainsKey(name))
                Items[name] = value;
            else
                Items.Add(name, value);
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            SetColor(name, Color.FromArgb(a, value));
        }

        private void InvalidateBitmap()
        {
            if (Width == 0 || Height == 0)
                return;
            B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            G = Graphics.FromImage(B);
        }

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (DesignMode || !DoneCreation)
                return;

            if (_IsAnimated)
            {
                ThemeShare.AddAnimationCallback(DoAnimation);
            }
            else {
                ThemeShare.RemoveAnimationCallback(DoAnimation);
            }
        }
        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        protected virtual void OnCreation()
        {
        }

        protected virtual void OnAnimation()
        {
        }

        #endregion


        #region " Offset "

        private Rectangle OffsetReturnRectangle;
        protected Rectangle Offset(Rectangle r, int amount)
        {
            OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return OffsetReturnRectangle;
        }

        private Size OffsetReturnSize;
        protected Size Offset(Size s, int amount)
        {
            OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return OffsetReturnSize;
        }

        private Point OffsetReturnPoint;
        protected Point Offset(Point p, int amount)
        {
            OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return OffsetReturnPoint;
        }

        #endregion

        #region " Center "


        private Point CenterReturn;
        protected Point Center(Rectangle p, Rectangle c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return CenterReturn;
        }

        protected Point Center(Rectangle child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return Center(Width, Height, childWidth, childHeight);
        }

        protected Point Center(Size p, Size c)
        {
            return Center(p.Width, p.Height, c.Width, c.Height);
        }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;
        //TODO: Potential issues during multi-threading.
        private Graphics MeasureGraphics;

        protected Size Measure()
        {
            return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
        }
        protected Size Measure(string text)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }

        #endregion


        #region " DrawPixel "


        private SolidBrush DrawPixelBrush;
        protected void DrawPixel(Color c1, int x, int y)
        {
            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
            }
            else {
                DrawPixelBrush = new SolidBrush(c1);
                G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1, int offset)
        {
            DrawCorners(c1, 0, 0, Width, Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else {
                DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;

            DrawTextSize = Measure(text);
            DrawTextPoint = Center(DrawTextSize);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, p1);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = Center(image.Size);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }


        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;

        private Rectangle DrawRadialRectangle;
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            DrawRadialPath.Reset();
            DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
            DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            DrawRadialBrush1.InterpolationColors = blend;

            if (G.SmoothingMode == SmoothingMode.AntiAlias)
            {
                G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            }
            else {
                G.FillEllipse(DrawRadialBrush1, r);
            }
        }


        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawRadialRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawRadialRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillEllipse(DrawRadialBrush2, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            G.FillEllipse(DrawRadialBrush2, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

    }

    static class ThemeShare
    {

        #region " Animation "

        private static int Frames;
        private static bool Invalidate;

        public static PrecisionTimer ThemeTimer = new PrecisionTimer();
        //1000 / 50 = 20 FPS
        private const int FPS = 50;

        private const int Rate = 10;
        public delegate void AnimationDelegate(bool invalidate);


        private static List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();
        private static void HandleCallbacks(IntPtr state, bool reserve)
        {
            Invalidate = (Frames >= FPS);
            if (Invalidate)
                Frames = 0;

            lock (Callbacks)
            {
                for (int I = 0; I <= Callbacks.Count - 1; I++)
                {
                    Callbacks[I].Invoke(Invalidate);
                }
            }

            Frames += Rate;
        }

        private static void InvalidateThemeTimer()
        {
            if (Callbacks.Count == 0)
            {
                ThemeTimer.Delete();
            }
            else {
                ThemeTimer.Create(0, Rate, HandleCallbacks);
            }
        }

        public static void AddAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (Callbacks.Contains(callback))
                    return;

                Callbacks.Add(callback);
                InvalidateThemeTimer();
            }
        }

        public static void RemoveAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (!Callbacks.Contains(callback))
                    return;

                Callbacks.Remove(callback);
                InvalidateThemeTimer();
            }
        }

        #endregion

    }

    //enum MouseState : byte
    //{
    //    None = 0,
    //    Over = 1,
    //    Down = 2,
    //    Block = 3
    //}

    struct Bloom
    {

        public string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private Color _Value;
        public Color Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string ValueHex
        {
            get { return string.Concat("#", _Value.R.ToString("X2", null), _Value.G.ToString("X2", null), _Value.B.ToString("X2", null)); }
            set
            {
                try
                {
                    _Value = ColorTranslator.FromHtml(value);
                }
                catch
                {
                    return;
                }
            }
        }


        public Bloom(string name, Color value)
        {
            _Name = name;
            _Value = value;
        }
    }

    //------------------
    //Creator: aeonhack
    //Site: elitevs.net
    //Created: 11/30/2011
    //Changed: 11/30/2011
    //Version: 1.0.0
    //------------------
    class PrecisionTimer : IDisposable
    {

        private bool _Enabled;
        public bool Enabled
        {
            get { return _Enabled; }
        }

        private IntPtr Handle;

        private TimerDelegate TimerCallback;
        [DllImport("kernel32.dll", EntryPoint = "CreateTimerQueueTimer")]
        private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

        [DllImport("kernel32.dll", EntryPoint = "DeleteTimerQueueTimer")]
        private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

        public delegate void TimerDelegate(IntPtr r1, bool r2);

        public void Create(uint dueTime, uint period, TimerDelegate callback)
        {
            if (_Enabled)
                return;

            TimerCallback = callback;
            bool Success = CreateTimerQueueTimer(ref Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0);

            if (!Success)
                ThrowNewException("CreateTimerQueueTimer");
            _Enabled = Success;
        }

        public void Delete()
        {
            if (!_Enabled)
                return;
            bool Success = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero);

            if (!Success && !(Marshal.GetLastWin32Error() == 997))
            {
                ThrowNewException("DeleteTimerQueueTimer");
            }

            _Enabled = !Success;
        }

        private void ThrowNewException(string name)
        {
            throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
        }

        public void Dispose()
        {
            Delete();
        }
    }
}
