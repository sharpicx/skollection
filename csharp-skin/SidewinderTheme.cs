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
    //Sidewinder Theme.
    //Made by AeroRev9.

    public static class Helpers
    {

     
        public static Rectangle FullRectangle(Size S, bool Subtract)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
            }
            else {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        public static Color GreyColor(uint G)
        {
            return Color.FromArgb((int)G, (int)G, (int)G);
        }

        public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point(R.Width / 2 - (int)(TS.Width / 2), R.Height / 2 - (int)(TS.Height / 2)));
            }
        }


        public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
                G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
            }

        }


        public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            }

        }

        public enum Direction : byte
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }

        public static void DrawTriangle(Graphics G, Rectangle Rect, Direction D, Color C)
        {
            int halfWidth = Rect.Width / 2;
            int halfHeight = Rect.Height / 2;
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;

            switch (D)
            {
                case Direction.Up:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Top);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Down:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Bottom);
                    p1 = new Point(Rect.Left, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Top);

                    break;
                case Direction.Left:
                    p0 = new Point(Rect.Left, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Right, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Right:
                    p0 = new Point(Rect.Right, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Left, Rect.Top);

                    break;
            }

            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPolygon(B, new Point[] {
                p0,
                p1,
                p2
            });
            }

        }

    }

    public class SideWinderTab : TabControl
    {

        #region " Helpers "



        #endregion

        #region " Drawing "
        private Graphics G;
        private Rectangle Rect;
        private int LastIndex;

        private Color BackgroundC = Color.FromArgb(102, 105, 112);
        private int _Index = -1;
        private int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                Invalidate();
            }
        }

        public SideWinderTab()
        {
            DoubleBuffered = true;
            ItemSize = new Size(40, 170);
            Alignment = TabAlignment.Left;
            SizeMode = TabSizeMode.Fixed;
            Dock = DockStyle.Fill;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.BackColor = Color.White;
            e.Control.ForeColor = Color.FromArgb(72, 75, 82);
            e.Control.Font = new Font("Segoe UI", 10);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.FromArgb(72, 75, 82));


            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                Rect = GetTabRect(i);


                if (string.IsNullOrEmpty(TabPages[i].ToString()))
                {

                    if (SelectedIndex == i)
                    {
                        //Fill selected
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(90, 93, 100)))
                        {
                            G.FillRectangle(B, new Rectangle(Rect.X, Rect.Y + 2, Rect.Width, Rect.Height));
                        }

                        //Triangles
                        Helpers.DrawTriangle(G, new Rectangle(Rect.X + 158, (int)Rect.Y + (int)8.5f, 16, 25),Helpers.Direction.Left ,Color.FromArgb(62, 65, 72));
                        Helpers.DrawTriangle(G, new Rectangle(Rect.X + 160, (int)Rect.Y + (int)8.5f, 16, 25), Helpers.Direction.Left, TabPages[i].BackColor);


                    }
                    else {
                        //Fill not selected
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(72, 75, 82)))
                        {
                            G.FillRectangle(B, Rect);
                        }

                    }

                    //OverFill not selected

                    if (!(Index == -1) & !(SelectedIndex == Index))
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(82, 85, 92)))
                        {
                            G.FillRectangle(B, GetTabRect(Index));
                        }

                        //OverText
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                        {
                            G.DrawString(TabPages[Index].Text, new Font("Segoe UI", 10), B, new Point(GetTabRect(Index).X + 55, GetTabRect(Index).Y + 12));
                        }

                        //Images
                        if ((ImageList != null))
                        {
                            if (!(TabPages[Index].ImageIndex < 0))
                            {
                                G.DrawImage(ImageList.Images[TabPages[Index].ImageIndex], new Rectangle(GetTabRect(Index).X + 25, GetTabRect(Index).Y + ((GetTabRect(Index).Height / 2) - 9), 18, 18));
                            }
                        }

                    }


                    if (!(i == Index))
                    {
                        //Texts
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                        {
                            G.DrawString(TabPages[i].Text, new Font("Segoe UI", 10), B, new Point(Rect.X + 55, Rect.Y + 12));
                        }

                        //Images
                        if ((ImageList != null))
                        {
                            if (!(TabPages[i].ImageIndex < 0))
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Rectangle(Rect.X + 25, Rect.Y + ((Rect.Height / 2) - 9), 18, 18));
                            }
                        }

                    }
                }
                else {
                    //Headers
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(158, 160, 157)))
                    {
                        G.DrawString(TabPages[i].Text.ToUpper(), new Font("Segoe UI semibold", 9), B, new Point(Rect.X + 25, Rect.Y + 18));
                    }

                }

            }

        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);

            if ((e.TabPage != null))
            {
                if (!string.IsNullOrEmpty(e.TabPage.ToString()))
                {
                    e.Cancel = true;
                }
                else {
                    Index = -1;
                }
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                if (GetTabRect(i).Contains(e.Location) & !(SelectedIndex == i) & string.IsNullOrEmpty(TabPages[i].Text))
                {
                    Index = i;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Index = -1;
        }

        #endregion

    }

    public class SideWinderProgress : Control
    {

        #region " Drawing "

        private int _Val = 0;
        private int _Min = 0;

        private int _Max = 100;
        public int Value
        {
            get { return _Val; }
            set
            {
                _Val = value;
                Invalidate();
            }
        }

        public int Minimum
        {
            get { return _Min; }
            set
            {
                _Min = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _Max; }
            set
            {
                _Max = value;
                Invalidate();
            }
        }

        public SideWinderProgress()
        {
            DoubleBuffered = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            //G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.White);

            if (!(Value == 0))
            {
                Helpers.FillRoundRect(G, new Rectangle(0, 0, Value / Maximum * Width - 1, Height - 1), 8, Color.FromArgb(213, 228, 150));
            }

            Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 8, Color.FromArgb(232, 235, 242));

        }

        #endregion

    }

    public class SideWinderAlert : Control
    {

        #region " Drawing "

        private Graphics G;

        private Style _Alert;
        public bool Centered { get; set; }
        public bool Field { get; set; }

        public enum Style : byte
        {
            Notice = 0,
            Informations = 1,
            Warning = 2,
            Success = 3
        }

        public Style Alert
        {
            get { return _Alert; }
            set
            {
                _Alert = value;
                Invalidate();
            }
        }

        public SideWinderAlert()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint =TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);

            switch (Alert)
            {

                case Style.Notice:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(188, 232, 241));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(217, 237, 247));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), new Rectangle(20, 0, Width, Height));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), Helpers.FullRectangle(Size, false));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;

                case Style.Informations:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(251, 238, 213));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(252, 248, 227));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), new Rectangle(20, 0, Width, Height));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), Helpers.FullRectangle(Size, false));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;
                case Style.Warning:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(238, 211, 215));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(242, 222, 222));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), new Rectangle(20, 0, Width, Height));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), Helpers.FullRectangle(Size, false));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;
                default:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(214, 233, 198));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(223, 240, 216));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), new Rectangle(20, 0, Width, Height));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), Helpers.FullRectangle(Size, false));
                        }
                        else {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }
                    break;
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!Field)
            {
                Height = 37;
            }
        }

        #endregion

    }

    public class SideWinderBlock : GroupBox
    {

        #region " Drawing "


        private Graphics G;
        public SideWinderBlock()
        {
            DoubleBuffered = true;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.White);

            using (Pen P = new Pen(Color.FromArgb(220, 220, 220)) { DashStyle = DashStyle.Dash })
            {

                G.DrawRectangle(P, Helpers.FullRectangle(Size, true));
            }

        }


        #endregion


    }

    public class SideWinderSeparator : Control
    {

        #region " Drawing "


        private Graphics G;
        public SideWinderSeparator()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Color.FromArgb(232, 235, 242)) { DashStyle = DashStyle.Dash })
            {
                G.DrawLine(P, new Point(0, 0), new Point(Width, 0));
            }

        }

        #endregion

    }

    public class SideWinderBlockQuote : Control
    {

        #region " Drawing "


        private Graphics G;
        public string Title { get; set; }

        public string Description { get; set; }

        public SideWinderBlockQuote()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Color.FromArgb(102, 105, 112), 3))
            {
                G.DrawLine(P, new Point(3, 0), new Point(3, Height));
            }

            if (!string.IsNullOrEmpty(Title))
            {
                using (SolidBrush B = new SolidBrush(Color.FromArgb(112, 115, 122)))
                {
                    G.DrawString(Title.ToUpper(), new Font("Segoe UI semibold", 11), B, new Point(13, 0));
                }
            }

            using (SolidBrush B = new SolidBrush(Color.FromArgb(92, 95, 112)))
            {
                G.DrawString(Description, new Font("Segoe UI", 10), B, new Point(13, 23));
            }

        }

        #endregion

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
