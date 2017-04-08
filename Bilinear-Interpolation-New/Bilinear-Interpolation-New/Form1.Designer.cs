namespace Bilinear_Interpolation_New
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
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resizeBtn = new System.Windows.Forms.Button();
            this.resizeBox = new System.Windows.Forms.TextBox();
            this.imageBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // photoBox
            // 
            this.photoBox.Location = new System.Drawing.Point(12, 12);
            this.photoBox.Name = "photoBox";
            this.photoBox.Size = new System.Drawing.Size(804, 585);
            this.photoBox.TabIndex = 0;
            this.photoBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(822, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Масштаб в % :";
            // 
            // resizeBtn
            // 
            this.resizeBtn.Location = new System.Drawing.Point(825, 278);
            this.resizeBtn.Name = "resizeBtn";
            this.resizeBtn.Size = new System.Drawing.Size(149, 34);
            this.resizeBtn.TabIndex = 2;
            this.resizeBtn.Text = "Изменить размер";
            this.resizeBtn.UseVisualStyleBackColor = true;
            this.resizeBtn.Click += new System.EventHandler(this.resizeBtn_Click);
            // 
            // resizeBox
            // 
            this.resizeBox.Location = new System.Drawing.Point(825, 252);
            this.resizeBox.Name = "resizeBox";
            this.resizeBox.Size = new System.Drawing.Size(100, 20);
            this.resizeBox.TabIndex = 3;
            this.resizeBox.TextChanged += new System.EventHandler(this.resizeBox_TextChanged);
            this.resizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resizeBox_KeyPress);
            // 
            // imageBtn
            // 
            this.imageBtn.Location = new System.Drawing.Point(822, 37);
            this.imageBtn.Name = "imageBtn";
            this.imageBtn.Size = new System.Drawing.Size(149, 34);
            this.imageBtn.TabIndex = 2;
            this.imageBtn.Text = " Загрузить изображение";
            this.imageBtn.UseVisualStyleBackColor = true;
            this.imageBtn.Click += new System.EventHandler(this.imageBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(825, 535);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(149, 34);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Выйти";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(986, 609);
            this.Controls.Add(this.resizeBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.imageBtn);
            this.Controls.Add(this.resizeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.photoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilinear Interpolation Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox photoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resizeBtn;
        private System.Windows.Forms.TextBox resizeBox;
        private System.Windows.Forms.Button imageBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

