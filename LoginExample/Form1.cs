using LoginForumz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://atom0s.com/forums/ucp.php?mode=register");
        }
        private bool fucked;
        private void Button1_Click(object sender, EventArgs e)
        {
            fucked = true;
            webBrowser1.Document.GetElementById("username").SetAttribute("value", lolname.Text);
            webBrowser1.Document.GetElementById("password").SetAttribute("value", lolpassword.Text);
            HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
            foreach(HtmlElement el in elc)
            {
                if (el.GetAttribute("type").Equals("submit"))
                {
                    el.InvokeMember("Click");
                }
            }
        }
        Form2 lol = new Form2();
        string usernamexd;
        string forgotpassword = "http://atom0s.com/forums/ucp.php?mode=register";
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (fucked == true)
            {
                usernamexd = (lolname.Text);
                fucked = false;
                if(webBrowser1.DocumentText.Contains("General"))
                {
                    MessageBox.Show("Welcome " + usernamexd);
                    lol.Show();
                    this.Hide();
                    webBrowser1.Navigate("http://atom0s.com/forums/ucp.php?mode=login");
                }
                else
                {
                    webBrowser1.Navigate("http://atom0s.com/forums/ucp.php?mode=login");
                    MessageBox.Show("Don't have an account? Register Now");
                    Process.Start(forgotpassword);
                }
            }
            else if (fucked == false)
            {
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
