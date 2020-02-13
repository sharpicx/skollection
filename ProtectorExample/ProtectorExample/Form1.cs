using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Cecil;

namespace ProtectorExample
{
    public partial class Form1 : Form
    {
        #region Shit Code
        const string zhit = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلاىةوزظذضصثقفغشسيبلاعتهنمةحجدئءسلارىلتةنم___________________xaksdasjdasdjasd_____-";
        const string shetz = "______________LOLASDFGHJKLMN12_____ASD___AQWERTYUI___klklklasmdsakdn0q9i38e1456";
        private AssemblyDefinition noob;
        Random rand = new Random();
        private void Renameshit(AssemblyDefinition lol)
        {
            TypeDefinition elz = null;
            foreach(TypeDefinition x in lol.MainModule.Types)
            {
                if (x.Name != "<Module>")
                {
                    x.Name = Rando(12);
                }
            }

        }
        private void Renameasd(AssemblyDefinition aahf)
        {
            TypeDefinition lol = null;
            MethodDefinition asd = null;
            foreach (TypeDefinition k in aahf.MainModule.Types)
            {
                foreach(MethodDefinition qwe in k.Methods )
                {
                    qwe.Name = Rando(12);
                }
            }
        }

        public string Rando(int aaa)
        {
            char[] buffer = new char[aaa];
            for (int i = 0; i < aaa; i++)
            {
                buffer[i] = zhit[rand.Next(zhit.Length)];
            }
            return new string(buffer);
        }
        public string Randoo(int aaa)
        {
            char[] buffer = new char[aaa];
            for (int i = 0; i < aaa; i++)
            {
                buffer[i] = shetz[rand.Next(shetz.Length)];
            }
            return new string(buffer);
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Protector made by Skofos, this software under MIT License", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("https://sko0o.github.io");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".exe | *.exe";
            sfd.FileName = String.Format("{0}_protected", Path.GetFileNameWithoutExtension(textBox1.Text));
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (checkBox1.Checked)
                {
                    Renameshit(noob);
                }
                if (checkBox2.Checked)
                {
                    Renameasd(noob);
                }
                noob.Write(sfd.FileName);
                MessageBox.Show("Protecting File is Done!","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".exe | *.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                noob = AssemblyDefinition.ReadAssembly(textBox1.Text);
            }
        }
    }
}
