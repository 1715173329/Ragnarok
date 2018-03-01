using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ragnarok
{
    public static class PUB
    {
        public static Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);
        public static bool ActiveC = false;
    }
    static class Rg
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login_Form f1 = new Login_Form();
            f1.Show();
            Application.Run();
        }
    }
}
