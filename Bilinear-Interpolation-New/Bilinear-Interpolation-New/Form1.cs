using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilinear_Interpolation_New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            resizeBox.KeyPress += new KeyPressEventHandler(resizeBox_KeyPress);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void imageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog();
            imageDialog.Title = "Choose pictures!";
            imageDialog.Filter = "Image files (*.bmp, *.jpeg, *.jpg, *.png)| *.bmp; *.jpeg; *.jpg; *.png |All Files| *.*";
            imageDialog.FilterIndex = 1;
            
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                photoBox.ImageLocation = imageDialog.FileName;
                photoBox.Load();
                if(resizeBox.Enabled==false)
                { resizeBox.Enabled = true; }
            }
        }

        private void resizeBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(resizeBox.Text))
            {
                resizeBox.Enabled = true;
            }
            else
            {
                resizeBox.Enabled = false;
            }
        }

        private void resizeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar==(char)8)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resizeBox.Enabled = false;
            resizeBtn.Enabled = false;
        }

        private void resizeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
