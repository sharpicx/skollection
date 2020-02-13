using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HotkeyExample
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //Var
        const int Hotkey_WM = 0x0312;

        //Boolean for activing the hotkey
        Boolean HotkeyF1a = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //                          ID Keys        Keys
            RegisterHotKey(this.Handle, 1, 0, (int)Keys.F1); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //                            ID
            UnregisterHotKey(this.Handle, 1);
            e.Cancel = true;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkey_WM && (int)m.WParam == 1)
            {
                //if hotkey disabled
                //enabled it
                if (HotkeyF1a == false)
                {
                    timer1.Start();
                    hotkeyLabel.ForeColor = Color.Green;
                    hotkeyLabel.Text = "F1 - Spam (ON)";
                    HotkeyF1a = true;
                }
                //if hotkey enabled
                //disabled it
                else if (HotkeyF1a == true)
                {
                    timer1.Stop();
                    hotkeyLabel.ForeColor = Color.Red;
                    hotkeyLabel.Text = "F1 - Spam (OFF)";
                    HotkeyF1a = false;
                }
            }
            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(lolbox.Text);
            SendKeys.Send("{ENTER}");
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
