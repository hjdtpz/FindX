namespace FindX
{
    partial class pickColor2Button
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChoseImgButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.originImagePic = new System.Windows.Forms.PictureBox();
            this.ResultPic = new System.Windows.Forms.PictureBox();
            this.FindXPic = new System.Windows.Forms.PictureBox();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.Color1Button = new System.Windows.Forms.Button();
            this.Color2Button = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ClearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originImagePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindXPic)).BeginInit();
            this.SuspendLayout();
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Filter = "图片|*.jpg;*.png;*.gif”";
            // 
            // ChoseImgButton
            // 
            this.ChoseImgButton.Location = new System.Drawing.Point(6, 6);
            this.ChoseImgButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChoseImgButton.Name = "ChoseImgButton";
            this.ChoseImgButton.Size = new System.Drawing.Size(64, 38);
            this.ChoseImgButton.TabIndex = 0;
            this.ChoseImgButton.Text = "选择图片";
            this.ChoseImgButton.UseVisualStyleBackColor = true;
            this.ChoseImgButton.Click += new System.EventHandler(this.ChoseImgButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(453, 6);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(467, 775);
            this.logTextBox.TabIndex = 1;
            this.logTextBox.Text = "\r\n";
            // 
            // originImagePic
            // 
            this.originImagePic.Location = new System.Drawing.Point(6, 48);
            this.originImagePic.Margin = new System.Windows.Forms.Padding(2);
            this.originImagePic.Name = "originImagePic";
            this.originImagePic.Size = new System.Drawing.Size(188, 178);
            this.originImagePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originImagePic.TabIndex = 2;
            this.originImagePic.TabStop = false;
            // 
            // ResultPic
            // 
            this.ResultPic.Location = new System.Drawing.Point(6, 230);
            this.ResultPic.Margin = new System.Windows.Forms.Padding(2);
            this.ResultPic.Name = "ResultPic";
            this.ResultPic.Size = new System.Drawing.Size(443, 587);
            this.ResultPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResultPic.TabIndex = 3;
            this.ResultPic.TabStop = false;
            // 
            // FindXPic
            // 
            this.FindXPic.Location = new System.Drawing.Point(199, 48);
            this.FindXPic.Name = "FindXPic";
            this.FindXPic.Size = new System.Drawing.Size(226, 178);
            this.FindXPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FindXPic.TabIndex = 4;
            this.FindXPic.TabStop = false;
            // 
            // Color1Button
            // 
            this.Color1Button.Location = new System.Drawing.Point(970, 21);
            this.Color1Button.Name = "Color1Button";
            this.Color1Button.Size = new System.Drawing.Size(79, 64);
            this.Color1Button.TabIndex = 5;
            this.Color1Button.Text = "Color1";
            this.Color1Button.UseVisualStyleBackColor = true;
            this.Color1Button.Click += new System.EventHandler(this.Color1Button_Click);
            // 
            // Color2Button
            // 
            this.Color2Button.Location = new System.Drawing.Point(1099, 21);
            this.Color2Button.Name = "Color2Button";
            this.Color2Button.Size = new System.Drawing.Size(79, 64);
            this.Color2Button.TabIndex = 6;
            this.Color2Button.Text = "Color2";
            this.Color2Button.UseVisualStyleBackColor = true;
            this.Color2Button.Click += new System.EventHandler(this.Color2Button_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(1037, 116);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 60);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "计算";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ClearLog
            // 
            this.ClearLog.Location = new System.Drawing.Point(318, 6);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(75, 38);
            this.ClearLog.TabIndex = 8;
            this.ClearLog.Text = "清空显示";
            this.ClearLog.UseVisualStyleBackColor = true;
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // pickColor2Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 843);
            this.Controls.Add(this.ClearLog);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.Color2Button);
            this.Controls.Add(this.Color1Button);
            this.Controls.Add(this.FindXPic);
            this.Controls.Add(this.ResultPic);
            this.Controls.Add(this.originImagePic);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.ChoseImgButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pickColor2Button";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originImagePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindXPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog imageFileDialog;
        private System.Windows.Forms.Button ChoseImgButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.PictureBox originImagePic;
        private System.Windows.Forms.PictureBox ResultPic;
        private System.Windows.Forms.PictureBox FindXPic;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button Color1Button;
        private System.Windows.Forms.Button Color2Button;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button ClearLog;
    }
}

