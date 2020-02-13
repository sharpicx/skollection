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
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /Theme ] ---------------------
    public class ReactorTheme : ContainerControl
    {

        ReactorTopButton CloseBtn = new ReactorTopButton
        {
            Location = new Point(412, 7),
            ButtonType = ReactorTopButton.topButtonType.Close,
            CloseButtonFunction = ReactorTopButton.closeFunc.CloseForm
        };
        ReactorTopButton MinimBtn = new ReactorTopButton
        {
            Location = new Point(393, 7),
            ButtonType = ReactorTopButton.topButtonType.Minimize

        };
        #region " Control Help - Movement & Flicker Control "
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
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
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion

        public ReactorTheme() : base()
        {
            Dock = DockStyle.Fill;
            MoveHeight = 45;
            Font = new Font("Verdana", 6.75f);
            DoubleBuffered = true;

            Controls.Add(CloseBtn);
            Controls.Add(MinimBtn);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            if (!(this.ParentForm.FormBorderStyle == FormBorderStyle.None))
            {
                this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            }

            CloseBtn.Location = new Point(Width - 23, 7);
            MinimBtn.Location = new Point(Width - 42, 7);

            LinearGradientBrush glossLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 15), Color.FromArgb(102, 97, 93), Color.FromArgb(55, 54, 52), 90);
            LinearGradientBrush glossLGB2 = new LinearGradientBrush(new Rectangle(0, 15, Width, 15), Color.Black, Color.FromArgb(26, 25, 21), 90);
            LinearGradientBrush shadowLGB = new LinearGradientBrush(new Rectangle(5, 31, Width - 11, 20), Color.FromArgb(23, 23, 22), Color.FromArgb(38, 38, 38), 90);

            G.Clear(Color.FromArgb(26, 25, 21));
            G.FillRectangle(glossLGB, new Rectangle(0, 0, Width, 15));
            G.FillRectangle(glossLGB2, new Rectangle(0, 15, Width, 15));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(42, 41, 37))), 4, 30, Width - 9, Height - 36);
            G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), new Rectangle(5, 31, Width - 11, Height - 38));
            G.FillRectangle(shadowLGB, new Rectangle(5, 31, Width - 11, 20));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(24, 24, 24))), 5, 32, Width - 7, 32);
            G.DrawRectangle(Pens.Black, new Rectangle(5, 31, Width - 11, Height - 38));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(151, 150, 146))), 1, 1, Width - 2, 1);

            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));

            //G.DrawString(Text, Font, Brushes.Black, Width / 2 - (3 * Text.Length) + 3, 7)
            //G.DrawString(Text, Font, Brushes.White, Width / 2 - (3 * Text.Length) + 3, 8)
            G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, 10, Width - 1, 10), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 11, Width - 1, 11), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
        }
    }


    //--------------------- [ Button ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /Button ] ---------------------
    public class ReactorButton : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public ReactorButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 6.75f);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            G.Clear(Color.FromArgb(36, 34, 30));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                    LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(46, 45, 44))), new Rectangle(1, 1, Width - 3, Height - 4));
                    break;
                case MouseState.Over:
                    //Mouse Hover
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(46, 44, 38))), 2, Height - 1, Width - 4, Height - 1);
                    backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(219, 78, 0), Color.FromArgb(230, 95, 0), 90);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(245, 120, 10))), new Rectangle(1, 1, Width - 3, Height - 4));
                    break;
                case MouseState.Down:
                    //Mouse Down
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                    backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(209, 68, 0), Color.FromArgb(210, 75, 0), 270);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(225, 110, 30))), new Rectangle(1, 1, Width - 3, Height - 4));
                    break;
            }

            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height / 2 - 2), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, Width - 2, Height / 2 - 2));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(21, 20, 18))), new Rectangle(0, 0, Width - 1, Height - 2));

            G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, -2, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
        }
    }


    //--------------------- [ TopButton ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /TopButton ] ---------------------
    public class ReactorTopButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        Color buttonColor;
        public enum topButtonType : byte
        {
            Blank = 0,
            Minimize = 1,
            Maximize = 2,
            Close = 3
        }
        private MouseState State = MouseState.None;
        private topButtonType _tbType = topButtonType.Blank;
        public topButtonType ButtonType
        {
            get { return _tbType; }
            set
            {
                _tbType = value;
                Invalidate();
            }
        }
        private bool _defaultFunc = true;
        public bool UseStandardFunction
        {
            get { return _defaultFunc; }
            set { _defaultFunc = value; }
        }

        public enum closeFunc : byte
        {
            CloseForm = 0,
            CloseApp = 1
        }
        private closeFunc _closeFunc = 0;
        public closeFunc CloseButtonFunction
        {
            get { return _closeFunc; }
            set { _closeFunc = value; }
        }
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
        public void buttonFunction()
        {
            switch (_defaultFunc)
            {
                case true:
                    switch (ButtonType)
                    {
                        case topButtonType.Close:
                            switch (CloseButtonFunction)
                            {
                                case 0:
                                    this.Parent.FindForm().Close();
                                    break;
                                case (closeFunc)1:
                                    Application.Exit();
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        case topButtonType.Minimize:
                            this.Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                        case topButtonType.Maximize:
                            this.Parent.FindForm().WindowState = FormWindowState.Maximized;
                            break;
                    }
                    break;
            }
        }
        #endregion

        public ReactorTopButton() : base()
        {
            //Click += buttonFunction;
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 6.75f);
            Size = new Size(17, 17);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            Size = new Size(17, 17);
            G.Clear(Color.FromArgb(36, 34, 30));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                    LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(46, 45, 44))), new Rectangle(1, 1, Width - 3, Height - 4));
                    buttonColor = Color.FromArgb(163, 163, 162);
                    break;
                case MouseState.Over:
                    //Mouse Hover
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(46, 44, 38))), 2, Height - 1, Width - 4, Height - 1);
                     backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(219, 78, 0), Color.FromArgb(230, 95, 0), 90);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(245, 120, 10))), new Rectangle(1, 1, Width - 3, Height - 4));
                    buttonColor = Color.FromArgb(255, 255, 255);
                    break;
                case MouseState.Down:
                    //Mouse Down
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                     backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 270);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(46, 45, 44))), new Rectangle(1, 1, Width - 3, Height - 4));

                    break;
            }

            switch (ButtonType)
            {
                case topButtonType.Minimize:
                    G.FillRectangle(new SolidBrush(buttonColor), new Rectangle(4, 10, 9, 2));
                    break;
                case topButtonType.Maximize:
                    G.DrawRectangle(new Pen(new SolidBrush(buttonColor)), new Rectangle(4, 4, 8, 7));
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 5, Width - 6, 5);
                    break;
                case topButtonType.Close:
                    G.DrawLine(new Pen(new SolidBrush(buttonColor), 2), 4, 4, 12, 11);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor), 2), 12, 4, 4, 11);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 4, 5, 5);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 11, 5, 10);
                    break;
            }

            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, 7), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, Width - 2, 7));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(21, 20, 18))), new Rectangle(0, 0, Width - 1, Height - 2));
        }
    }


    //--------------------- [ ProgressBar ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /ProgressBar ] ---------------------
    public class ReactorProgressBar : Control
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
    //            switch (value)
    //            {
    //                case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //_Value:
    //                    _Value = value;
    //                    break;
    //            }
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
                        return 1;
                    default:
                        return _Value;
                }
            }
            set
            {
    //            switch (value)
    //            {
    //                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //_Maximum:
    //                    value = _Maximum;
    //                    break;
    //            }
                _Value = value;
                Invalidate();
            }
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            // Dim tmr As New Timer With {.Interval = Speed}
            // AddHandler tmr.Tick, AddressOf Animate
            // tmr.Start()
            Thread T = new Thread(Animate);
            T.IsBackground = true;
            T.Start();
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
                Thread.Sleep(Speed);
            }
        }
        #endregion

        public ReactorProgressBar() : base()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(Color.FromArgb(38, 38, 38));

            LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, intValue - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
            G.FillRectangle(backGrad, new Rectangle(1, 1, intValue - 1, Height - 2));
            HatchBrush hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(175, 219, 78, 0), Color.FromArgb(175, 229, 98, 0));
            G.RenderingOrigin = new Point(OFS, 0);
            G.FillRectangle(hatch, new Rectangle(1, 1, intValue - 2, Height - 2));
            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, intValue - 2, Height / 2 - 1), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, intValue - 2, Height / 2 - 1));

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);

        }
    }


    //--------------------- [ TextBox (Multi) ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /TextBox (Multi) ] ---------------------
    public class ReactorMultiLineTextBox : Control
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
        private int _maxchars = 32767;
        public int MaxCharacters
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                Invalidate();
            }
        }
        private HorizontalAlignment _align;
        public HorizontalAlignment TextAlign
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
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            txtbox.Size = new Size(Width - 10, Height - 11);
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
            _with1.Multiline = true;
            _with1.BackColor = BackColor;
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(2, 4);
            _with1.Font = new Font("Verdana", (float)7.25 , FontStyle.Regular);
            _with1.Size = new Size(Width - 10, Height - 10);
        }
        #endregion

        public ReactorMultiLineTextBox() : base()
        {
            //TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            Text = "";
            BackColor = Color.FromArgb(37, 37, 37);
            ForeColor = Color.White;
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            txtbox.TextAlign = TextAlign;

            G.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), new Rectangle(1, 1, Width - 2, Height - 2));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);
        }
    }


    //--------------------- [ TextBox ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /TextBox ] ---------------------
    public class ReactorTextBox : Control
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
        public bool UsePasswordMask
        {
            get { return _passmask; }
            set
            {
                _passmask = value;
                Invalidate();
            }
        }
        private int _maxchars = 32767;
        public int MaxCharacters
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                Invalidate();
            }
        }
        private HorizontalAlignment _align;
        public HorizontalAlignment TextAlign
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
            var _with2 = txtbox;
            _with2.Multiline = false;
            _with2.BackColor = BackColor;
            _with2.ForeColor = ForeColor;
            _with2.Text = string.Empty;
            _with2.TextAlign = HorizontalAlignment.Center;
            _with2.BorderStyle = BorderStyle.None;
            _with2.Location = new Point(5, 5);
            _with2.Font = new Font("Verdana",(float) 7.25);
            _with2.Size = new Size(Width - 10, Height - 11);
            _with2.UseSystemPasswordChar = UsePasswordMask;

        }
        #endregion

        public ReactorTextBox() : base()
        {
            //TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            Text = "";
            BackColor = Color.FromArgb(37, 37, 37);
            ForeColor = Color.White;
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            Height = txtbox.Height + 11;
            var _with3 = txtbox;
            _with3.Width = Width - 10;
            _with3.TextAlign = TextAlign;
            _with3.UseSystemPasswordChar = UsePasswordMask;

            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), new Rectangle(1, 1, Width - 2, Height - 2));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);
        }
    }


    //--------------------- [ ListBox ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /ListBox ] ---------------------
    public class ReactorListBox : Control
    {
        private ListBox withEventsField_lstbox = new ListBox();
        public ListBox lstbox
        {
            get { return withEventsField_lstbox; }
            set
            {
                if (withEventsField_lstbox != null)
                {
                    withEventsField_lstbox.DrawItem -= DrawItem;
                }
                withEventsField_lstbox = value;
                if (withEventsField_lstbox != null)
                {
                    withEventsField_lstbox.DrawItem += DrawItem;
                }
            }
        }

        private string[] __Items = { "" };
        #region " Control Help - Properties & Flicker Control "

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            lstbox.Size = new Size(Width - 6, Height - 6);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            lstbox.BackColor = BackColor;
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            lstbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            lstbox.Font = Font;
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            lstbox.Focus();
        }

        public string[] Items
        {
            get
            {
                return __Items;
                Invalidate();
            }
            set
            {
                __Items = value;
                lstbox.Items.Clear();
                Invalidate();
                lstbox.Items.AddRange(value);
                Invalidate();
            }
        }
        public string SelectedItem
        {
            get { return lstbox.SelectedItem.ToString(); }
        }
        public void DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.Graphics.DrawString(lstbox.Items[e.Index].ToString(), e.Font, new SolidBrush(lstbox.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {
            }
        }
        public void AddRange(object[] Items)
        {
            lstbox.Items.Remove("");
            lstbox.Items.AddRange(Items);
            Invalidate();
        }
        public void AddItem(object Item)
        {
            lstbox.Items.Add(Item);
            Invalidate();
        }
        public void NewListBox()
        {
            lstbox.Size = new Size(126, 96);
            lstbox.BorderStyle = BorderStyle.None;
            lstbox.DrawMode = DrawMode.OwnerDrawVariable;
            lstbox.Location = new Point(4, 4);
            lstbox.ForeColor = Color.FromArgb(216, 216, 216);
            lstbox.BackColor = Color.FromArgb(38, 38, 38);
            lstbox.Items.Clear();
        }

        #endregion

        public ReactorListBox() : base()
        {

            NewListBox();
            Controls.Add(lstbox);

            Size = new Size(131, 101);
            BackColor = Color.FromArgb(38, 38, 38);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), new Rectangle(1, 1, Width - 2, Height - 2));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);
        }
    }


    //--------------------- [ ComboBox ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /ComboBox ] ---------------------
    public class ReactorComboBox : ComboBox
    {

        #region " Control Help - Properties & Flicker Control "
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
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
        private Color LightBlack = Color.FromArgb(37, 37, 37);
        private Color LighterBlack = Color.FromArgb(60, 60, 60);
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(229, 88, 0)), e.Bounds);
                    //37 37 37
                }
                using (SolidBrush b = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, e.Bounds);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }
        #endregion

        public ReactorComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            LinearGradientBrush T = new LinearGradientBrush(new Rectangle(0, 0, Width, 10), Color.FromArgb(62, Color.White), Color.FromArgb(30, Color.White), 90);
            SolidBrush DrawCornersBrush = default(SolidBrush);
            DrawCornersBrush = new SolidBrush(Color.FromArgb(37, 37, 37));
            try
            {
                var _with4 = G;
                _with4.SmoothingMode = SmoothingMode.HighQuality;
                _with4.Clear(Color.FromArgb(37, 37, 37));
                _with4.FillRectangle(T, new Rectangle(Width - 20, 0, Width, 9));
                _with4.DrawLine(Pens.Black, Width - 20, 0, Width - 20, Height);
                try
                {
                    //.DrawString(Items(SelectedIndex).ToString, Font, Brushes.White, New Rectangle(New Point(3, 3), New Size(Width - 18, Height)))
                    _with4.DrawString(Text, Font, Brushes.White, new Rectangle(3, 0, Width - 20, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                catch
                {
                }

                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(37, 37, 37))), 0, 0, 0, 0);
                _with4.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0, 0, 0))), new Rectangle(1, 1, Width - 3, Height - 3));

                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, Height - 1, Width, Height - 1);

                DrawTriangle(Color.White, new Point(Width - 14, 8), new Point(Width - 7, 8), new Point(Width - 11, 11), G);
            }
            catch
            {
            }
        }
    }


    //--------------------- [ TabControl ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /TabControl ] ---------------------
    public class ReactorTabControl : TabControl
    {

        #region " Control Help - Properties & Flicker Control "
        private LinearGradientBrush DrawGradientBrush;
        private LinearGradientBrush DrawGradientBrush2;
        private Color _TabBrColor;
        public Color TabBorderColor
        {
            get { return _TabBrColor; }
            set
            {
                _TabBrColor = value;
                Invalidate();
            }
        }
        private Color _ControlBColor;
        public Color TabTextColor
        {
            get { return _ControlBColor; }
            set
            {
                _ControlBColor = value;
                Invalidate();
            }
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        #endregion

        public ReactorTabControl() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            TabBorderColor = Color.White;
            TabTextColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            Rectangle r2 = new Rectangle(0, 0, Width - 1, 25);
            Rectangle r3 = new Rectangle(0, 0, Width - 1, 25);
            Rectangle r4 = new Rectangle(2, 0, Width - 1, 13);
            Rectangle ItemBounds = default(Rectangle);
            SolidBrush TextBrush = new SolidBrush(Color.Empty);
            SolidBrush TabBrush = new SolidBrush(Color.DimGray);
            LinearGradientBrush dgb2 = new LinearGradientBrush(r4, Color.FromArgb(50, Color.White), Color.FromArgb(25, Color.White), 90);

            G.Clear(Color.FromArgb(32, 32, 32));
            DrawGradientBrush2 = new LinearGradientBrush(r3, Color.FromArgb(10, 10, 10), Color.FromArgb(50, 50, 50), 90);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(28, 28, 28))), new Rectangle(1, 1, Width - 3, Height - 3));

            G.FillRectangle(DrawGradientBrush2, r2);
            G.FillRectangle(dgb2, r4);

            for (int TabItemIndex = 0; TabItemIndex <= this.TabCount - 1; TabItemIndex++)
            {
                ItemBounds = this.GetTabRect(TabItemIndex);

                if (Convert.ToBoolean(TabItemIndex & 1))
                {
                    TabBrush.Color = Color.Transparent;
                }
                else {
                    TabBrush.Color = Color.Transparent;
                }
                G.FillRectangle(TabBrush, ItemBounds);
                Pen BorderPen = default(Pen);
                if (TabItemIndex == SelectedIndex)
                {
                    BorderPen = new Pen(Color.Transparent, 1);
                    LinearGradientBrush dgb = new LinearGradientBrush(new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6), Color.FromArgb(175, 219, 78, 0), Color.FromArgb(175, 229, 98, 0), 90);
                    LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height / 2 - 5), Color.FromArgb(80, Color.White), Color.FromArgb(20, Color.White), 90);
                    G.FillRectangle(dgb, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6));
                    G.FillRectangle(gloss, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height / 2 - 4));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(100, 230, 90, 0))), new Rectangle(ItemBounds.Location.X + 4, ItemBounds.Location.Y + 4, ItemBounds.Width - 10, ItemBounds.Height - 8));
                    Rectangle r1 = new Rectangle(1, 1, Width - 1, 3);
                }
                else {
                    BorderPen = new Pen(Color.Transparent, 1);
                }

                G.DrawRectangle(BorderPen, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 1, ItemBounds.Width - 8, ItemBounds.Height - 4));

                BorderPen.Dispose();

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                if (this.SelectedIndex == TabItemIndex)
                {
                    TextBrush.Color = TabTextColor;
                }
                else {
                    TextBrush.Color = Color.DimGray;
                }
                G.DrawString(this.TabPages[TabItemIndex].Text, Font, TextBrush, GetTabRect(TabItemIndex), sf);
                try
                {
                    this.TabPages[TabItemIndex].BackColor = Color.FromArgb(32, 32, 32);
                }
                catch
                {
                }
            }
            try
            {
                foreach (TabPage tabpg in this.TabPages)
                {
                    tabpg.BorderStyle = BorderStyle.None;
                }
            }
            catch
            {
            }

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), 2, 24, Width - 2, 24);
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);
        }
    }


    //--------------------- [ CheckBox ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /CheckBox ] ---------------------
    [DefaultEvent("CheckedChanged")]
    public class ReactorCheckBox : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
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
        #endregion

        public ReactorCheckBox() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            ForeColor = Color.White;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            Height = 16;

            G.Clear(BackColor);

            Color bordColor = Color.FromArgb(46, 45, 44);
            LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, 13, Height / 2 - 2), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);

            if (_Checked)
            {
                bordColor = Color.FromArgb(225, 110, 30);
                backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(209, 68, 0), Color.FromArgb(210, 75, 0), 90);
            }
            else {
                bordColor = Color.FromArgb(46, 45, 44);
                backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(24, 24, 24), Color.FromArgb(30, 30, 30), 90);
            }

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(18, Height / 2 + (Font.Height) - 18));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, 14, Height - 1);
            G.FillRectangle(backGrad, new Rectangle(1, 1, 14, Height - 2));
            G.DrawRectangle(new Pen(new SolidBrush(bordColor)), new Rectangle(1, 1, 12, Height - 4));
            if (_Checked)
            {
                G.FillRectangle(glossGradient, new Rectangle(1, 1, 13, Height / 2 - 2));
            }
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 0, 14, Height - 2));
        }

    }


    //--------------------- [ RadioButton ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /RadioButton ] ---------------------
    [DefaultEvent("CheckedChanged")]
    public class ReactorRadioButton : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
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
                if (!object.ReferenceEquals(C, this) && C is ReactorRadioButton)
                {
                    ((ReactorRadioButton)C).Checked = false;
                }
            }
        }
        #endregion

        public ReactorRadioButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            ForeColor = Color.White;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            Height = 16;
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            R1 = new Rectangle(2, 0, 13, 13);
            if (_Checked)
            {
                G1 = new LinearGradientBrush(R1, Color.FromArgb(220, 209, 68, 0), Color.FromArgb(220, 210, 75, 0), 90);
            }
            else {
                G1 = new LinearGradientBrush(R1, Color.FromArgb(24, 24, 24), Color.FromArgb(30, 30, 30), 90);
            }
            G.FillEllipse(G1, R1);
            if (State == MouseState.Over)
            {
                R1 = new Rectangle(2, 0, 13, 13);
                G.FillEllipse(new SolidBrush(Color.FromArgb(5, Color.White)), R1);
            }
            if (_Checked)
            {
                R1 = new Rectangle(4, 1, 9, 6);
                G1 = new LinearGradientBrush(R1, Color.FromArgb(80, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90);
                G.FillEllipse(G1, R1);
                G.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(225, 110, 30))), 3, 1, 11, 11);
            }
            G.DrawString(Text, Font, new SolidBrush(ForeColor), 18, 1);
            G.DrawEllipse(Pens.Black, 2, 0, 13, 13);
            G.DrawEllipse(new Pen(Color.FromArgb(15, Color.White)), 1, -1, 15, 15);
        }

    }


    //--------------------- [ GroupBox ] --------------------
    //Creator: oVERT3Xo
    //Site: **********.net
    //Contact: oVERT3Xo@hotmail.com
    //Created: 11/22/2011
    //Changed: 11/23/2011
    //-------------------- [ /GroupBox ] ---------------------
    public class ReactorGroupBox : ContainerControl
    {
        #region " Control Help - Properties & Flicker Control"
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public ReactorGroupBox() : base()
        {
            BackColor = Color.FromArgb(33, 33, 33);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush DrawGradientBrush2 = new LinearGradientBrush(new Rectangle(0, 0, Width, 24), Color.FromArgb(10, 10, 10), Color.FromArgb(50, 50, 50), 90);

            G.FillRectangle(DrawGradientBrush2, new Rectangle(0, 0, Width, 24));
            LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(0, 0, Width, 12), Color.FromArgb(60, Color.White), Color.FromArgb(20, Color.White), 90);
            G.FillRectangle(gloss, new Rectangle(0, 0, Width, 12));
            G.DrawLine(Pens.Black, 0, 24, Width, 24);

            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);

            G.DrawString(Text, Font, Brushes.Black, Width / 2 - (3 * Text.Length) + 1, 6);
            G.DrawString(Text, Font, Brushes.White, Width / 2 - (3 * Text.Length) + 1, 7);
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
