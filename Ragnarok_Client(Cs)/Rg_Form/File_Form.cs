using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Ragnarok
{
    public partial class File_Form : Form
    {
        public static bool closelock = false;
        public byte[] bytesReceived = new byte[1024];
        public static int counter;
        public static string filename;
        public File_Form()
        {
            InitializeComponent();

            if (PUB.ActiveC)
            {
                ChooseFile.Enabled = true;
                label1.Text = "加密进度：";
                label2.Text = "发送进度：";
            }
            else
            {
                Sendfile_button.Text = "别慌";
                Thread FR = new Thread(new ThreadStart(File_recv));
                FR.Start();
                closelock = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                PathBox.Text = fName;
            }
        }

        

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            Sendfile_button.Enabled = true;
        }

        private void File_recv()
        {
            Action<int> setpgs1 = new Action<int>(Pgs1_set);
            int sum = 0;
            float pgs;
            counter = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
            byte[] filename_byte = new byte[counter];
            Array.Copy(bytesReceived, 0, filename_byte, 0, counter);
            filename = Encoding.UTF8.GetString(filename_byte);
            PUB.s_file.Send(filename_byte);
            
            counter = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
            byte[] filesize_byte = new byte[counter];
            Array.Copy(bytesReceived, 0, filesize_byte, 0, counter);
            string filesize_string= Encoding.UTF8.GetString(filesize_byte);
            int filesize = Convert.ToInt32(filesize_string);
            PUB.s_file.Send(filename_byte);

            using (FileStream fsw = File.Create(Directory.GetCurrentDirectory() + @"\tmp.bin"))
            {
                while (true)
                {
                    counter = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
                    fsw.Write(bytesReceived, 0, counter);
                    sum += counter;
                    pgs = Convert.ToSingle(sum) / Convert.ToSingle(filesize) * 100;
                    Invoke(setpgs1, Convert.ToInt32(pgs));
                    if (sum==filesize)
                    {
                        break;
                    }
                    
                }
                
            }
            Thread FD = new Thread(new ThreadStart(File_dcpt));
            FD.Start();
        }

        private void File_dcpt()
        {
            byte[] b = new byte[4096];
            int readlenth;
            int sum = 0;
            float pgs;
            FileInfo FI = new FileInfo(Directory.GetCurrentDirectory() + @"\tmp.bin");
            Action<int> setpgs2 = new Action<int>(Pgs2_set);
            using (FileStream fsw = File.Create(Directory.GetCurrentDirectory()+@"\"+filename))
            {
                using (FileStream fsr = File.Open((Directory.GetCurrentDirectory() + @"\tmp.bin"), FileMode.Open))
                {
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = PUB.AES_Key;
                        aesAlg.IV = PUB.AES_IV;
                        aesAlg.Mode = CipherMode.CFB;
                        Array.Clear(b, 0, b.Length);
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        using (CryptoStream cs = new CryptoStream(fsw, decryptor, CryptoStreamMode.Write))
                        {
                            while (true)
                            {
                                if ((readlenth = fsr.Read(b, 0, b.Length)) > 0)
                                {
                                    byte[] tmp = new byte[readlenth];
                                    Array.Copy(b, tmp, readlenth);
                                    cs.Write(tmp, 0, tmp.Length);
                                    sum += readlenth;
                                    pgs = Convert.ToSingle(sum) / Convert.ToSingle(FI.Length) * 100;
                                    Invoke(setpgs2, Convert.ToInt32(pgs));
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            var dr = MessageBox.Show("好人一生平安", "上车", MessageBoxButtons.OK, MessageBoxIcon.Question);
            PUB.s_file.Close();
            closelock = false;
        }

        private void File_ecpt()
        {
            int sum = 0;
            float pgs;
            byte[] b = new byte[4096];
            int readlenth;
            FileInfo FI = new FileInfo(PathBox.Text);
            Action<int> setpgs1 = new Action<int>(Pgs1_set);
            string tmpPath = (Directory.GetCurrentDirectory() + @"\tmp.bin");
            
            using (FileStream fsw = File.Create(tmpPath))
            {
                using (FileStream fsr = File.Open(PathBox.Text, FileMode.Open))
                {
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = PUB.AES_Key;
                        aesAlg.IV = PUB.AES_IV;
                        aesAlg.Mode = CipherMode.CFB;
                        Array.Clear(b, 0, b.Length);
                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                        using (CryptoStream cs = new CryptoStream(fsw, encryptor, CryptoStreamMode.Write))
                        {
                            while (true)
                            {
                                if ((readlenth = fsr.Read(b, 0, b.Length)) > 0)
                                {
                                    byte[] tmp = new byte[readlenth];
                                    Array.Copy(b, tmp, readlenth);
                                    cs.Write(tmp, 0, tmp.Length);
                                    sum += readlenth;
                                    pgs = Convert.ToSingle(sum) / Convert.ToSingle(FI.Length) * 100;
                                    Invoke(setpgs1, Convert.ToInt32(pgs));
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Thread FS = new Thread(new ThreadStart(File_send));
            FS.Start();
        }

        private void File_send()
        {
            Action<int> setpgs2 = new Action<int>(Pgs2_set);
            byte[] b = new byte[4096];
            int sum = 0;
            float pgs;
            FileInfo FI = new FileInfo(PathBox.Text);
            PUB.s_file.Send(Encoding.UTF8.GetBytes(FI.Name));
            counter = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
            FileInfo FItmp = new FileInfo(Directory.GetCurrentDirectory() + @"\tmp.bin");
            PUB.s_file.Send(Encoding.UTF8.GetBytes(Convert.ToString(FItmp.Length)));
            counter = PUB.s_file.Receive(bytesReceived, bytesReceived.Length, 0);
            using (FileStream fsr = File.Open(Directory.GetCurrentDirectory() + @"\tmp.bin", FileMode.Open))
            {
                while (true)
                {
                    counter = fsr.Read(b, 0, b.Length);
                    if (counter > 0)
                    {
                        byte[] tmp = new byte[counter];
                        Array.Copy(b, tmp, counter);
                        PUB.s_file.Send(tmp);
                        sum += counter;
                        pgs = Convert.ToSingle(sum) / Convert.ToSingle(FI.Length) * 100;
                        Invoke(setpgs2, Convert.ToInt32(pgs));
                    }
                    else break;
                }
                
            }
            var dr = MessageBox.Show("强撸灰飞烟灭", "上车", MessageBoxButtons.OK, MessageBoxIcon.Question);
            PUB.s_file.Close();
            closelock = false;
        }

        private void Pgs1_set(int set)
        {
            speed1.Text = Convert.ToString(set) + @"%";
            Pgs1.Value = set;
        }
        private void Pgs2_set(int set)
        {
            speed2.Text = Convert.ToString(set)+@"%";
            Pgs2.Value = set;
        }

        private void Sendfile_button_Click(object sender, EventArgs e)
        {
            Thread FE = new Thread(new ThreadStart(File_ecpt));
            FE.Start();
            closelock = true;
            Sendfile_button.Enabled = false;
            
        }

        private void File_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closelock)
            {
                var result = MessageBox.Show("别闹", "喵喵喵", MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }
    }
}
