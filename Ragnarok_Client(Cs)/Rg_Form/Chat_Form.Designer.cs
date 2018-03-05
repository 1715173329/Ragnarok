namespace Ragnarok
{
    partial class Chat_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat_Form));
            this.RecvBox = new System.Windows.Forms.RichTextBox();
            this.TransBox = new System.Windows.Forms.RichTextBox();
            this.SendMSG_Button = new System.Windows.Forms.Button();
            this.TargetID_Lable = new System.Windows.Forms.Label();
            this.Send_File = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RecvBox
            // 
            this.RecvBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RecvBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecvBox.Location = new System.Drawing.Point(47, 52);
            this.RecvBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RecvBox.Name = "RecvBox";
            this.RecvBox.ReadOnly = true;
            this.RecvBox.Size = new System.Drawing.Size(682, 363);
            this.RecvBox.TabIndex = 0;
            this.RecvBox.Text = "";
            this.RecvBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // TransBox
            // 
            this.TransBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransBox.Location = new System.Drawing.Point(47, 438);
            this.TransBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TransBox.Name = "TransBox";
            this.TransBox.Size = new System.Drawing.Size(584, 67);
            this.TransBox.TabIndex = 1;
            this.TransBox.Text = "";
            this.TransBox.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SendMSG_Button
            // 
            this.SendMSG_Button.Enabled = false;
            this.SendMSG_Button.Location = new System.Drawing.Point(638, 438);
            this.SendMSG_Button.Name = "SendMSG_Button";
            this.SendMSG_Button.Size = new System.Drawing.Size(91, 67);
            this.SendMSG_Button.TabIndex = 2;
            this.SendMSG_Button.Text = "发送";
            this.SendMSG_Button.UseVisualStyleBackColor = true;
            this.SendMSG_Button.Click += new System.EventHandler(this.SendMSG_Button_Click);
            // 
            // TargetID_Lable
            // 
            this.TargetID_Lable.AutoSize = true;
            this.TargetID_Lable.Location = new System.Drawing.Point(42, 20);
            this.TargetID_Lable.Name = "TargetID_Lable";
            this.TargetID_Lable.Size = new System.Drawing.Size(172, 27);
            this.TargetID_Lable.TabIndex = 3;
            this.TargetID_Lable.Text = "正在与。。。聊天";
            // 
            // Send_File
            // 
            this.Send_File.Location = new System.Drawing.Point(596, 9);
            this.Send_File.Name = "Send_File";
            this.Send_File.Size = new System.Drawing.Size(133, 35);
            this.Send_File.TabIndex = 4;
            this.Send_File.Text = "发福利";
            this.Send_File.UseVisualStyleBackColor = true;
            this.Send_File.Click += new System.EventHandler(this.Send_File_Click);
            // 
            // Chat_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 528);
            this.Controls.Add(this.Send_File);
            this.Controls.Add(this.TargetID_Lable);
            this.Controls.Add(this.SendMSG_Button);
            this.Controls.Add(this.TransBox);
            this.Controls.Add(this.RecvBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Chat_Form";
            this.Text = "Ragnarok C#";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chat_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RecvBox;
        private System.Windows.Forms.RichTextBox TransBox;
        private System.Windows.Forms.Button SendMSG_Button;
        private System.Windows.Forms.Label TargetID_Lable;
        private System.Windows.Forms.Button Send_File;
    }
}