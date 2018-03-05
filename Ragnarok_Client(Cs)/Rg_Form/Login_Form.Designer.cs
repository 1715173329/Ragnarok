namespace Ragnarok
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.UserID_Lable = new System.Windows.Forms.Label();
            this.TargetID_Lable = new System.Windows.Forms.Label();
            this.ServerIP_Lable = new System.Windows.Forms.Label();
            this.ServerPort_Lable = new System.Windows.Forms.Label();
            this.UserID_Box = new System.Windows.Forms.TextBox();
            this.TargetID_Box = new System.Windows.Forms.TextBox();
            this.ServerIP_Box = new System.Windows.Forms.TextBox();
            this.ServerPort_Box = new System.Windows.Forms.TextBox();
            this.Conn_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Split_Lable = new System.Windows.Forms.Label();
            this.IDcard = new System.Windows.Forms.Label();
            this.IDcard_words = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.IDcard_name = new System.Windows.Forms.Label();
            this.IDcard_namebox = new System.Windows.Forms.TextBox();
            this.IDcard_gender = new System.Windows.Forms.Label();
            this.IDcard_gendercombo = new System.Windows.Forms.ComboBox();
            this.Save_botton = new System.Windows.Forms.Button();
            this.Conn_lable = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserID_Lable
            // 
            this.UserID_Lable.AutoSize = true;
            this.UserID_Lable.Location = new System.Drawing.Point(61, 40);
            this.UserID_Lable.Name = "UserID_Lable";
            this.UserID_Lable.Size = new System.Drawing.Size(87, 27);
            this.UserID_Lable.TabIndex = 0;
            this.UserID_Lable.Text = "User ID:";
            this.UserID_Lable.Click += new System.EventHandler(this.label1_Click);
            // 
            // TargetID_Lable
            // 
            this.TargetID_Lable.AutoSize = true;
            this.TargetID_Lable.Location = new System.Drawing.Point(43, 80);
            this.TargetID_Lable.Name = "TargetID_Lable";
            this.TargetID_Lable.Size = new System.Drawing.Size(105, 27);
            this.TargetID_Lable.TabIndex = 1;
            this.TargetID_Lable.Text = "Target ID:";
            this.TargetID_Lable.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ServerIP_Lable
            // 
            this.ServerIP_Lable.AutoSize = true;
            this.ServerIP_Lable.Location = new System.Drawing.Point(46, 120);
            this.ServerIP_Lable.Name = "ServerIP_Lable";
            this.ServerIP_Lable.Size = new System.Drawing.Size(102, 27);
            this.ServerIP_Lable.TabIndex = 4;
            this.ServerIP_Lable.Text = "Server IP:";
            // 
            // ServerPort_Lable
            // 
            this.ServerPort_Lable.AutoSize = true;
            this.ServerPort_Lable.Location = new System.Drawing.Point(24, 158);
            this.ServerPort_Lable.Name = "ServerPort_Lable";
            this.ServerPort_Lable.Size = new System.Drawing.Size(124, 27);
            this.ServerPort_Lable.TabIndex = 5;
            this.ServerPort_Lable.Text = "Server Port:";
            // 
            // UserID_Box
            // 
            this.UserID_Box.Location = new System.Drawing.Point(154, 34);
            this.UserID_Box.Name = "UserID_Box";
            this.UserID_Box.Size = new System.Drawing.Size(205, 33);
            this.UserID_Box.TabIndex = 6;
            // 
            // TargetID_Box
            // 
            this.TargetID_Box.Location = new System.Drawing.Point(154, 74);
            this.TargetID_Box.Name = "TargetID_Box";
            this.TargetID_Box.Size = new System.Drawing.Size(205, 33);
            this.TargetID_Box.TabIndex = 7;
            // 
            // ServerIP_Box
            // 
            this.ServerIP_Box.Location = new System.Drawing.Point(154, 113);
            this.ServerIP_Box.Name = "ServerIP_Box";
            this.ServerIP_Box.Size = new System.Drawing.Size(205, 33);
            this.ServerIP_Box.TabIndex = 10;
            // 
            // ServerPort_Box
            // 
            this.ServerPort_Box.Location = new System.Drawing.Point(154, 152);
            this.ServerPort_Box.Name = "ServerPort_Box";
            this.ServerPort_Box.Size = new System.Drawing.Size(205, 33);
            this.ServerPort_Box.TabIndex = 11;
            // 
            // Conn_Button
            // 
            this.Conn_Button.Enabled = false;
            this.Conn_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Conn_Button.Location = new System.Drawing.Point(154, 237);
            this.Conn_Button.Name = "Conn_Button";
            this.Conn_Button.Size = new System.Drawing.Size(205, 40);
            this.Conn_Button.TabIndex = 12;
            this.Conn_Button.Text = "连接服务器";
            this.Conn_Button.UseVisualStyleBackColor = true;
            this.Conn_Button.Click += new System.EventHandler(this.Conn_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ragnarok.Properties.Resources.GGphoto;
            this.pictureBox1.Location = new System.Drawing.Point(406, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Split_Lable
            // 
            this.Split_Lable.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Split_Lable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Split_Lable.Location = new System.Drawing.Point(379, 34);
            this.Split_Lable.Name = "Split_Lable";
            this.Split_Lable.Size = new System.Drawing.Size(3, 350);
            this.Split_Lable.TabIndex = 14;
            // 
            // IDcard
            // 
            this.IDcard.AutoSize = true;
            this.IDcard.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDcard.Location = new System.Drawing.Point(502, 31);
            this.IDcard.Name = "IDcard";
            this.IDcard.Size = new System.Drawing.Size(110, 31);
            this.IDcard.TabIndex = 15;
            this.IDcard.Text = "个人资料";
            // 
            // IDcard_words
            // 
            this.IDcard_words.AutoSize = true;
            this.IDcard_words.Location = new System.Drawing.Point(401, 225);
            this.IDcard_words.Name = "IDcard_words";
            this.IDcard_words.Size = new System.Drawing.Size(92, 27);
            this.IDcard_words.TabIndex = 17;
            this.IDcard_words.Text = "个性签名";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(406, 262);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(299, 123);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "网络一线牵，相聚在空间，\n真情四海连，珍惜这段缘。";
            // 
            // IDcard_name
            // 
            this.IDcard_name.AutoSize = true;
            this.IDcard_name.Location = new System.Drawing.Point(560, 74);
            this.IDcard_name.Name = "IDcard_name";
            this.IDcard_name.Size = new System.Drawing.Size(52, 27);
            this.IDcard_name.TabIndex = 19;
            this.IDcard_name.Text = "昵称";
            // 
            // IDcard_namebox
            // 
            this.IDcard_namebox.Location = new System.Drawing.Point(565, 104);
            this.IDcard_namebox.Name = "IDcard_namebox";
            this.IDcard_namebox.Size = new System.Drawing.Size(128, 33);
            this.IDcard_namebox.TabIndex = 20;
            this.IDcard_namebox.Text = "﹌★`浩滒╳灬";
            // 
            // IDcard_gender
            // 
            this.IDcard_gender.AutoSize = true;
            this.IDcard_gender.Location = new System.Drawing.Point(560, 140);
            this.IDcard_gender.Name = "IDcard_gender";
            this.IDcard_gender.Size = new System.Drawing.Size(52, 27);
            this.IDcard_gender.TabIndex = 21;
            this.IDcard_gender.Text = "性别";
            // 
            // IDcard_gendercombo
            // 
            this.IDcard_gendercombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDcard_gendercombo.FormattingEnabled = true;
            this.IDcard_gendercombo.Items.AddRange(new object[] {
            "GG",
            "MM",
            "保密"});
            this.IDcard_gendercombo.Location = new System.Drawing.Point(565, 167);
            this.IDcard_gendercombo.Name = "IDcard_gendercombo";
            this.IDcard_gendercombo.Size = new System.Drawing.Size(128, 35);
            this.IDcard_gendercombo.TabIndex = 22;
            this.IDcard_gendercombo.SelectedIndexChanged += new System.EventHandler(this.IDcard_gendercombo_SelectedIndexChanged);
            // 
            // Save_botton
            // 
            this.Save_botton.Location = new System.Drawing.Point(154, 191);
            this.Save_botton.Name = "Save_botton";
            this.Save_botton.Size = new System.Drawing.Size(205, 40);
            this.Save_botton.TabIndex = 23;
            this.Save_botton.Text = "保存";
            this.Save_botton.UseVisualStyleBackColor = true;
            this.Save_botton.Click += new System.EventHandler(this.Save_botton_Click);
            // 
            // Conn_lable
            // 
            this.Conn_lable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Conn_lable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Conn_lable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Conn_lable.Location = new System.Drawing.Point(29, 290);
            this.Conn_lable.Name = "Conn_lable";
            this.Conn_lable.Size = new System.Drawing.Size(330, 35);
            this.Conn_lable.TabIndex = 24;
            this.Conn_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_button
            // 
            this.start_button.Enabled = false;
            this.start_button.ForeColor = System.Drawing.Color.Green;
            this.start_button.Location = new System.Drawing.Point(29, 345);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(330, 40);
            this.start_button.TabIndex = 25;
            this.start_button.Text = "未连接服务器";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 411);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.Conn_lable);
            this.Controls.Add(this.Save_botton);
            this.Controls.Add(this.IDcard_gendercombo);
            this.Controls.Add(this.IDcard_gender);
            this.Controls.Add(this.IDcard_namebox);
            this.Controls.Add(this.IDcard_name);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.IDcard_words);
            this.Controls.Add(this.IDcard);
            this.Controls.Add(this.Split_Lable);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Conn_Button);
            this.Controls.Add(this.ServerPort_Box);
            this.Controls.Add(this.ServerIP_Box);
            this.Controls.Add(this.TargetID_Box);
            this.Controls.Add(this.UserID_Box);
            this.Controls.Add(this.ServerPort_Lable);
            this.Controls.Add(this.ServerIP_Lable);
            this.Controls.Add(this.TargetID_Lable);
            this.Controls.Add(this.UserID_Lable);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login_Form";
            this.Text = "Ragnarok C#";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_Form_FormClosed);
            this.Load += new System.EventHandler(this.Login_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserID_Lable;
        private System.Windows.Forms.Label TargetID_Lable;
        private System.Windows.Forms.Label ServerIP_Lable;
        private System.Windows.Forms.Label ServerPort_Lable;
        private System.Windows.Forms.TextBox UserID_Box;
        private System.Windows.Forms.TextBox TargetID_Box;
        private System.Windows.Forms.TextBox ServerIP_Box;
        private System.Windows.Forms.TextBox ServerPort_Box;
        private System.Windows.Forms.Button Conn_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Split_Lable;
        private System.Windows.Forms.Label IDcard;
        private System.Windows.Forms.Label IDcard_words;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label IDcard_name;
        private System.Windows.Forms.TextBox IDcard_namebox;
        private System.Windows.Forms.Label IDcard_gender;
        private System.Windows.Forms.ComboBox IDcard_gendercombo;
        private System.Windows.Forms.Button Save_botton;
        private System.Windows.Forms.Label Conn_lable;
        private System.Windows.Forms.Button start_button;
    }
}