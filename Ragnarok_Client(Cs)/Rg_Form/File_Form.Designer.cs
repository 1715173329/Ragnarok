namespace Ragnarok
{
    partial class File_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File_Form));
            this.Pgs1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.Pgs2 = new System.Windows.Forms.ProgressBar();
            this.Sendfile_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speed1 = new System.Windows.Forms.Label();
            this.speed2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Pgs1
            // 
            this.Pgs1.Location = new System.Drawing.Point(153, 139);
            this.Pgs1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pgs1.Name = "Pgs1";
            this.Pgs1.Size = new System.Drawing.Size(511, 30);
            this.Pgs1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Enabled = false;
            this.ChooseFile.Location = new System.Drawing.Point(560, 40);
            this.ChooseFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(104, 33);
            this.ChooseFile.TabIndex = 1;
            this.ChooseFile.Text = "选择文件";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(39, 40);
            this.PathBox.Name = "PathBox";
            this.PathBox.ReadOnly = true;
            this.PathBox.Size = new System.Drawing.Size(514, 33);
            this.PathBox.TabIndex = 2;
            this.PathBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // Pgs2
            // 
            this.Pgs2.Location = new System.Drawing.Point(153, 220);
            this.Pgs2.Name = "Pgs2";
            this.Pgs2.Size = new System.Drawing.Size(511, 30);
            this.Pgs2.TabIndex = 3;
            // 
            // Sendfile_button
            // 
            this.Sendfile_button.Enabled = false;
            this.Sendfile_button.Location = new System.Drawing.Point(560, 294);
            this.Sendfile_button.Name = "Sendfile_button";
            this.Sendfile_button.Size = new System.Drawing.Size(104, 34);
            this.Sendfile_button.TabIndex = 4;
            this.Sendfile_button.Text = "发送";
            this.Sendfile_button.UseVisualStyleBackColor = true;
            this.Sendfile_button.Click += new System.EventHandler(this.Sendfile_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "接收进度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "解密进度：";
            // 
            // speed1
            // 
            this.speed1.AutoSize = true;
            this.speed1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.speed1.Location = new System.Drawing.Point(595, 174);
            this.speed1.Name = "speed1";
            this.speed1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.speed1.Size = new System.Drawing.Size(24, 27);
            this.speed1.TabIndex = 7;
            this.speed1.Text = "0";
            // 
            // speed2
            // 
            this.speed2.AutoSize = true;
            this.speed2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.speed2.Location = new System.Drawing.Point(595, 253);
            this.speed2.Name = "speed2";
            this.speed2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.speed2.Size = new System.Drawing.Size(24, 27);
            this.speed2.TabIndex = 8;
            this.speed2.Text = "0";
            // 
            // File_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 340);
            this.Controls.Add(this.speed2);
            this.Controls.Add(this.speed1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sendfile_button);
            this.Controls.Add(this.Pgs2);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.Pgs1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "File_Form";
            this.Text = "干嘛，想当车手？";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.File_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Pgs1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.ProgressBar Pgs2;
        private System.Windows.Forms.Button Sendfile_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label speed1;
        private System.Windows.Forms.Label speed2;
    }
}