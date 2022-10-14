namespace GPL
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Btn_Run = new MetroFramework.Controls.MetroButton();
            this.btn_Del = new MetroFramework.Controls.MetroButton();
            this.txt_cmdbx = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(400, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 529);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(389, 371);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Btn_Run
            // 
            this.Btn_Run.Location = new System.Drawing.Point(40, 503);
            this.Btn_Run.Name = "Btn_Run";
            this.Btn_Run.Size = new System.Drawing.Size(105, 45);
            this.Btn_Run.TabIndex = 3;
            this.Btn_Run.Text = "RUN";
            this.Btn_Run.UseSelectable = true;
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(211, 503);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(105, 45);
            this.btn_Del.TabIndex = 4;
            this.btn_Del.Text = "Clear";
            this.btn_Del.UseSelectable = true;
            // 
            // txt_cmdbx
            // 
            // 
            // 
            // 
            this.txt_cmdbx.CustomButton.Image = null;
            this.txt_cmdbx.CustomButton.Location = new System.Drawing.Point(367, 1);
            this.txt_cmdbx.CustomButton.Name = "";
            this.txt_cmdbx.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_cmdbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_cmdbx.CustomButton.TabIndex = 1;
            this.txt_cmdbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_cmdbx.CustomButton.UseSelectable = true;
            this.txt_cmdbx.CustomButton.Visible = false;
            this.txt_cmdbx.Lines = new string[0];
            this.txt_cmdbx.Location = new System.Drawing.Point(5, 465);
            this.txt_cmdbx.MaxLength = 32767;
            this.txt_cmdbx.Name = "txt_cmdbx";
            this.txt_cmdbx.PasswordChar = '\0';
            this.txt_cmdbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_cmdbx.SelectedText = "";
            this.txt_cmdbx.SelectionLength = 0;
            this.txt_cmdbx.SelectionStart = 0;
            this.txt_cmdbx.ShortcutsEnabled = true;
            this.txt_cmdbx.Size = new System.Drawing.Size(389, 23);
            this.txt_cmdbx.TabIndex = 5;
            this.txt_cmdbx.UseSelectable = true;
            this.txt_cmdbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_cmdbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 630);
            this.Controls.Add(this.txt_cmdbx);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.Btn_Run);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Graphic Programing Language";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MetroFramework.Controls.MetroButton Btn_Run;
        private MetroFramework.Controls.MetroButton btn_Del;
        private MetroFramework.Controls.MetroTextBox txt_cmdbx;
    }
}

