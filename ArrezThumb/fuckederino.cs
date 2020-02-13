using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArrezThumb
{
    public class fuckederino
    {
        static string kek = "/maxresdefault.jpg";
        static string noob = "/hqdefault.jpg";
        private static string ________(string ___)
        {
            try
            {
                string __________ = ___.Split(new char[] { '=' })[1];
                try
                {
                    if(__________.Contains("&"))  
                        __________ = __________.Split(new char[] { '&' })[1];
                }
                catch (Exception) { }
                return __________;
            }
            catch (Exception)
            {
                return "";
            }
        }
        private enum Type
        {
            __,
            ___
        }
        private static string ___(string ____a, Type a)
        {
            if (a == Type.__)
                return "https://i.ytimg.com/vi/" + ____a + kek;
            if (a == Type.___)
                return "https://i.ytimg.com/vi/" + ____a + noob;
            else
                return "";
        }
        private static Image ___________(string ooo)
        {
            var fuck = new WebClient();
            Stream __________ = null;
            try
            {
                try
                {
                    __________= fuck.OpenRead(___(ooo, Type.__));
                }
                catch (Exception)
                {
                    __________ = fuck.OpenRead(___(ooo, Type.___));
                }
            }
            catch (Exception) { return null; }
            Image __ = Image.FromStream(__________);
            __________.Close();
            return __;
        }
        public static Image __(string aaa)
        {
            string fuc = ________(aaa);
            if(String.IsNullOrEmpty(fuc))
            {
                return null;
            }
            Image _________k = ___________(fuc);
            return _________k;
        }
    }
}
