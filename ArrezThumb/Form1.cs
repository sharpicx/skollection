using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArrezThumb.Properties;

namespace ArrezThumb
{
    // Made by Skofos
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // aaa = location
        // suckadick = save a thumbnail.
        private static Image neeb { get; set; }
        private bool suckadick(string aaabbbccc)
        {
            if (File.Exists(aaabbbccc))
            {
                DialogResult nigga = MessageBox.Show("File Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (nigga == DialogResult.No)
                {
                    return false;
                }
            }

            FileStream suck = File.Create(aaabbbccc);

            byte[] lolbytes = lmao();

            suck.Write(lolbytes, 0, lolbytes.Length);
            suck.Close();
            return true;

            byte[] lmao()
            {
                var k = new MemoryStream();
                neeb.Save(k, ImageFormat.Jpeg);
                return k.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("No Path or URL set!");
                return;
            }
            if (neeb == null)
                return;

            if (suckadick(textBox1.Text))
                MessageBox.Show("Download Success!");
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtURL.Text))
            {
                neeb = fuckederino.__(txtURL.Text);
                if (neeb != null)
                {
                    thumBox.Image = neeb;
                }
                else
                {
                    
                }
            }
        }
        
        //lmao lazy to code xd
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult __ = ___.ShowDialog();
            if (__ == DialogResult.Yes || __ == DialogResult.OK)
            {
                Settings.Default._____ = ___.FileName;
                textBox1.Text = ___.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default._____;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
