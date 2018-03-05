using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Ragnarok
{
    
    public partial class Login_Form : Form
    {
        
        static bool Connected = false;
        Ragnarok.Properties.Settings CFG = new Ragnarok.Properties.Settings();
        public Login_Form()
        {
            InitializeComponent();
            Conn_Button.Enabled = false;
            start_button.Enabled = false;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            UserID_Box.Text = CFG.UserID;
            TargetID_Box.Text= CFG.TargetID;
            ServerIP_Box.Text = CFG.Server_IP;
            ServerPort_Box.Text = CFG.Server_Port.ToString();
            IDcard_gendercombo.Text = "GG";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void IDcard_gendercombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDcard_gendercombo.Text=="MM")
            {
                pictureBox1.Image = Properties.Resources.MMphoto;
            }
            if (IDcard_gendercombo.Text == "GG")
            {
                pictureBox1.Image = Properties.Resources.GGphoto;
            }
            if (IDcard_gendercombo.Text == "保密")
            {
                pictureBox1.Image = Properties.Resources.Brother_Chun;
            }
        }

        private void Save_botton_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(UserID_Box.Text, "^[0-9a-zA-Z]+$"))
                {
                    CFG.UserID = UserID_Box.Text;
                }
                else throw new FormatException();

                if (System.Text.RegularExpressions.Regex.IsMatch(TargetID_Box.Text, "^[0-9a-zA-Z]+$"))
                {
                    CFG.TargetID = TargetID_Box.Text;
                }
                else throw new FormatException();



                var ipcheck = ServerIP_Box.Text.Split('.');
                foreach (var i in ipcheck)
                {
                    if (Convert.ToInt32(i) >= 0 && Convert.ToInt32(i) <= 255);
                    else throw new FormatException();
                }
                CFG.Server_IP = ServerIP_Box.Text;

                int portcheck = Convert.ToInt32(ServerPort_Box.Text);
                if (portcheck >= 0 && portcheck <= 65535)
                {
                    CFG.Server_Port = portcheck;
                }
                CFG.Server_Port = Convert.ToInt32(ServerPort_Box.Text);

                CFG.Save();
                Conn_Button.Enabled = true;
                
            }
            catch (FormatException err)
            {
                var result = MessageBox.Show("要不要教教你怎么输入？", "喵喵喵",MessageBoxButtons.OK,MessageBoxIcon.Question);
            } 
            
            
        }

        private void Conn_Button_Click(object sender, EventArgs e)
        {
            Thread ConnectThread = new Thread(new ThreadStart(ConnectToServer));
            ConnectThread.Start();
        }

        public void ConnectToServer()
        {
            Action<string> chlable = new Action<string>(chLable_Conn);
            Action<string> chbutton = new Action<string>(StartButtonTextChange);
            Action<string> CloseButton = new Action<string>(CloseConnButton);
            try
            {
                byte[] bytesReceived = new Byte[256];
                PUB.s_ctrl.Connect(CFG.Server_IP, CFG.Server_Port);
                PUB.s_ctrl.Send(Encoding.UTF8.GetBytes(CFG.UserID));
                int tmp = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                Invoke(chlable, Encoding.UTF8.GetString(bytesReceived, 0, tmp));

                PUB.s_ctrl.Send(Encoding.UTF8.GetBytes(CFG.TargetID));
                tmp = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                Invoke(chlable, Encoding.UTF8.GetString(bytesReceived, 0, tmp));

                while (true)
                {
                    tmp = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                    Invoke(chlable, Encoding.UTF8.GetString(bytesReceived, 0, tmp));
                    if (Encoding.UTF8.GetString(bytesReceived, 0, tmp) == "In coming")
                    {
                        Connected = true;
                        Invoke(chbutton,"s");
                        break;
                    }
                    else
                    {
                        PUB.ActiveC = true;
                    }
                }
                tmp = PUB.s_ctrl.Receive(bytesReceived, bytesReceived.Length, 0);
                Invoke(chlable, Encoding.UTF8.GetString(bytesReceived, 0, tmp));

            }
            catch (SocketException err)
            {
                Invoke(CloseButton, "1");
                var result = MessageBox.Show("小鸡好像不见了！", "喵喵喵", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
                
        }

        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        public void CloseConnButton(string t)
        {
            Conn_Button.Enabled=false;
        }
        
        public void chLable_Conn(string t)
         {
            Conn_lable.Text = t;
         }

        public void StartButtonTextChange(string t)
        {
            start_button.Enabled = true;
            start_button.Text = "开始网上冲浪";
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                Chat_Form f2 = new Chat_Form(this);
                f2.Show();
                this.Hide();
            }

        }

    }

}
