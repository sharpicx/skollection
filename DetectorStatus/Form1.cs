using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectorExample
{
    public partial class Form1 : Form
    {
        /*
         Made by: Skofos @ www.hackforums.net @ https://www.github.com/sko0o
         */
        #region DLLSHIT
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr ProcessName(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
#endregion

        private bool processJalan = false;
        bool lol = false;
        long baseAddress = 0;

        //trash string
        static string process;


        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
        	string focused = "Running (Focused)"; string notFocused = "Running (Not Focused);"; // just a shit string to help another function
            process = (procText.Text); // this too lol
            string proclabel = ("Process (" + process + "): ");
            Process[] nothing = Process.GetProcessesByName(process); // get a process from textbox
            if (nothing.Length == 0)
            {
            // check the process is not running
                lol = false;
                processJalan = false;
                loolproc.ForeColor = Color.DarkRed;
                loolproc.Text = (proclabel + "Not Running");
            }
            else
            {
                foreach (Process proc in nothing)
                {
                    int num = 256;
                    StringBuilder builder = new StringBuilder(num);
                    IntPtr foregroundHandle = GetForegroundWindow();
                    GetWindowText(foregroundHandle, builder, num);
                    if (builder.ToString().ToLower().Contains(process))
                    {
                        processJalan = true; //Process is running
                        loolproc.ForeColor = Color.ForestGreen;
                        loolproc.Text = (proclabel + focused);
                    }
                    else
                    {
                        processJalan = true; // Process is running but not focused
                        loolproc.ForeColor = Color.Orange;
                        loolproc.Text = (proclabel + notFocused);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ProcText_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
