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
        public static Socket s_ctrl = new Socket(SocketType.Stream, ProtocolType.Tcp);
        public static Socket s_chat = new Socket(SocketType.Stream, ProtocolType.Tcp);
        public static Socket s_file = new Socket(SocketType.Stream, ProtocolType.Tcp);
        public static bool ActiveC = false;
        public static byte[] AES_Key = new byte[32];
        public static byte[] AES_IV = new byte[16];
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
