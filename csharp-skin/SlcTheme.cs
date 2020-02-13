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
    //IMPORTANT:
    //Please leave these comments in place as they help protect intellectual rights and allow
    //developers to determine the version of the theme they are using. 
    //Name: SLC Theme
    //Created: Not defined yet
    //Version: 1.0.0.0 beta
    //Site: http://sliceproducts.pw/

    //Copyright © 2013 Slice Software
    //Special Thanks to : Aeonhack http://nimoru.com/
   
    #region "SLCTheme"
    class SLCTheme : ThemeContainer154
    {

        private Pen P1;
        private Pen P2;
        private Color topc;
        private Color botc;
        private Color topc2;
        private Color botc2;

        private SolidBrush B1;




        public SLCTheme()
        {
            TransparencyKey = Color.Fuchsia;
            Header = 30;
            SetColor("top", Color.FromArgb(21, 18, 37));
            SetColor("bottom", Color.FromArgb(32, 35, 54));
            //(21, 18, 37)
            SetColor("top2", Color.FromArgb(32, 35, 54));
            SetColor("bottom2", Color.FromArgb(21, 18, 37));
            BackColor = Color.FromArgb(0, 57, 72);
            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(60, 60, 60));
            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));

        }

        protected override void ColorHook()
        {
            topc = GetColor("top");
            botc = GetColor("bottom");
            topc2 = GetColor("top2");
            botc2 = GetColor("bottom2");
        }

        private GraphicsPath PrepareBorder()
        {
            GraphicsPath P = new GraphicsPath();

            List<Point> PS = new List<Point>();
            PS.Add(new Point(0, 2));
            PS.Add(new Point(2, 0));
            PS.Add(new Point(100, 0));
            PS.Add(new Point(115, 15));
            PS.Add(new Point(Width - 1 - 115, 15));
            PS.Add(new Point(Width - 1 - 100, 0));
            PS.Add(new Point(Width - 2, 0));
            PS.Add(new Point(Width - 1, 3));


            //PS.Add(New Point(Width - 1, Height - 1))

            //bottom
            PS.Add(new Point(Width - 1, Height - 3));
            PS.Add(new Point(Width - 3, Height - 1));
            PS.Add(new Point(Width - 100, Height - 1));
            PS.Add(new Point(Width - 115, Height - 15 - 1));
            PS.Add(new Point(116, Height - 15 - 1));
            PS.Add(new Point(101, Height - 1));
            PS.Add(new Point(2, Height - 1));
            PS.Add(new Point(0, Height - 2));

            P.AddPolygon(PS.ToArray());
            return P;
        }

        //Private Function FormInsideSQ()
        //    Dim P As New GraphicsPath()
        //    Dim PS As New List(Of Point)

        //    PS.Add(New Point(6, Height - 310))
        //    PS.Add(New Point(Width - 6, 64))
        //    PS.Add(New Point(Width - 6, Height - 6))
        //    PS.Add(New Point(Width - 100, Height - 6))
        //    PS.Add(New Point(Width - 116, Height - 22))
        //    PS.Add(New Point(Width - 522, Height - 22))
        //    PS.Add(New Point(Width - 538, Height - 6))
        //    PS.Add(New Point(6, Height - 6))
        //    P.AddPolygon(PS.ToArray())
        //    Return p
        //End Function



        protected override void PaintHook()
        {
            TransparencyKey = Color.Fuchsia;

            G.Clear(Color.Fuchsia);




            HatchBrush HB = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.FromArgb(38, 138, 201)), Color.FromArgb(80, Color.FromArgb(12, 40, 57)));
            LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(108, 137, 184), Color.FromArgb(13, 20, 25), 20f);

            G.FillRectangle(linear, new Rectangle(3, 3, Width - 5, Height - 3));

            G.FillRectangle(HB, new Rectangle(3, 3, Width - 5, Height - 3));


            G.DrawLine(Pens.Fuchsia, 1, 0, Width - 1, 0);
            G.DrawLine(Pens.Fuchsia, 1, 1, Width - 1, 1);
            G.DrawLine(new Pen(Color.FromArgb(26, 47, 59)), 1, 2, Width - 1, 2);

            G.DrawLine(Pens.Fuchsia, 1, Height - 1, Width - 1, Height - 1);
            G.DrawLine(Pens.Fuchsia, 1, Height - 2, Width - 1, Height - 2);
            G.DrawLine(new Pen(Color.FromArgb(26, 47, 59)), 1, Height - 2, Width - 4, Height - 2);




            GraphicsPath GPF = PrepareBorder();


            PathGradientBrush PB2 = default(PathGradientBrush);
            PB2 = new PathGradientBrush(GPF);
            PB2.CenterColor = Color.FromArgb(250, 250, 250);
            PB2.SurroundColors = new [] { Color.FromArgb(237, 237, 237) };
            PB2.FocusScales = new PointF(0.9f, 0.5f);

            G.SetClip(GPF);

            G.FillPath(PB2, GPF);
            G.DrawPath(new Pen(Color.White, 3), GPF);
            G.ResetClip();

            GraphicsPath tmpG = PrepareBorder();

            G.DrawPath(Pens.Gray, tmpG);



            LinearGradientBrush linear2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(13, 59, 85), Color.FromArgb(22, 35, 43), 180f);



            GraphicsPath barGP = new GraphicsPath();

            PathGradientBrush PB3 = default(PathGradientBrush);
            PB3 = new PathGradientBrush(GPF);
            PB3.CenterColor = Color.FromArgb(39, 60, 73);
            PB3.SurroundColors = new [] { Color.FromArgb(31, 105, 152) };
            PB3.FocusScales = new PointF(0.5f, 0.5f);
            PB3.CenterPoint = new Point(Width / 2, 10);

            barGP.AddRectangle(new Rectangle(0, 39, Width - 1, 20));

            G.FillPath(PB3, barGP);
            G.FillPath(new HatchBrush(HatchStyle.NarrowHorizontal, Color.FromArgb(20, 34, 45), Color.Transparent), barGP);

            //// get rid of some pixels
            G.DrawRectangle(Pens.Fuchsia, new Rectangle(Width - 4, 40, 3, 17));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 4, 40, 3, 17));

            G.DrawRectangle(Pens.Fuchsia, new Rectangle(0, 40, 3, 17));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 40, 3, 17));


            //// inside square

            //Dim SQpth As GraphicsPath = FormInsideSQ()
            // G.DrawPath(Pens.Red, SQpth)



            DrawText(new SolidBrush(Color.FromArgb(30, Color.Black)), HorizontalAlignment.Left, 12, 6);
            DrawText(new SolidBrush(Color.FromArgb(20, Color.Black)), HorizontalAlignment.Left, 11, 5);
            DrawText(Brushes.Black, HorizontalAlignment.Left, 10, 4);





        }
    }
    #endregion
    #region "SLCbtn"
    class SLCbtn : ThemeControl154
    {



        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.White);

            switch (State)
            {
                case MouseState.None:

                    //// bnt form

                    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    GraphicsPath gp = new GraphicsPath();
                    gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear, gp);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                    G.SetClip(gp);
                    GraphicsPath btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.White, 1), btninsideborder);
                    G.ResetClip();

                    //// circle



                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                    //PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)

                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                    DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                    break;
                case MouseState.Down:
                    //// bnt form

                    linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    gp = new GraphicsPath();
                    gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear, gp);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                    G.SetClip(gp);
                    btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.White, 1), btninsideborder);
                    G.ResetClip();

                    //// circle



                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(86, 161, 196)
                    //PB2.SurroundColors = {Color.FromArgb(94, 176, 215)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(105, 194, 236)), GPF)

                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                    DrawText(new SolidBrush(Color.FromArgb(86, 161, 196)), HorizontalAlignment.Left, 5, 1);

                    break;
                case MouseState.Over:
                    //// bnt form

                    linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    gp = new GraphicsPath();
                    gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear, gp);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                    G.SetClip(gp);
                    btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.FromArgb(50, Color.Gray), 1), btninsideborder);
                    G.ResetClip();

                    //// circle


                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                    //PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))
                    DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                    break;
            }

        }
    }
    #endregion
    #region "SLCTabControl"
    class SLCTabControl : TabControl
    {

        public SLCTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 120);

        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        public GraphicsPath Borderpts()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(0, 0));
            PS.Add(new Point(Width - 1, 0));
            PS.Add(new Point(Width - 1, Height - 1));
            PS.Add(new Point(0, Height - 1));



            P.AddPolygon(PS.ToArray());
            return P;
        }

        public GraphicsPath BorderptsInside()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(1, 1));
            PS.Add(new Point(122, 1));
            PS.Add(new Point(122, Height - 2));
            PS.Add(new Point(1, Height - 2));



            P.AddPolygon(PS.ToArray());
            return P;
        }

        public GraphicsPath BigBorder()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(50, 1));
            PS.Add(new Point(349, 50));
            PS.Add(new Point(349, 50));
            PS.Add(new Point(50, 349));

            P.AddPolygon(PS.ToArray());
            return P;
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {


            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);




            ////Big square shadow







            GraphicsPath GP1 = Borderpts();
            g.DrawPath(Pens.LightGray, GP1);


            //// small border
            GraphicsPath tmp1 = BorderptsInside();

            PathGradientBrush PB2 = default(PathGradientBrush);
            PB2 = new PathGradientBrush(tmp1);
            PB2.CenterColor = Color.FromArgb(250, 250, 250);
            PB2.SurroundColors = new [] { Color.FromArgb(237, 237, 237) };
            PB2.FocusScales = new PointF(0.9f, 0.9f);

            g.FillPath(PB2, tmp1);
            g.DrawPath(Pens.Gray, tmp1);




            //// items







            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle rec = GetTabRect(i);
                Rectangle rec2 = rec;


                ////inside small 
                rec2.Width -= 3;
                rec2.Height -= 3;
                rec2.Y += 1;
                rec2.X += 1;





                if (i == SelectedIndex)
                {


                    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                    LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                    g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                    g.DrawRectangle(Pens.White, rec2);
                    g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                    g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                    g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));
                    //// circle


                    g.SmoothingMode = SmoothingMode.HighQuality;
                    //    g.DrawEllipse(New Pen(Color.FromArgb(200, 200, 200), 3), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))
                    // g.DrawEllipse(New Pen(Color.FromArgb(150, 150, 150), 1), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))


                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(rec2.X - 10, rec2.Y - 10);
                    PB3.CenterColor = Color.FromArgb(56, 142, 196);
                    PB3.SurroundColors = new [] { Color.FromArgb(64, 106, 140) };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    g.FillPath(PB3, GPF);

                    g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
                    g.SetClip(GPF);
                    g.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(rec2.X + (int)10.5, rec2.Y + 11, 6, 6));
                    g.ResetClip();



                    g.SmoothingMode = SmoothingMode.None;


                }
                else {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                    LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                    g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                    g.DrawRectangle(Pens.White, rec2);
                    g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                    g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                    g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));


                    g.FillEllipse(Brushes.LightGray, new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    g.DrawEllipse(new Pen(Color.FromArgb(100, 100, 100), 1), new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    g.SmoothingMode = SmoothingMode.None;

                }

                g.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(56, 106, 137)), rec, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }




            e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
            base.OnPaint(e);
        }
    }
    #endregion
    #region "SLCTextbox"
    [DefaultEvent("TextChanged")]
    class SLCTextBox : Control
    {

        #region " Variables"
        private TextBox TB;
        #endregion
        private MouseState State = MouseState.None;

        #region " Properties"
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            TB.Focus();
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            TB.Focus();
            Invalidate();
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (TB != null)
                {
                    TB.TextAlign = value;
                }
            }
        }
        private int _MaxLength = 32767;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (TB != null)
                {
                    TB.MaxLength = value;
                }
            }
        }
        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (TB != null)
                {
                    TB.ReadOnly = value;
                }
            }
        }
        private bool _UseSystemPasswordChar;
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (TB != null)
                {
                    TB.UseSystemPasswordChar = value;
                }
            }
        }
        private bool _Multiline;
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (TB != null)
                {
                    TB.Multiline = value;

                    if (value)
                    {
                        TB.Height = Height - 11;
                    }
                    else {
                        Height = TB.Height + 11;
                    }

                }
            }
        }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (TB != null)
                {
                    TB.Text = value;
                }
            }
        }
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (TB != null)
                {
                    TB.Font = value;
                    TB.Location = new Point(3, 5);
                    TB.Width = Width - 6;

                    if (!_Multiline)
                    {
                        Height = TB.Height + 11;
                    }
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(TB))
            {
                Controls.Add(TB);
            }
        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TB.Text;
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                TB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            TB.Location = new Point(5, 5);
            TB.Width = Width - 10;

            if (_Multiline)
            {
                TB.Height = Height - 11;
            }
            else {
                Height = TB.Height + 11;
            }

            base.OnResize(e);
        }
        #endregion

        public SLCTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);

            DoubleBuffered = true;

            TB = new TextBox();
            TB.Font = new Font("Tahoma", 8);
            TB.BackColor = Color.White;
            TB.ForeColor = Color.FromArgb(1, 75, 124);
            TB.MaxLength = _MaxLength;
            TB.Multiline = _Multiline;
            TB.ReadOnly = _ReadOnly;
            TB.UseSystemPasswordChar = _UseSystemPasswordChar;
            TB.BorderStyle = BorderStyle.None;
            TB.Location = new Point(5, 5);
            TB.Width = Width - 10;

            TB.Cursor = Cursors.IBeam;

            if (_Multiline)
            {
                TB.Height = Height - 11;
            }
            else {
                Height = TB.Height + 11;
            }

            TB.TextChanged += OnBaseTextChanged;
            TB.KeyDown += OnBaseKeyDown;
        }
        public Rectangle Borderpts()
        {
            Rectangle P = new Rectangle();


            P = new Rectangle(2, 2, Width - 5, Height - 5);
            return P;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);


            PathGradientBrush PB1 = default(PathGradientBrush);
            GraphicsPath GP1 = RoundRec(Borderpts(), 2);





            var _with1 = G;
            _with1.SmoothingMode = (SmoothingMode)2;
            _with1.TextRenderingHint = (TextRenderingHint)1;
            _with1.Clear(Color.White);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.White;
            PB1.SurroundColors = new []{ Color.FromArgb(234, 234, 234) };
            PB1.FocusScales = new PointF(0.9f, 0.5f);



            _with1.FillPath(PB1, GP1);
            _with1.DrawPath(new Pen(Color.FromArgb(125, 125, 125)), GP1);


            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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
    }
    #endregion
    #region "SLCRadioButton"
    [DefaultEvent("CheckedChanged")]
    class SLCRadionButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public SLCRadionButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.White;

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Brushes.Red);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;

                if (_Checked)
                {
                    InvalidateParent();
                }

                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        private void InvalidateParent()
        {
            if (Parent == null)
                return;

            foreach (Control C in Parent.Controls)
            {
                if ((!object.ReferenceEquals(C, this)) && (C is SLCRadionButton))
                {
                    ((SLCRadionButton)C).Checked = false;
                }
            }
        }


        private GraphicsPath GP1;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;

        private Pen P2;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = default(Graphics);
            G = e.Graphics;


            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = new GraphicsPath();
            GP1.AddEllipse(0, 2, Height - 5, Height - 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new [] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            // G.FillPath(PB1, GP1)

            G.DrawEllipse(P1, 4, 4, Height - 11, Height - 11);
            // G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)

            if (_Checked)
            {
                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Height - (int)18.5, Height - 19, 12, 12));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                PB3.CenterColor = Color.FromArgb(56, 142, 196);
                PB3.SurroundColors = new []{ Color.FromArgb(64, 106, 140) };
                PB3.FocusScales = new PointF(0.9f, 0.9f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
                G.ResetClip();
            }

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseDown(e);
        }

    }
    #endregion
    #region "SLCComboBox"
    class SLCComboBox : ComboBox
    {

        public SLCComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;


            DrawMode = DrawMode.OwnerDrawFixed;


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.Clear(Color.White);





            //inside borders



            GraphicsPath GP = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 5);
            GraphicsPath GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 5);
            GraphicsPath GP3 = RoundRec(new Rectangle(2, 2, Width - 5, Height - 5), 5);


            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP3);
            G.DrawPath(new Pen(Color.FromArgb(60, Color.LightGray), 4), GP2);
            G.DrawPath(new Pen(Color.FromArgb(100, Color.FromArgb(15, 15, 15))), GP);
            // G.DrawPath(New Pen(Color.FromArgb(60, Color.LightGray), 4), GP3)
            G.SmoothingMode = SmoothingMode.None;

            Rectangle rect1 = new Rectangle(Width - 26, 0, 1, Height);
            Rectangle rect2 = new Rectangle(Width - 27, 0, 2, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.FromArgb(1, 75, 124))), rect1);
            G.DrawRectangle(new Pen(Color.FromArgb(60, Color.FromArgb(61, 113, 153))), rect1);



            //little arrow shit

            G.SmoothingMode = SmoothingMode.HighQuality;


            G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 18, Height - 19, 8, 8), 20, 140);

            G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 18, Height - 18, 8, 8), 10, 160);
            G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), (int)1.5), new Rectangle(Width - 18, Height - 20, 8, 8), 20, 140);



            G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 19, Height - 16, 10, 10), 20, 140);

            G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 19, Height - 15, 10, 10), 10, 160);
            G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), (int)1.5), new Rectangle(Width - 19, Height - 17, 10, 10), 20, 140);
            G.SmoothingMode = SmoothingMode.None;


            PointF PT1 = new PointF(3, Height - 18);

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(1, 75, 124)), e.Bounds);
            }
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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
    }
    #endregion
    #region "SLCProgrssBar"
    class SLCProgrssBar : Control
    {

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public SLCProgrssBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);


            P2 = new Pen(Color.FromArgb(55, 55, 55));
            B1 = new SolidBrush(Color.FromArgb(0, 214, 37));
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;

        private GraphicsPath GP3;
        private Rectangle R1;

        private Rectangle R2;
        private Pen P2;
        private SolidBrush B1;
        private LinearGradientBrush GB1;

        private LinearGradientBrush GB2;

        private int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle R3 = new Rectangle();
            HatchBrush HB = default(HatchBrush);

            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.HighQuality;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);





            G.SetClip(GP1);
            //gloss
            PathGradientBrush PB = new PathGradientBrush(GP1);
            PB.CenterColor = Color.FromArgb(230, 230, 230);
            PB.SurroundColors = new []{ Color.FromArgb(255, 255, 255) };
            PB.CenterPoint = new Point(0, Height);
            PB.FocusScales = new PointF(1, 0);

            G.FillRectangle(PB, R1);

            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), RoundRec(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));

            I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3));


            if (I1 > 1)
            {




                GP3 = RoundRec(new Rectangle(1, 1, I1, Height - 3), 4);

                //grad
                HB = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.Black), Color.Transparent);



                //bar
                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(20, 34, 45), Color.FromArgb(27, 84, 121), 90f);

                G.FillPath(GB2, GP3);
                G.DrawPath(new Pen(Color.FromArgb(120, 134, 145)), GP3);

                G.SetClip(GP3);
                G.SmoothingMode = SmoothingMode.None;



                G.FillRectangle(new SolidBrush(Color.FromArgb(32, 100, 144)), R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

                R3 = new Rectangle(1, 1, I1, Height - 1);

                G.FillRectangle(HB, R3);

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.ResetClip();
            }



            G.DrawPath(new Pen(Color.FromArgb(125, 125, 125)), GP2);
            G.DrawPath(new Pen(Color.FromArgb(80, Color.LightGray)), GP1);
        }
        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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

    }
    #endregion
    #region "SLCCheckbox"
    [DefaultEvent("CheckedChanged")]
    class SLCCheckbox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public SLCCheckbox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P11 = new Pen(Color.LightGray);
            P22 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.Black, 2f);
            P4 = new Pen(Color.White, 2f);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }

                Invalidate();
            }
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P11;
        private Pen P22;
        private Pen P3;

        private Pen P4;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 2, Height - 5, Height - 5), 1);
            GP2 = RoundRec(new Rectangle(1, 3, Height - 7, Height - 7), 1);

            GraphicsPath GPF = new GraphicsPath();
            GPF.AddPath(RoundRec(new Rectangle(Height - (int)18.5, Height - 20, 14, 14), 2), true);
            PathGradientBrush PB3 = default(PathGradientBrush);
            PB3 = new PathGradientBrush(GPF);
            //  PB3.CenterPoint = New Point(Height - 18.5, Height - 21)
            PB3.CenterColor = Color.FromArgb(240, 240, 240);
            PB3.SurroundColors = new [] { Color.FromArgb(90, 90, 90) };
            PB3.FocusScales = new PointF(0.4f, 0.4f);

            HatchBrush hb = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(70, Color.FromArgb(15, 54, 80)), Color.Transparent);

            g.FillPath(PB3, GPF);
            g.FillPath(hb, GPF);


            g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
            g.SetClip(GPF);
            g.FillEllipse(new SolidBrush(Color.FromArgb(70, Color.DarkGray)), new Rectangle(Height - 16, Height - 18, 6, 6));
            g.DrawPath(Pens.White, RoundRec(new Rectangle(5, 4, Height - 11, Height - 11), 2));
            g.ResetClip();




            if (_Checked)
            {
                //g.DrawLine(Pens.Red, New PointF(7, Height - 10), New PointF(Height - 10, 5))
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), new Point(8, Height - 9), new Point(Height - 8, 6));


                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), 7, Height - 13, 8, Height - 10);


            }

            SZ1 = g.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


            g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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

    }

    #endregion
    #region "SLCListview"
    class SLCListView : Control
    {

        public class NSListViewItem
        {
            public string Text { get; set; }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public List<NSListViewSubItem> SubItems { get; set; }


            protected Guid UniqueId;
            public NSListViewItem()
            {
                UniqueId = Guid.NewGuid();
            }

            public override string ToString()
            {
                return Text;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj is NSListViewItem)
                {
                    return (((NSListViewItem)obj).UniqueId == UniqueId);
                }

                return false;
            }


        }

        public class NSListViewSubItem
        {
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class NSListViewColumnHeader
        {
            public string Text { get; set; }
            public int Width { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private List<NSListViewItem> _Items = new List<NSListViewItem>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewItem[] Items
        {
            get { return _Items.ToArray(); }
            set
            {
                _Items = new List<NSListViewItem>(value);
                InvalidateScroll();
            }
        }

        private List<NSListViewItem> _SelectedItems = new List<NSListViewItem>();
        public NSListViewItem[] SelectedItems
        {
            get { return _SelectedItems.ToArray(); }
        }

        private List<NSListViewColumnHeader> _Columns = new List<NSListViewColumnHeader>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewColumnHeader[] Columns
        {
            get { return _Columns.ToArray(); }
            set
            {
                _Columns = new List<NSListViewColumnHeader>(value);
                InvalidateColumns();
            }
        }

        private bool _MultiSelect = true;
        public bool MultiSelect
        {
            get { return _MultiSelect; }
            set
            {
                _MultiSelect = value;

                if (_SelectedItems.Count > 1)
                {
                    _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);
                }

                Invalidate();
            }
        }

        private int ItemHeight = 24;
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6;

                if (VS != null)
                {
                    VS.SmallChange = ItemHeight;
                    VS.LargeChange = ItemHeight;
                }

                base.Font = value;
                InvalidateLayout();
            }
        }

        #region " Item Helper Methods "

        //Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

        public void AddItem(string text, params string[] subItems)
        {
            List<NSListViewSubItem> Items = new List<NSListViewSubItem>();
            foreach (string I in subItems)
            {
                NSListViewSubItem SubItem = new NSListViewSubItem();
                SubItem.Text = I;
                Items.Add(SubItem);
            }

            NSListViewItem Item = new NSListViewItem();
            Item.Text = text;
            Item.SubItems = Items;

            _Items.Add(Item);
            InvalidateScroll();
        }

        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            InvalidateScroll();
        }

        public void RemoveItem(NSListViewItem item)
        {
            _Items.Remove(item);
            InvalidateScroll();
        }

        public void RemoveItems(NSListViewItem[] items)
        {
            foreach (NSListViewItem I in items)
            {
                _Items.Remove(I);
            }

            InvalidateScroll();
        }

        #endregion


        private SLCScrollBar VS;
        public SLCListView()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, true);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(62, 62, 62));
            B2 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B3 = new SolidBrush(Color.FromArgb(47, 47, 47));
            B4 = new SolidBrush(Color.FromArgb(50, 50, 50));

            VS = new SLCScrollBar();
            VS.SmallChange = ItemHeight;
            VS.LargeChange = ItemHeight;

            VS.Scroll += HandleScroll;
            VS.MouseDown += VS_MouseDown;
            Controls.Add(VS);

            InvalidateLayout();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        private void HandleScroll(object sender)
        {
            Invalidate();
        }

        private void InvalidateScroll()
        {
            VS.Maximum = (_Items.Count * ItemHeight);
            Invalidate();
        }

        private void InvalidateLayout()
        {
            VS.Location = new Point(Width - VS.Width - 1, 1);
            VS.Size = new Size(18, Height - 2);

            Invalidate();
        }

        private int[] ColumnOffsets;
        private void InvalidateColumns()
        {
            int Width = 3;
            ColumnOffsets = new int[_Columns.Count];

            for (int I = 0; I <= _Columns.Count - 1; I++)
            {
                ColumnOffsets[I] = Width;
                Width += Columns[I].Width;
            }

            Invalidate();
        }

        private void VS_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();

            if (e.Button == MouseButtons.Left)
            {
                int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));
                int Index = ((e.Y + Offset - ItemHeight) / ItemHeight);

                if (Index > _Items.Count - 1)
                    Index = -1;

                if (!(Index == -1))
                {
                    //TODO: Handle Shift key

                    if (ModifierKeys == Keys.Control && _MultiSelect)
                    {
                        if (_SelectedItems.Contains(_Items[Index]))
                        {
                            _SelectedItems.Remove(_Items[Index]);
                        }
                        else {
                            _SelectedItems.Add(_Items[Index]);
                        }
                    }
                    else {
                        _SelectedItems.Clear();
                        _SelectedItems.Add(_Items[Index]);
                    }
                }

                Invalidate();
            }

            base.OnMouseDown(e);
        }

        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private SolidBrush B4;

        private LinearGradientBrush GB1;
        //I am so sorry you have to witness this. I tried warning you. ;.;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;

            G.Clear(Color.White);

            int X = 0;
            int Y = 0;
            float H = 0;

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, Color.LightGray))), 1, 1, Width - 3, Height - 3);

            Rectangle R1 = default(Rectangle);
            NSListViewItem CI = null;

            int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));

            int StartIndex = 0;
            if (Offset == 0)
                StartIndex = 0;
            else
                StartIndex = (Offset / ItemHeight);

            int EndIndex = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1);

            for (int I = StartIndex; I <= EndIndex; I++)
            {
                CI = Items[I];

                R1 = new Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1);

                H = G.MeasureString(CI.Text, Font).Height;
                Y = R1.Y + Convert.ToInt32((ItemHeight / 2) - (H / 2));

                if (_SelectedItems.Contains(CI))
                {
                    if (I % 2 == 0)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.LightGray)), R1);
                    }
                    else {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.LightGray)), R1);
                    }
                }
                else {
                    if (I % 2 == 0)
                    {
                        G.FillRectangle(Brushes.White, R1);
                    }
                    else {
                        G.FillRectangle(Brushes.White, R1);
                    }
                }

                G.DrawLine(Pens.LightGray, 0, R1.Bottom, Width, R1.Bottom);

                if (Columns.Length > 0)
                {
                    R1.Width = Columns[0].Width;
                    G.SetClip(R1);
                }

                //TODO: Ellipse text that overhangs seperators.
                G.DrawString(CI.Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), 10, Y + 1);


                if (CI.SubItems != null)
                {
                    for (int I2 = 0; I2 <= Math.Min(CI.SubItems.Count, _Columns.Count) - 1; I2++)
                    {
                        X = ColumnOffsets[I2 + 1] + 4;

                        R1.X = X;
                        R1.Width = Columns[I2].Width;
                        G.SetClip(R1);

                        G.DrawString(CI.SubItems[I2].Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1);

                    }
                }

                G.ResetClip();
            }

            R1 = new Rectangle(0, 0, Width, ItemHeight);

            GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90f);
            G.FillRectangle(GB1, R1);
            G.SetClip(R1);
            G.FillRectangle(Brushes.White, new Rectangle(0, 0, R1.Width - 1, R1.Height / 2 - 1));
            G.ResetClip();
            G.DrawRectangle(Pens.White, 1, 1, Width - 22, ItemHeight - 2);

            int LH = Math.Min(VS.Maximum + ItemHeight - Offset, Height);

            NSListViewColumnHeader CC = null;
            for (int I = 0; I <= _Columns.Count - 1; I++)
            {
                CC = Columns[I];

                H = G.MeasureString(CC.Text, Font).Height;
                Y = Convert.ToInt32((ItemHeight / 2) - (H / 2));
                X = ColumnOffsets[I];

                G.DrawString(CC.Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1);


                G.DrawLine(Pens.LightGray, X - 3, 0, X - 3, LH);
                G.DrawLine(Pens.White, X - 2, 0, X - 2, ItemHeight);
            }

            G.DrawRectangle(Pens.LightGray, 0, 0, Width - 1, Height - 1);

            G.DrawLine(new Pen(new SolidBrush(Color.LightGray)), 0, ItemHeight, Width, ItemHeight);
            G.DrawLine(new Pen(Brushes.LightGray), VS.Location.X - 1, 0, VS.Location.X - 1, Height);

            G.FillRectangle(Brushes.White, Width - 19, 0, Width, Height);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (ItemHeight / 2));

            int Value = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum);
            VS.Value = Value;

            base.OnMouseWheel(e);
        }

    }

    #endregion
    #region "SLCScrollBar"
    [DefaultEvent("Scroll")]
    class SLCScrollBar : Control
    {

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;

                InvalidateLayout();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;

                InvalidateLayout();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                if (!ShowThumb)
                    return _Minimum;
                return _Value;
            }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                InvalidatePosition();

                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }

        public double _Percent { get; set; }
        public double Percent
        {
            get
            {
                if (!ShowThumb)
                    return 0;
                return GetProgress();
            }
        }

        private int _SmallChange = 1;
        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _SmallChange = value;
            }
        }

        private int _LargeChange = 10;
        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _LargeChange = value;
            }
        }

        private int ButtonSize = 16;
        // 14 minimum
        private int ThumbSize = 24;

        private Rectangle TSA;
        private Rectangle BSA;
        private Rectangle Shaft;

        private Rectangle Thumb;
        private bool ShowThumb;

        private bool ThumbDown;
        public SLCScrollBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Width = 18;


        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;



        int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;
            G.Clear(Color.FromArgb(255, 255, 255));

            GP1 = DrawArrow(4, 6, false);
            GP2 = DrawArrow(5, 7, false);

            G.FillPath(new SolidBrush(Color.LightGray), GP2);
            G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP1);

            GP3 = DrawArrow(4, Height - 11, true);
            GP4 = DrawArrow(5, Height - 10, true);

            G.FillPath(new SolidBrush(Color.LightGray), GP4);
            G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP3);

            if (ShowThumb)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), Thumb);
                G.DrawRectangle(Pens.LightGray, Thumb);
                G.DrawRectangle(Pens.White, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

                int Y = 0;
                int LY = Thumb.Y + (Thumb.Height / 2) - 3;

                for (int I = 0; I <= 2; I++)
                {
                    Y = LY + (I * 3);

                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(68, 95, 127))), Thumb.X + 5, Y, Thumb.Right - 5, Y);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(50, Color.FromArgb(68, 95, 127)))), Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1);
                }
            }
            G.SmoothingMode = SmoothingMode.HighQuality;
            //G.DrawRectangle(New Pen(New SolidBrush(Color.Red)), 0, 0, Width - 1, Height - 1)
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(59, 122, 165))), RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4));
            G.SmoothingMode = SmoothingMode.None;
        }

        private GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            GraphicsPath GP = new GraphicsPath();

            int W = 9;
            int H = 5;

            if (flip)
            {
                GP.AddLine(x + 1, y, x + W + 1, y);
                GP.AddLine(x + W, y, x + H, y + H - 1);
            }
            else {
                GP.AddLine(x, y + H, x + W, y + H);
                GP.AddLine(x + W, y + H, x + H, y);
            }

            GP.CloseFigure();
            return GP;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        private void InvalidateLayout()
        {
            TSA = new Rectangle(0, 0, Width, ButtonSize);
            BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
            Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1);

            ShowThumb = ((_Maximum - _Minimum) > Shaft.Height);

            if (ShowThumb)
            {
                //ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
                Thumb = new Rectangle(1, 0, Width - 3, ThumbSize);
            }

            if (Scroll != null)
            {
                Scroll(this);
            }
            InvalidatePosition();
        }

        private void InvalidatePosition()
        {
            Thumb.Y = Convert.ToInt32(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (TSA.Contains(e.Location))
                {
                    I1 = _Value - _SmallChange;
                }
                else if (BSA.Contains(e.Location))
                {
                    I1 = _Value + _SmallChange;
                }
                else {
                    if (Thumb.Contains(e.Location))
                    {
                        ThumbDown = true;
                        base.OnMouseDown(e);
                        return;
                    }
                    else {
                        if (e.Y < Thumb.Y)
                        {
                            I1 = _Value - _LargeChange;
                        }
                        else {
                            I1 = _Value + _LargeChange;
                        }
                    }
                }

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ThumbDown && ShowThumb)
            {
                int ThumbPosition = e.Y - TSA.Height - (ThumbSize / 2);
                int ThumbBounds = Shaft.Height - ThumbSize;

                I1 = Convert.ToInt32((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbDown = false;
            base.OnMouseUp(e);
        }

        private double GetProgress()
        {
            return (_Value - _Minimum) / (_Maximum - _Minimum);
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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
    }
    #endregion
    #region "SLCOnOffBox"
    [DefaultEvent("CheckedChanged")]
    class SLCOnOffBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);


        protected MouseState State;

        public SLCOnOffBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(35, 35, 35));
            B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
            B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B4 = new SolidBrush(Color.FromArgb(205, 150, 0));
            B5 = new SolidBrush(Color.FromArgb(40, 40, 40));

            SF1 = new StringFormat();
            SF1.LineAlignment = StringAlignment.Center;
            SF1.Alignment = StringAlignment.Near;

            SF2 = new StringFormat();
            SF2.LineAlignment = StringAlignment.Center;
            SF2.Alignment = StringAlignment.Far;

            Size = new Size(56, 24);
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }

                Invalidate();
            }
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private SolidBrush B4;

        private SolidBrush B5;
        private PathGradientBrush PB1;

        private LinearGradientBrush GB1;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        private StringFormat SF1;

        private StringFormat SF2;

        private int Offset;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(250, 250, 250);
            PB1.SurroundColors = new [] { Color.FromArgb(245, 245, 245) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            G.FillPath(PB1, GP1);
            G.DrawPath(Pens.LightGray, GP1);
            G.DrawPath(Pens.White, GP2);

            R1 = new Rectangle(5, 0, Width - 10, Height + 2);
            R2 = new Rectangle(6, 1, Width - 10, Height + 2);

            R3 = new Rectangle(1, 1, (Width / 2) - 1, Height - 3);



            if (_Checked)
            {
                // G.DrawString("On", Font, Brushes.Black, R2, SF1)
                G.DrawString("On", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF1);

                R3.X += (Width / 2) - 1;
            }
            else {
                //G.DrawString("Off", Font, B1, R2, SF2)
                G.DrawString("Off", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF2);
            }

            GP3 = RoundRec(R3, 7);
            GP4 = RoundRec(new Rectangle(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2), 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90f);

            G.FillPath(GB1, GP3);
            G.DrawPath(Pens.LightGray, GP3);
            G.DrawPath(Pens.White, GP4);


            Offset = R3.X + (R3.Width / 2) - 3;

            for (int I = 0; I <= 1; I++)
            {
                if (_Checked)
                {
                    //G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }
                else {
                    // G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }

                G.SmoothingMode = SmoothingMode.None;


                if (_Checked)
                {
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 17, 10, 10));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                    PB3.CenterColor = Color.FromArgb(53, 152, 74);
                    PB3.SurroundColors = new [] { Color.FromArgb(86, 216, 114) };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(85, 200, 109)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();


                    //  G.FillRectangle(New SolidBrush(Color.FromArgb(85, 158, 203)), Offset + (I * 5), 7, 2, Height - 14)
                }
                else {
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Height - 15, Height - 17, 10, 10));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                    PB3.CenterColor = Color.FromArgb(185, 65, 65);
                    PB3.SurroundColors = new [] { Color.Red };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(152, 53, 53)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
                    G.ResetClip();



                    //  G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
            base.OnMouseDown(e);
        }

    }
    #endregion
    #region "SLCGroupBox"
    class SLCGroupBox : ContainerControl
    {

        private bool _DrawSeperator;
        public bool DrawSeperator
        {
            get { return _DrawSeperator; }
            set
            {
                _DrawSeperator = value;
                Invalidate();
            }
        }

        private string _Title = "GroupBox";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Invalidate();
            }
        }

        private string _SubTitle = "Details";
        public string SubTitle
        {
            get { return _SubTitle; }
            set
            {
                _SubTitle = value;
                Invalidate();
            }
        }

        private Font _TitleFont;

        private Font _SubTitleFont;
        public SLCGroupBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            _TitleFont = new Font("Verdana", 10f);
            _SubTitleFont = new Font("Verdana", 6.5f);


        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private PointF PT1;
        private SizeF SZ1;

        private SizeF SZ2;



        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;


            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);


            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP2);
            G.SetClip(GP2);
            PathGradientBrush PB = new PathGradientBrush(GP2);
            PB.CenterColor = Color.FromArgb(255, 255, 255);
            PB.SurroundColors = new []{ Color.FromArgb(250, 250, 250) };
            PB.FocusScales = new PointF((int)0.95, (int)0.95);
            G.FillPath(PB, GP2);
            G.ResetClip();

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(70, Color.LightGray))), GP1);
            G.DrawPath(Pens.Gray, GP2);

            SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
            SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);


            G.DrawString(_Title, _TitleFont, new SolidBrush(Color.FromArgb(1, 75, 124)), 5, 5);

            PT1 = new PointF(6f, SZ1.Height + 4f);


            G.DrawString(_SubTitle, _SubTitleFont, new SolidBrush(Color.Black), PT1.X, PT1.Y);


        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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

    }
    #endregion
    #region "SLCContextMenu"
    class SLCContextMenu : ContextMenuStrip
    {

        public SLCContextMenu()
        {
            Renderer = new ToolStripProfessionalRenderer(new SLCColorTable());
            ForeColor = Color.FromArgb(1, 75, 124);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            base.OnPaint(e);
        }

    }

    #endregion
    #region "SCLCT"

    class SLCColorTable : ProfessionalColorTable
    {


        private Color BackColor = Color.White;
        public override Color ButtonSelectedBorder
        {
            get { return BackColor; }
        }

        public override Color CheckBackground
        {
            get { return BackColor; }
        }

        public override Color CheckPressedBackground
        {
            get { return BackColor; }
        }

        public override Color CheckSelectedBackground
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return BackColor; }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(1, 75, 124); }
        }

        public override Color MenuItemBorder
        {
            get { return BackColor; }
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(50, Color.LightGray); }
        }

        public override Color SeparatorDark
        {
            get { return Color.FromArgb(35, 35, 35); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return BackColor; }
        }

    }
    #endregion
    #region "SLCLABEL"
    class SLCLabel : Control
    {
        Label lb = new Label();
        public SLCLabel()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Verdana", 8f, FontStyle.Regular);
            Size = new Size(39, 13);


        }

        private string _text = "SLCLabel";
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate();
            }
        }


        private PointF PT1;

        private SizeF SZ1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;

            G.Clear(Color.White);


            PT1 = new PointF(0, 0);

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);

        }

    }
    #endregion
    #region "SLCClose"
    class SLCClose : ThemeControl154
    {
        Label LB = new Label();

        protected override void ColorHook()
        {
        }

        public SLCClose()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(20, 20);


        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.White);
            G.FillRectangle(new SolidBrush(Color.FromArgb(239, 239, 239)), new Rectangle(-1, -1, Width + 1, Height + 1));



            switch (State)
            {
                case MouseState.None:


                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                    PB3.CenterColor = Color.FromArgb(193, 26, 26);
                    PB3.SurroundColors =new [] { Color.FromArgb(229, 110, 110) };
                    PB3.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
                case MouseState.Down:
                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                    PB3.CenterColor = Color.FromArgb(221, 32, 32);
                    PB3.SurroundColors = new [] { Color.FromArgb(229, 110, 110) };
                    PB3.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.White), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
                case MouseState.Over:
                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(Height - (int)18.5, Height - 20);
                    PB3.CenterColor = Color.FromArgb(221, 32, 32);
                    PB3.SurroundColors = new [] { Color.FromArgb(229, 110, 110) };
                    PB3.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
            }

        }
    }
    #endregion
















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
