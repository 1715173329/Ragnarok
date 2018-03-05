using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cipher;
namespace Ragnarok
{
    public partial class Chat_Form : Form
    {
        
        Properties.Settings CFG = new Properties.Settings();
        public string pubkey;
        public string privkey;
        public string pubkey4send;
        public int counter;
        public byte[] bytesReceived = new byte[1024];
        public Form f1;
        //public byte[] AES_Key = new byte[32];
        //public byte[] AES_IV = new byte[16];
        

        public Chat_Form(Login_Form tf1)
        {
            InitializeComponent();
            f1 = tf1;
            TargetID_Lable.Text = "正在与 " + CFG.TargetID + " 聊天：";
            RSA_module.RSA_pair(out pubkey, out privkey);
            Thread Sh = new Thread(new ThreadStart(ShakeHand));
            Sh.Start();
            Sh.Join();
            Thread ChT = new Thread(new ThreadStart(OpenChat_tunnel));
            ChT.Start();
        }

        private void FLformOpen(string s)
        {
            Form f3 = new File_Form();
            f3.Show();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RecvBox.SelectionStart = RecvBox.Text.Length;
            RecvBox.ScrollToCaret();
        }

        private void SendMSG_Button_Click(object sender, EventArgs e)
        {
            if (TransBox.Text != "")
            {
                DateTime dt = DateTime.Now;
                RecvBox.AppendText(dt.ToString() + "   " + CFG.UserID + ":" + Environment.NewLine);
                RecvBox.AppendText(TransBox.Text + Environment.NewLine);
                byte[] sendcache = AES_module.AES_Encrypt(Encoding.UTF8.GetBytes(TransBox.Text), PUB.AES_Key, PUB.AES_IV);
                PUB.s_chat.Send(sendcache);
                TransBox.Clear();
                TransBox.Focus();
            }
        }
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                DateTime dt = DateTime.Now;
                RecvBox.AppendText(dt.ToString() + "   " + CFG.UserID + ":" + Environment.NewLine);
                RecvBox.AppendText(TransBox.Text + Environment.NewLine);
                byte[] sendcache = AES_module.AES_Encrypt(Encoding.UTF8.GetBytes(TransBox.Text), PUB.AES_Key, PUB.AES_IV);
                PUB.s_chat.Send(sendcache);
                TransBox.Clear();
                TransBox.Focus();
            }
         }

        private void Recv()
        {
            Action<string> Show_Recv = new Action<string>(RecvboxFresh);
            try
            {
                while (true)
                {
                    counter = PUB.s_chat.Receive(bytesReceived, bytesReceived.Length, 0);
                    byte[] cipherbyte = new byte[counter];
                    Array.Copy(bytesReceived, 0, cipherbyte, 0, counter);
                    byte[] plainbytes = AES_module.AES_Decrypt(cipherbyte, PUB.AES_Key, PUB.AES_IV);
                    string plaintext = Encoding.UTF8.GetString(plainbytes);
                    Invoke(Show_Recv, plaintext);
                }
            }
            catch (SocketException e)
            {
            }
        }
        private void RecvboxFresh(string text)
        {
            DateTime dt = DateTime.Now;
            RecvBox.AppendText(dt.ToString() + "   " + CFG.TargetID + ":" + Environment.NewLine);
            RecvBox.AppendText(text + Environment.NewLine);
        }

        

        private void ShakeHand()
        {
            
            if (PUB.ActiveC)
            {

                PUB.s_ctrl.Send(Encoding.UTF8.GetBytes(pubkey));

                counter = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                pubkey4send = Encoding.UTF8.GetString(bytesReceived, 0, counter);

                AES_module.AES_Initialize(out PUB.AES_Key, out PUB.AES_IV);
                byte[] AES_Complex = AES_join(PUB.AES_Key, PUB.AES_IV);
                byte[] cipherkey = RSA_module.RSAEncrypt(AES_Complex, pubkey4send);
                PUB.s_ctrl.Send(cipherkey);
                
            }
            else
            {
                counter = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                pubkey4send = Encoding.UTF8.GetString(bytesReceived, 0, counter);

                PUB.s_ctrl.Send(Encoding.UTF8.GetBytes(pubkey));

                counter = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                byte[] cipherkey = new byte[counter];
                Array.Copy(bytesReceived, 0, cipherkey, 0, counter);

                byte[] AES_Complex = RSA_module.RSADecrypt(cipherkey, privkey);
                Buffer.BlockCopy(AES_Complex, 0, PUB.AES_Key, 0, 32);
                Buffer.BlockCopy(AES_Complex, 32, PUB.AES_IV, 0, 16);
                
            }
        }
        private byte[] AES_join(byte[] Key,byte[] IV)
        {
            byte[] AES_Complex = new byte[Key.Length + IV.Length];
            Buffer.BlockCopy(Key, 0, AES_Complex, 0, Key.Length);
            Buffer.BlockCopy(IV, 0, AES_Complex, Key.Length, IV.Length);
            Console.WriteLine(AES_Complex.Length.ToString());
            return AES_Complex;
        }
        private void Established(string i)
        {
            SendMSG_Button.Enabled = true;
            Thread Rx = new Thread(new ThreadStart(Recv));
            Rx.Start();
            Thread LC = new Thread(new ThreadStart(Listen_Ctrl));
            LC.Start();
        }

        private void Listen_Ctrl()
        {
            Thread FlT = new Thread(new ThreadStart(OpenFile_tunnel));
            int tmp;
            string Commander;
            try
            {
                while (true)
                {
                    tmp = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                    Commander = Encoding.UTF8.GetString(bytesReceived, 0, tmp);
                    //
                    if (Commander == "File")
                    {
                        PUB.ActiveC = false;
                        var dr = MessageBox.Show("老司机" + CFG.TargetID + "师傅发福利要吗", "没时间解释了快上车", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {

                            PUB.s_ctrl.Send(Encoding.UTF8.GetBytes("Accepted"));
                            FlT.Start();

                        }
                        else
                            PUB.s_ctrl.Send(Encoding.UTF8.GetBytes("Denied"));
                    }
                    else if (Commander == "Accepted")
                    {
                        FlT.Start();
                    }
                    else if (Commander == "Denied")
                    {
                        var result = MessageBox.Show("老司机，停车接受我们的吊♂叉！", "净网行动", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }

                }
            }
            
            catch (SocketException e)
            {
                //this.Close();
                //f1.Show();
            }
        }

        private void OpenChat_tunnel()
        {
            Action<string> OK = new Action<string>(Established);
            try
            {
                byte[] bytesReceived = new Byte[256];
                PUB.s_chat.Connect(CFG.Server_IP, CFG.Server_Port);
                PUB.s_chat.Send(Encoding.UTF8.GetBytes(CFG.UserID + @"_chat"));
                int tmp = PUB.s_chat.Receive(bytesReceived, bytesReceived.Length, 0);
                PUB.s_chat.Send(Encoding.UTF8.GetBytes(CFG.TargetID + @"_chat"));
                tmp = PUB.s_chat.Receive(bytesReceived, bytesReceived.Length, 0);

                while (true)
                {
                    tmp = PUB.s_chat.Receive(bytesReceived, bytesReceived.Length, 0);
                    if (Encoding.UTF8.GetString(bytesReceived, 0, tmp) == "In coming")
                    {
                        break;
                    }
                }
                tmp = PUB.s_chat.Receive(bytesReceived, bytesReceived.Length, 0);
                Invoke(OK, "s");
            }
            catch (SocketException err)
            {
                var result = MessageBox.Show("小鸡好像不见了！", "喵喵喵", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void OpenFile_tunnel()
        {
            Action<string> Show_f3 = new Action<string>(FLformOpen);
            try
            {
                byte[] bytesReceived = new Byte[256];
                PUB.s_file.Connect(CFG.Server_IP, CFG.Server_Port);
                PUB.s_file.Send(Encoding.UTF8.GetBytes(CFG.UserID + @"_file"));
                int tmp = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
                PUB.s_file.Send(Encoding.UTF8.GetBytes(CFG.TargetID + @"_file"));
                tmp = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
                while (true)
                {
                    tmp = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
                    if (Encoding.UTF8.GetString(bytesReceived, 0, tmp) == "In coming")
                    {
                        break;
                    }
                }
                tmp = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
                Invoke(Show_f3, "OKF3");
            }
            catch (SocketException err)
            {
                var result = MessageBox.Show("小鸡好像不见了！", "喵喵喵", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }


        private void Send_File_Click(object sender, EventArgs e)
        {
            PUB.ActiveC = true;
            PUB.s_ctrl.Send(Encoding.UTF8.GetBytes("File"));
        }

        private void Chat_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            PUB.s_chat.Close();
            PUB.s_ctrl.Close();
            f1.Show();
        }
    }
}
