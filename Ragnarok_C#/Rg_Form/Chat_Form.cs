using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public int tmp;
        public byte[] bytesReceived = new byte[1024];
        public byte[] AES_Key = new byte[32];
        public byte[] AES_IV = new byte[16];
        

        public Chat_Form()
        {
            InitializeComponent();
            TargetID_Lable.Text = "正在与 " + CFG.TargetID + " 聊天：";
            RSA_module.RSA_pair(out pubkey, out privkey);
            if (PUB.ActiveC)
            {

                PUB.s.Send(Encoding.UTF8.GetBytes(pubkey));

                tmp = PUB.s.Receive(bytesReceived, bytesReceived.Length, 0);
                pubkey4send = Encoding.UTF8.GetString(bytesReceived, 0, tmp);

                AES_module.AES_Initialize(out AES_Key, out AES_IV);
                byte[] AES_Complex = AES_join(AES_Key, AES_IV);
                byte[] cipherkey = RSA_module.RSAEncrypt(AES_Complex, pubkey4send);
                PUB.s.Send(cipherkey);

            }
            else
            {
                tmp = PUB.s.Receive(bytesReceived, bytesReceived.Length, 0);
                pubkey4send = Encoding.UTF8.GetString(bytesReceived, 0, tmp);

                PUB.s.Send(Encoding.UTF8.GetBytes(pubkey));

                tmp = PUB.s.Receive(bytesReceived, bytesReceived.Length, 0);
                byte[] cipherkey = new byte[tmp];
                Array.Copy(bytesReceived, 0, cipherkey, 0, tmp);

                byte[] AES_Complex = RSA_module.RSADecrypt(cipherkey, privkey);
                Buffer.BlockCopy(AES_Complex, 0, AES_Key, 0, 32);
                Buffer.BlockCopy(AES_Complex, 32, AES_IV, 0, 16);
            }
            
            Thread Rx = new Thread(new ThreadStart(Recv));
            Rx.Start();
            SendMSG_Button.Enabled = true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Recv()
        {
            Action<string> Show_Recv = new Action<string>(RecvboxFresh);
            
            while (true)
            {
                tmp = PUB.s.Receive(bytesReceived, bytesReceived.Length, 0);
                byte[] cipherbyte = new byte[tmp];
                Array.Copy(bytesReceived, 0, cipherbyte, 0, tmp);
                byte[] plainbytes = AES_module.AES_Decrypt(cipherbyte, AES_Key, AES_IV);
                string plaintext = Encoding.UTF8.GetString(plainbytes);
                Invoke(Show_Recv,plaintext);
            }
            
        }

        public void RecvboxFresh(string text)
        {
            DateTime dt = DateTime.Now;
            RecvBox.AppendText(dt.ToString() + "   " + CFG.TargetID + ":" + Environment.NewLine);
            RecvBox.AppendText(text + Environment.NewLine);
        }

        private void SendMSG_Button_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            RecvBox.AppendText(dt.ToString() + "   " + CFG.UserID + ":" + Environment.NewLine);
            RecvBox.AppendText(TransBox.Text + Environment.NewLine);
            byte[] sendcache = AES_module.AES_Encrypt(Encoding.UTF8.GetBytes(TransBox.Text), AES_Key, AES_IV); 
            PUB.s.Send(sendcache);
            TransBox.Clear();
        }

        //private void textbox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == (Keys.Control | Keys.Enter))
        //    {
        //        RecvBox.AppendText(dt.ToString() + "   " + CFG.UserID + ":" + Environment.NewLine);
        //        RecvBox.AppendText(TransBox.Text + Environment.NewLine);
        //        PUB.s.Send(Encoding.UTF8.GetBytes(TransBox.Text));
        //        TransBox.Clear();
        //     }
        // }

        private void Chat_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private byte[] AES_join(byte[] Key,byte[] IV)
        {
            byte[] AES_Complex = new byte[Key.Length + IV.Length];
            Buffer.BlockCopy(Key, 0, AES_Complex, 0, Key.Length);
            Buffer.BlockCopy(IV, 0, AES_Complex, Key.Length, IV.Length);
            Console.WriteLine(AES_Complex.Length.ToString());
            return AES_Complex;
        }

        private void Chat_Form_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
