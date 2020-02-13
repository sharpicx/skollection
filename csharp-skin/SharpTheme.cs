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
using System.Threading;
using System.Threading.Tasks;
namespace CS_ClassLibraryTester
{
    class SharpButton : Control
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

        #endregion
        public bool Color2
        {
            get { return _Color2; }
            set
            {
                _Color2 = value;
                this.Refresh();
            }
        }
        private bool _Color2 = false;
        public SharpButton() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            ForeColor = Color.FromArgb(210, 220, 230);
            DoubleBuffered = true;
            Font = new Font("Verdana", 8.5f, FontStyle.Regular);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);
            base.OnPaint(e);

            switch (State)
            {
                case MouseState.None:
                    if (_Color2)
                    {
                        G.Clear(Color.FromArgb(43, 53, 63));
                        LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(37, 47, 57), Color.FromArgb(140, 149, 155), 180);
                        G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(140, 149, 155), Color.FromArgb(37, 47, 57), 180);
                        G.FillRectangle(BTNLGB1, new Rectangle(1, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(23, 33, 43))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(113, 123, 133), Color.FromArgb(50, 50, 50), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(63, 73, 83))), 2, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    else {
                        G.Clear(Color.FromArgb(43, 53, 63));
                        LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(37, 47, 57), Color.FromArgb(140, 149, 155), LinearGradientMode.Horizontal);
                        G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(140, 149, 155), Color.FromArgb(37, 47, 57), LinearGradientMode.Horizontal);
                        G.FillRectangle(BTNLGB1, new Rectangle(1, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(50, 50, 50), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(73, 83, 93))), 1, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Over:
                    if (_Color2)
                    {
                        G.Clear(Color.FromArgb(47, 57, 67));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(43, 53, 63), Color.FromArgb(157, 166, 172), 180);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(157, 166, 172), Color.FromArgb(43, 53, 63), 180);
                        G.FillRectangle(LGBOver1, new Rectangle(1, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(29, 39, 49))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(50, 50, 50), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(73, 83, 93))), 1, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(200, 210, 220)), new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    else {
                        G.Clear(Color.FromArgb(51, 61, 71));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(43, 53, 63), Color.FromArgb(154, 163, 169), LinearGradientMode.Horizontal);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(154, 163, 169), Color.FromArgb(43, 53, 63), LinearGradientMode.Horizontal);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(43, 53, 63))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(163, 173, 183), Color.FromArgb(60, 60, 60), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(83, 93, 103))), 1, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(200, 210, 220)), new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Down:
                    if (_Color2)
                    {
                        G.Clear(Color.FromArgb(37, 47, 57));
                        LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(35, 45, 55), Color.FromArgb(132, 141, 147), 180);
                        G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(132, 141, 147), Color.FromArgb(35, 45, 55), 180);
                        G.FillRectangle(BTNLGB1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(93, 103, 113), Color.FromArgb(45, 45, 45), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(53, 63, 73))), 1, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(1, -1, Width - 1, Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    else {
                        G.Clear(Color.FromArgb(43, 53, 63));
                        LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(27, 37, 47), Color.FromArgb(130, 139, 145), LinearGradientMode.Horizontal);
                        G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(130, 139, 145), Color.FromArgb(27, 37, 47), LinearGradientMode.Horizontal);
                        G.FillRectangle(BTNLGB1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(123, 133, 143), Color.FromArgb(55, 55, 55), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(73, 83, 93))), 2, Height - 2, Width - 2, Height - 2);
                        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(1, -1, Width - 1, Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                    break;
            }

            e.Graphics.DrawImage(bmp, 0, 0);
            G.Dispose();
            bmp.Dispose();

        }
    }

    class SharpForm : ContainerControl
    {
        private int Header;
        private bool Cap;
        private Point MouseP = new Point(0, 0);
        private GraphicsPath path;
        protected Graphics G;
        protected Bitmap bmp;
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X;
            float y = r.Y;
            float w = r.Width;
            float h = r.Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }
        #region " Control Help - Movement & Flicker Control "
        protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            ParentForm.FindForm().Text = Text;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, Header).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                //Parent.Location = MousePosition - MouseP;
            }
        }
        private void minimBtnClick()
        {
            ParentForm.FindForm().WindowState = FormWindowState.Minimized;
        }
        private void closeBtnClick()
        {
            if (CloseButtonExitsApp)
            {
                System.Environment.Exit(0);
            }
            else {
                ParentForm.FindForm().Close();
            }
        }
        private bool _closesEnv = false;
        public bool CloseButtonExitsApp
        {
            get { return _closesEnv; }
            set
            {
                _closesEnv = value;
                Invalidate();
            }
        }

        private bool _minimBool = true;
        public bool MinimizeButton
        {
            get { return _minimBool; }
            set
            {
                _minimBool = value;
                Invalidate();
            }
        }
        #endregion


        private SharpTopButton withEventsField_minimBtn = new SharpTopButton
        {
            TopButtonTXT = SharpTopButton.TxtState.Minim,
            //Location = new Point(Width - 60, 0)
        };
        public SharpTopButton minimBtn
        {
            get { return withEventsField_minimBtn; }
            set
            {
                if (withEventsField_minimBtn != null)
                {
                    //withEventsField_minimBtn.Click -= minimBtnClick;
                }
                withEventsField_minimBtn = value;
                if (withEventsField_minimBtn != null)
                {
                    //withEventsField_minimBtn.Click += minimBtnClick;
                }
            }
        }
        private SharpTopButton withEventsField_closeBtn = new SharpTopButton
        {
            TopButtonTXT = SharpTopButton.TxtState.Close,
            //Location = new Point(Width - 40, 0)
        };
        public SharpTopButton closeBtn
        {
            get { return withEventsField_closeBtn; }
            set
            {
                if (withEventsField_closeBtn != null)
                {
                    //withEventsField_closeBtn.Click -= closeBtnClick;
                }
                withEventsField_closeBtn = value;
                if (withEventsField_closeBtn != null)
                {
                    //withEventsField_closeBtn.Click += closeBtnClick;
                }
            }

        }

        public bool Color2
        {
            get { return _Color2; }
            set
            {
                _Color2 = value;
                this.Refresh();
            }
        }

        private bool _Color2 = true;

        public SharpForm() : base()
        {
            Header = 25;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;

            Controls.Add(closeBtn);

            closeBtn.Refresh();
            minimBtn.Refresh();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            bmp = new Bitmap(Width, Height);
            G = Graphics.FromImage(bmp);
            Color TransparencyKey = this.ParentForm.TransparencyKey;


            base.OnPaint(e);

            if (_minimBool)
            {
                Controls.Add(minimBtn);
            }
            else {
                Controls.Remove(minimBtn);
            }

            minimBtn.Location = new Point(Width - 60, 0);
            closeBtn.Location = new Point(Width - 40, 0);


            G.Clear(Color.FromArgb(43, 53, 63));
            //---- Sides--
            Rectangle LGBunderGrdrect = new Rectangle(1, Header, Width, 130);
            LinearGradientBrush LGBunderGrd = new LinearGradientBrush(LGBunderGrdrect, Color.FromArgb(43, 53, 63), Color.FromArgb(70, 79, 85), 90);
            G.FillRectangle(LGBunderGrd, LGBunderGrdrect);


            if (_Color2)
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Header / 2), Color.FromArgb(20, 30, 40), Color.FromArgb(135, Color.White), 360);
                G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Header / 2));
                LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(-1, 1, Width, Header / 2), Color.FromArgb(100, Color.White), Color.FromArgb(20, 30, 40), 360);
                G.FillRectangle(BTNLGB1, new Rectangle(-1, 1, Width / 2, Header / 2));
                Brush txtbrushCL2 = new SolidBrush(Color.FromArgb(250, 250, 250));
                G.DrawString(Text, Font, txtbrushCL2, new Rectangle(16, 6, Width - 1, 22), new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                });
            }
            else {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Header / 2), Color.FromArgb(35, 45, 55), Color.FromArgb(155, Color.White), 180);
                G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Header / 2));
                LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(-1, 1, Width, Header / 2), Color.FromArgb(120, Color.White), Color.FromArgb(35, 45, 55), 180);
                G.FillRectangle(BTNLGB1, new Rectangle(-1, 1, Width / 2, Header / 2));
                Brush txtbrush = new SolidBrush(Color.FromArgb(210, 220, 230));
                G.DrawString(Text, Font, txtbrush, new Rectangle(16, 7, Width - 1, 22), new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                });
            }





            Rectangle InerRecLGB = new Rectangle(11, 28, Width - 22, Height - 37);
            LinearGradientBrush InnerRecLGB = new LinearGradientBrush(InerRecLGB, Color.FromArgb(57, 67, 77), Color.FromArgb(60, 69, 75), 90);
            G.FillRectangle(InnerRecLGB, InerRecLGB);

            //----- InnerRect
            Pen P1 = new Pen(new SolidBrush(Color.FromArgb(23, 33, 43)));
            G.DrawRectangle(P1, 12, 29, Width - 25, Height - 40);
            Pen P2 = new Pen(new SolidBrush(Color.FromArgb(93, 103, 113)));
            G.DrawRectangle(P2, 11, 28, Width - 23, Height - 38);



            LinearGradientBrush LGBunderGrd3 = new LinearGradientBrush(new Rectangle(0, Height - 9, Width / 2, 50), Color.FromArgb(40, 50, 60), Color.FromArgb(50, Color.White), 360);
            G.FillRectangle(LGBunderGrd3, 0, Height - 9, Width / 2, 50);
            LinearGradientBrush LGBunderGrd2 = new LinearGradientBrush(new Rectangle(Width / 2, Height - 9, Width / 2, Height), Color.FromArgb(40, 50, 60), Color.FromArgb(50, Color.White), 180);
            G.FillRectangle(LGBunderGrd2, Width / 2, Height - 9, Width / 2, Height);
            G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width / 2, Height - 9, Width / 2, Height);

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(137, 147, 157))), 1, 1, Width - 3, Height - 3);

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            G.DrawPath(Pens.Black, RoundRect(ClientRectangle, 0, 0, 0, 0));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(163, 173, 183))), 2, 1, Width - 3, 1);
            e.Graphics.DrawImage((Bitmap)bmp.Clone(), 0, 0);
            bmp.Dispose();
            G.Dispose();

        }

    }

    class SharpTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"
        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }
        private MouseState State;

        int X;
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        #endregion
        public enum TxtState : byte
        {
            Close = 1,
            Minim = 2
        }
        private TxtState BtnTxt;
        public TxtState TopButtonTXT
        {
            get { return BtnTxt; }
            set
            {
                BtnTxt = value;
                Invalidate();
            }
        }
        public SharpTopButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 8.25f);
            Size = new Size(30, 20);

            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);
            base.OnPaint(e);


            switch (State)
            {
                case MouseState.Over:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(170, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(170, 18, 32), Color.FromArgb(147, 156, 162), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(147, 156, 162), Color.FromArgb(170, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 175));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 175), Color.FromArgb(157, 166, 172), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(157, 166, 172), Color.FromArgb(0, 102, 175), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.None:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(140, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(140, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(140, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 156));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 156), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(0, 102, 156), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.Down:
                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(130, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(130, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(130, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;
                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(151, 161, 171), Color.FromArgb(83, 83, 83), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(97, 107, 117))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 146));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 154), Color.FromArgb(132, 141, 147), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(132, 141, 147), Color.FromArgb(0, 102, 154), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(37, 47, 57))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(150, 150, 150), Color.FromArgb(127, 137, 147), 90);
                        G.DrawRectangle(new Pen(InnerRect1), new Rectangle(1, 1, Width - 3, Height - 3));
                    }

                    break;
            }
            switch (BtnTxt)
            {
                case TxtState.Close:
                    Size = new Size(30, 20);
                    G.DrawString("r", new Font("Marlett", (float)8.75), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case TxtState.Minim:
                    Size = new Size(25, 20);
                    G.DrawString("0", new Font("Marlett", 12), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(1, -1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            //  G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(40, 40, 40))), 0, 0, 29, 19)

            e.Graphics.DrawImage((Bitmap)bmp.Clone(), 0, 0);
            G.Dispose();
            bmp.Dispose();
        }

    }

    class SharpGroupBOx : ContainerControl
    {
        #region " Control Help - Properties & Flicker Control"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion
        public SharpGroupBOx() : base()
        {
            Size = new Size(200, 100);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            //BackColor = Color.Transparent
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(210, 220, 230);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);

            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(Color.FromArgb(43, 53, 63));

            LinearGradientBrush s2 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 25), Color.FromArgb(35, 45, 55), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(s2, new Rectangle(1, 14, Width - 3, 13));
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 25), Color.FromArgb(90, Color.White), Color.FromArgb(35, 45, 55), 90);
            G.FillRectangle(s1, new Rectangle(1, 1, Width - 3, 13));


            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), 0, 0, Width - 1, 28);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(111, 121, 131))), 1, 1, Width - 3, 26);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), 0, 30, Width - 1, Height - 31);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(60, 70, 80))), 1, 31, Width - 3, Height - 33);

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 30, 30))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(20, 30, 40))), 1, 29, Width - 2, 29);

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(1, 4, Width, 20), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)bmp.Clone(), 0, 0);
            G.Dispose();
            bmp.Dispose();
        }
    }

    class SharpProgreSsBar : Control
    {
        private System.Windows.Forms.Timer GlowAnimation = new System.Windows.Forms.Timer();
        //Private _GlowColor As Color = Color.FromArgb(55, 65, 75)
        private Color _GlowColor = Color.FromArgb(50, 255, 255, 255);
        private bool _Animate = true;
        private Int32 _Value = 0;
        private Color _HighlightColor = Color.Silver;
        private Color _BackgroundColor = Color.FromArgb(150, 150, 150);
        #region "Properties"
        private Color _StartColor = Color.FromArgb(110, 110, 110);
        public Color Color
        {
            get { return _StartColor; }
            set
            {
                _StartColor = value;
                this.Invalidate();
            }
        }
        public bool Animate
        {
            get { return _Animate; }
            set
            {
                _Animate = value;
                if (value == true)
                {
                    GlowAnimation.Start();
                }
                else {
                    GlowAnimation.Stop();
                }
                this.Invalidate();
            }
        }
        public Color GlowColor
        {
            get { return _GlowColor; }
            set
            {
                _GlowColor = value;
                this.Invalidate();
            }
        }
        public Int32 Value
        {
            get { return _Value; }
            set
            {
                if (value < 0)
                    return;
                _Value = value;
                if (value < 100)
                    GlowAnimation.Start();

                this.Invalidate();
            }
        }
        public Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                this.Invalidate();
            }
        }
        public Color HighlightColor
        {
            get { return _HighlightColor; }
            set
            {
                _HighlightColor = value;
                this.Invalidate();
            }
        }

        #endregion
        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }
        public SharpProgreSsBar() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            if (!InDesignMode())
            {
                GlowAnimation.Interval = 15;
                if (Value < 100)
                    GlowAnimation.Start();

                GlowAnimation.Tick += GlowAnimation_Tick;
            }
        }

        private int _mGlowPosition = -100;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(Color.FromArgb(43, 53, 63));
            //   -------------------Draw Background for the MBProgressBar--------------------

            LinearGradientBrush s2 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 50), Color.FromArgb(35, 45, 55), Color.FromArgb(50, Color.White), 90);

            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 50), Color.FromArgb(75, Color.White), Color.FromArgb(35, 45, 55), 90);

            Rectangle BackRectangle = this.ClientRectangle;
            BackRectangle.Width = BackRectangle.Width - 1;
            BackRectangle.Height = BackRectangle.Height - 1;
            GraphicsPath GrafP = RoundRect(BackRectangle, 2, 2, 2, 2);
            G.FillPath(s1, GrafP);


            //--------------------Draw Background Shadows for MBProgrssBar------------------
            Rectangle BGSH = new Rectangle(2, 2, 10, this.Height - 5);
            LinearGradientBrush LGBS = new LinearGradientBrush(BGSH, Color.FromArgb(70, 80, 90), Color.FromArgb(95, 105, 115), LinearGradientMode.Horizontal);
            G.FillRectangle(LGBS, BGSH);
            Rectangle BGSRectangle = new Rectangle(this.Width - 12, 2, 10, this.Height - 5);
            LinearGradientBrush LG = new LinearGradientBrush(BGSRectangle, Color.FromArgb(80, 90, 100), Color.FromArgb(75, 85, 95), LinearGradientMode.Horizontal);
            G.FillRectangle(LG, BGSRectangle);


            //----------------------Draw MBProgressBar--------------------	
            Rectangle ProgressRect = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            ProgressRect.Width = Convert.ToInt32((Value * 1f / (100) * this.Width));
            G.FillRectangle(s2, ProgressRect);


            //----------------------Draw Shadows for MBProgressBar------------------
            Rectangle SHRect = new Rectangle(1, 2, 15, this.Height - 3);
            LinearGradientBrush LGSHP = new LinearGradientBrush(SHRect, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend BColor = new ColorBlend(3);
            BColor.Colors = new Color[] {
            Color.Gray,
            Color.FromArgb(40, 0, 0, 0),
            Color.Transparent
        };
            BColor.Positions = new float[] {
            0f,
            0.2f,
            1f
        };
            LGSHP.InterpolationColors = BColor;

            SHRect.X = SHRect.X - 1;
            G.FillRectangle(LGSHP, SHRect);

            Rectangle Rect1 = new Rectangle(this.Width - 3, 2, 15, this.Height - 3);
            Rect1.X = Convert.ToInt32((Value * 1f / (100) * this.Width) - 14);
            LinearGradientBrush LGSH1 = new LinearGradientBrush(Rect1, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend BColor1 = new ColorBlend(3);
            BColor1.Colors = new Color[] {
            Color.Transparent,
            Color.FromArgb(70, 0, 0, 0),
            Color.Transparent
        };
            BColor1.Positions = new float[] {
            0f,
            0.8f,
            1f
        };
            LGSH1.InterpolationColors = BColor1;

            G.FillRectangle(LGSH1, Rect1);


            //-------------------------Draw Highlight for MBProgressBar-----------------
            Rectangle HLRect = new Rectangle(1, 1, this.Width - 1, 6);
            GraphicsPath HLGPa = RoundRect(HLRect, 2, 2, 0, 0);
            //G.SetClip(HLGPa)
            LinearGradientBrush HLGBS = new LinearGradientBrush(HLRect, Color.FromArgb(190, 190, 190), Color.FromArgb(150, 150, 150), LinearGradientMode.Vertical);
            G.FillPath(HLGBS, HLGPa);
            G.ResetClip();
            Rectangle HLrect2 = new Rectangle(1, this.Height - 8, this.Width - 1, 6);
            GraphicsPath bp1 = RoundRect(HLrect2, 0, 0, 2, 2);
            // G.SetClip(bp1)
            LinearGradientBrush bg1 = new LinearGradientBrush(HLrect2, Color.Transparent, Color.FromArgb(150, this.HighlightColor), LinearGradientMode.Vertical);
            G.FillPath(bg1, bp1);
            G.ResetClip();


            //--------------------Draw Inner Sroke for MBProgressBar--------------
            Rectangle Rect20 = this.ClientRectangle;
            Rect20.X = Rect20.X + 1;
            Rect20.Y = Rect20.Y + 1;
            Rect20.Width -= 3;
            Rect20.Height -= 3;
            GraphicsPath Rect15 = RoundRect(Rect20, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(55, 65, 75)), Rect15);

            //-----------------------Draw Outer Stroke on the Control----------------------------
            Rectangle StrokeRect = this.ClientRectangle;
            StrokeRect.Width = StrokeRect.Width - 1;
            StrokeRect.Height = StrokeRect.Height - 1;
            GraphicsPath GGH = RoundRect(StrokeRect, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(122, 122, 122)), GGH);

            //------------------------Draw Glow for MBProgressBar-----------------------
            Rectangle GlowRect = new Rectangle(_mGlowPosition, 6, 60, 60);
            LinearGradientBrush GlowLGBS = new LinearGradientBrush(GlowRect, Color.FromArgb(127, 137, 147), Color.FromArgb(75, 85, 95), LinearGradientMode.Horizontal);
            ColorBlend BColor3 = new ColorBlend(4);
            BColor3.Colors = new Color[] {
            Color.Transparent,
            this.GlowColor,
            this.GlowColor,
            Color.Transparent
        };
            BColor3.Positions = new float[] {
            0f,
            0.5f,
            0.6f,
            1f
        };
            GlowLGBS.InterpolationColors = BColor3;
            Rectangle clip = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            clip.Width = Convert.ToInt32((Value * 1f / (100) * this.Width));
            G.SetClip(clip);
            G.FillRectangle(GlowLGBS, GlowRect);
            G.ResetClip();

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X;
            float y = r.Y;
            float w = r.Width;
            float h = r.Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }
        private void GlowAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Animate)
            {
                _mGlowPosition += 4;
                if (_mGlowPosition > this.Width)
                {
                    _mGlowPosition = -10;
                    this.Invalidate();
                }


            }
            else {
                GlowAnimation.Stop();

                _mGlowPosition = -50;
            }
        }

    }

    class SharpTextBox : Control
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
        public void NewTextBox()
        {
            var _with1 = txtbox;
            _with1.Multiline = false;
            _with1.BackColor = Color.FromArgb(43, 43, 43);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 5);
            _with1.Font = new Font("Verdana", 8);
            _with1.Size = new Size(Width - 10, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public SharpTextBox() : base()
        {
            //TextChanged += TextChng;
            NewTextBox();
            Controls.Add(txtbox);
            Text = "";
            BackColor = Color.FromArgb(35, 45, 55);
            ForeColor = Color.FromArgb(162, 172, 182);
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);

            Height = txtbox.Height + 11;
            var _with2 = txtbox;
            _with2.Width = Width - 10;
            _with2.TextAlign = TextAlignment;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.FromArgb(35, 45, 55));
            Rectangle txtRect = new Rectangle(0, 0, Width - 1, Height - 1);
            LinearGradientBrush InnerRect = new LinearGradientBrush(txtRect, Color.FromArgb(74, 84, 94), Color.FromArgb(94, 104, 114), 90);

            G.DrawRectangle(new Pen(Color.FromArgb(12, 22, 32), 2), txtRect);
            G.DrawLine(new Pen(InnerRect), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(InnerRect), 0, Height - 1, Width - 1, Height - 1);


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }

    class SharpCheckBox : Control
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
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 18;
        }
        #endregion

        public SharpCheckBox() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(145, 16);
            ForeColor = Color.FromArgb(210, 210, 222);
            DoubleBuffered = true;
            Font = new Font("Verdana", 8);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);
            if (Checked == false)
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(37, 47, 57), Color.FromArgb(62, 68, 74), 90);
                G.FillRectangle(BTNLGBOver, new Rectangle(3, 3, 12, 11));



            }
            else {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(73, 83, 93), Color.FromArgb(40, 50, 60), 90);
                G.FillRectangle(BTNLGBOver, new Rectangle(3, 3, 12, 11));

                Rectangle chkRec12 = new Rectangle(3, 2, Height - 5, Height - 6);
                Rectangle chkPoly = new Rectangle(chkRec12.X + chkRec12.Width / 4, chkRec12.Y + chkRec12.Height / 4, chkRec12.Width / 2, chkRec12.Height / 2);
                Point[] Poly = {
                new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
            };

                Pen P1 = new Pen((Color.White), 2);

                for (int i = 0; i <= Poly.Length - 2; i++)
                {
                    G.DrawLine(P1, Poly[i], Poly[i + 1]);
                }


            }
            G.DrawRectangle(new Pen(Color.FromArgb(93, 103, 113)), 1, 1, 16, 15);
            G.DrawRectangle(new Pen(Color.FromArgb(13, 23, 33)), 2, 2, 14, 13);
            G.DrawRectangle(new Pen(Color.FromArgb(113, 123, 133)), 3, 3, 12, 11);
            Brush txtbrush = new SolidBrush(Color.FromArgb(210, 220, 230));
            G.DrawString(Text, Font, txtbrush, new Point(18, 2), new StringFormat
            {
                LineAlignment = StringAlignment.Near,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    class SharpRadioButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }
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
            Height = 16;
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
                if (!object.ReferenceEquals(C, this) && C is SharpRadioButton)
                {
                    ((SharpRadioButton)C).Checked = false;
                }
            }
        }
        #endregion
        public SharpRadioButton() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(150, 16);
            ForeColor = Color.FromArgb(210, 210, 222);
            DoubleBuffered = true;
            Font = new Font("Verdana", 8);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            base.OnPaint(e);

            G.Clear(BackColor);


            if (Checked == false)
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(37, 47, 57), Color.FromArgb(62, 68, 74), 90);
                G.FillEllipse(BTNLGBOver, new Rectangle(3, 3, 12, 11));
                G.DrawEllipse(new Pen(Color.FromArgb(0, 0, 0)), 2, 2, 14, 13);

            }
            else {
                LinearGradientBrush CKelGrd = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(65, 71, 77), Color.FromArgb(0, 0, 0), 90);
                G.FillEllipse(CKelGrd, new Rectangle(3, 3, 12, 11));
                G.DrawEllipse(new Pen(Color.FromArgb(13, 23, 33)), 2, 2, 14, 13);
            }



            G.DrawEllipse(new Pen(Color.FromArgb(93, 103, 113)), 1, 1, 15, 14);

            G.DrawEllipse(new Pen(Color.FromArgb(113, 123, 133)), 3, 3, 11, 10);
            Brush txtbrush = new SolidBrush(Color.FromArgb(210, 220, 230));
            G.DrawString(Text, Font, txtbrush, new Point(18, 2), new StringFormat
            {
                LineAlignment = StringAlignment.Near,
                Alignment = StringAlignment.Near
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

    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

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
