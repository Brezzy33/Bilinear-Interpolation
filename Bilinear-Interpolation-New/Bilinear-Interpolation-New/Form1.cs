using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                resizeBtn.Enabled = true;
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
            //Создаем битмап и переменные для информации о битах (РГБ) и ширину с высотой
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Bitmap picture = (Bitmap)photoBox.Image;
            double resize = Convert.ToDouble(resizeBox.Text) / 100;
            int xMax = picture.Width;
            int yMax = picture.Height;

            int[,] Rm = new int[xMax, yMax];
            int[,] Gm = new int[xMax, yMax];
            int[,] Bm = new int[xMax, yMax];

            //Циклы для заполнения массивов информацией о битах
            for (int yCur =0; yCur < yMax; yCur++)
            {
                for (int xCur=0; xCur < xMax; xCur++)
                {
                    Color color = picture.GetPixel(xCur, yCur);
                    Rm[xCur, yCur] = color.R;
                    Gm[xCur, yCur] = color.G;
                    Bm[xCur, yCur] = color.B;
                }
            }

            //Перезадаем значения с учетом ресайза
            int resizeXmax = Convert.ToInt32(Math.Floor(picture.Width * resize));
            int resizeYmax = Convert.ToInt32(Math.Floor(picture.Height * resize));

            if (resizeXmax <1)
            {
                resizeXmax = 1;
            }
            if (resizeYmax <1)
            {
                resizeYmax = 1;
            }
            //Новые массивы с измененными данными
            double[,] RRm = new double[resizeXmax, resizeYmax];
            double[,] RGm = new double[resizeXmax, resizeYmax];
            double[,] RBm = new double[resizeXmax, resizeYmax];

            double xStep = Convert.ToDouble(xMax - 1) / Convert.ToDouble(resizeXmax - 1);
            double yStep = Convert.ToDouble(yMax - 1) / Convert.ToDouble(resizeYmax - 1);

            if (Double.IsInfinity(xStep)==true)
            {
                xStep = 1;
            }
            if (Double.IsInfinity(yStep)==true)
            {
                yStep = 1;
            }

            for (double yCur =0; Math.Round(yCur,1)<=yMax-1;yCur+=yStep)
            {
                for (double xCur = 0; Math.Round(xCur, 1) <= xMax - 1; xCur += xStep)
                {
                    double x = Math.Round(xCur / xStep, 0);
                    double y = Math.Round(yCur / yStep, 0);
                    double x1 = Math.Floor(xCur);
                    double y1 = Math.Floor(yCur);
                    if(xCur==Math.Floor(xCur)&xCur>=1||xCur>xMax-1)
                    {
                        x1--;
                    }
                    if (yCur == Math.Floor(yCur) & yCur >= 1 || yCur > yMax - 1)
                    {
                        y1--;
                    }

                    double x2 = x1 + 1;
                    double y2 = y1 + 1;
                    int xi = Convert.ToInt32(x);
                    int yi = Convert.ToInt32(y);
                    int xi1 = Convert.ToInt32(x1);
                    int yi1 = Convert.ToInt32(y1);
                    int xi2 = Convert.ToInt32(x2);
                    int yi2 = Convert.ToInt32(y2);

                    RRm[xi,yi]= Rm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Rm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Rm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Rm[xi2, yi2] * (xCur - x1) * (yCur - y1);
                    RGm[xi, yi] = Gm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Gm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Gm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Gm[xi2, yi2] * (xCur - x1) * (yCur - y1);
                    RBm[xi, yi] = Bm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Bm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Bm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Bm[xi2, yi2] * (xCur - x1) * (yCur - y1);

                    Bitmap resizedPicture = new Bitmap(resizeXmax, resizeYmax);

                    for (int j = 0; j < resizeYmax; j++)
                    {
                        for (int i = 0; i < resizeXmax; i++)
                        {
                            resizedPicture.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(RRm[i, j]), Convert.ToInt32(RGm[i, j]), Convert.ToInt32(RBm[i, j])));
                        }
                    }
                    photoBox.Image = resizedPicture;
                    timer.Stop();
                    TimeSpan timerResult = timer.Elapsed;
                    timerLabel.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", timerResult.Hours, timerResult.Minutes, timerResult.Seconds, timerResult.Milliseconds);


                    //Материал использованный в данной работе
                    //Программа не стабильна, необходимо пофиксить
                    //https://ru.wikipedia.org/wiki/Билинейная_интерполяция
                }
            }
        }
    }
}
