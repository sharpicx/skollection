using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ReterBatch_IDE
{
    public partial class Form1 : Form
    {
        private string FileName;
        private bool Disimpan;
        string path = @"C:\ZMXENKCDQ\RNEZQ\Zfzhm\Zfzhm\Zfzhm\Zfzhm";
        string file = @"C:\ZMXENKCDQ\RNEZQ\Zfzhm\Zfzhm\Zfzhm\Zfzhm\thisIsAnExampleRunningWindows.bat";
        public Form1()
        {
            InitializeComponent();
        }

        private void VisualBasicVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Version is Cooming Soon and will be added on My Github", "Message From the Coder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("https://github.com/sko0o");
        }

        private void AboutTheSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The First Version of IDE, Lazy to make Form About Section :D and btw please dont steal this code without my permission YOU: (for what ur code to used for?)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
            a:;
            StreamWriter Streamlol = new StreamWriter(file);
            Streamlol.Write(shitText.Text);
            Streamlol.Close();
            if (System.IO.File.Exists(file))
                Process.Start(file);
            else
                goto a;

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                shitText.Text = File.ReadAllText(fileName);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && !Disimpan)
            {
                FileName = saveFileDialog1.FileName;
                using (Stream suck = File.Open(saveFileDialog1.FileName, FileMode.Create))
                using (StreamWriter sucked = new StreamWriter(suck))
                {
                    sucked.Write(shitText.Text);
                }
            }

            if (Disimpan)
            {
                using (Stream suck = File.Open(saveFileDialog1.FileName, FileMode.Create))
                using (StreamWriter sucked = new StreamWriter(suck))
                {
                    sucked.Write(shitText.Text);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TutorialPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tutorialspoint.com/batch_script/index.htm");
        }

        private void HackForumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://hackforums.net/forumdisplay.php?fid=49");
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ShitText_Load(object sender, EventArgs e)
        {
            FileSyntaxModeProvider fileSMP;
            if (Directory.Exists(Application.StartupPath))
            {
                fileSMP = new FileSyntaxModeProvider(Application.StartupPath);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fileSMP);
                shitText.SetHighlighting("BAT");
            }
        }
    }
}
