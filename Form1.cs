using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Image_Project
{
    public partial class Form1 : Form
    {
        Bitmap OriginalImage;
        Mat CVImage;
        bool ImageLoaded = false;
        bool MenuToggle = false;
        bool AdaptiveButtons = false;
        public Form1()
        {
            InitializeComponent();
            MedianFBut.Hide();
            AdaptiveFBut.Hide();
            AvergFBut.Hide();
            GaussFBut.Hide();
            InputMask.Hide();
            HistoEqBut.Hide();
            InterpBut.Hide();
            button2.Hide();
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                OriginalImage = new Bitmap(open.FileName);
                CVImage = Cv2.ImRead(open.FileName, ImreadModes.Grayscale);
                ImageLoaded = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            if (ImageLoaded)
            {
                Mat newImage = new Mat(CVImage.Width, CVImage.Height, 0);
                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        List<int> neighboors = new List<int>();
                        neighboors.Add(CVImage.At<byte>(i, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i - 1, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j + 1));
                        neighboors.Add(CVImage.At<byte>(i, j - 1));
                        neighboors.Add(CVImage.At<byte>(i, j + 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j));
                        neighboors.Add(CVImage.At<byte>(i + 1, j + 1));
                        neighboors.Sort();
                        newImage.Set<byte>(i, j, (byte)neighboors[4]);
                    }
                }
                Cv2.ImShow("Median Filter", newImage);
            }
            else
            {
                MessageBox.Show("Load the Image First");
            }
        }

        private void MenuBut_Click(object sender, EventArgs e)
        {
            MenuToggle = !MenuToggle;
            if (MenuToggle)
            {
                MedianFBut.Show();
                AdaptiveFBut.Show();
                AvergFBut.Show();
                GaussFBut.Show();
                InputMask.Show();
                HistoEqBut.Show();
                InterpBut.Show();
            }
            else
            {
                MedianFBut.Hide();
                AdaptiveFBut.Hide();
                AvergFBut.Hide();
                GaussFBut.Hide();
                InputMask.Hide();
                HistoEqBut.Hide();
                InterpBut.Hide();
                button2.Hide();
                button3.Hide();
            }
        }

        private void AdaptiveFBut_Click(object sender, EventArgs e)
        {

            if(ImageLoaded)
            {
                button2.Text = "Max";
                button3.Text = "Min";
                button2.Show();
                button3.Show();
                MessageBox.Show("Choose the Type of Adaptive Filter");
                AdaptiveButtons = true;
            }    
        }

        private void AvergFBut_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            if (ImageLoaded)
            {
                Mat newImage = new Mat(CVImage.Width, CVImage.Height, 0);
                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        List<int> neighboors = new List<int>();
                        neighboors.Add(CVImage.At<byte>(i, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i - 1, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j + 1));
                        neighboors.Add(CVImage.At<byte>(i, j - 1));
                        neighboors.Add(CVImage.At<byte>(i, j + 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j));
                        neighboors.Add(CVImage.At<byte>(i + 1, j + 1));
                        int sum = 0;
                        foreach (int n in neighboors)
                        {
                            sum += n;
                        }
                        newImage.Set<byte>(i, j, (byte)(sum / 9));
                    }
                }
                Cv2.ImShow("Average Filter", newImage);
            }
            else
            {
                MessageBox.Show("Load the Image First");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            if (AdaptiveButtons)
            {
                Mat newImage = new Mat(CVImage.Width, CVImage.Height, 0);
                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        List<int> neighboors = new List<int>();
                        neighboors.Add(CVImage.At<byte>(i, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i - 1, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j + 1));
                        neighboors.Add(CVImage.At<byte>(i, j - 1));
                        neighboors.Add(CVImage.At<byte>(i, j + 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j));
                        neighboors.Add(CVImage.At<byte>(i + 1, j + 1));
                        neighboors.Sort();
                        newImage.Set<byte>(i, j, (byte)neighboors[8]);
                    }
                }
                Cv2.ImShow("Adaptive Filter (Max)", newImage);
                AdaptiveButtons = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            if (AdaptiveButtons)
            {
                Mat newImage = new Mat(CVImage.Width, CVImage.Height, 0);
                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        List<int> neighboors = new List<int>();
                        neighboors.Add(CVImage.At<byte>(i, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i - 1, j));
                        neighboors.Add(CVImage.At<byte>(i - 1, j + 1));
                        neighboors.Add(CVImage.At<byte>(i, j - 1));
                        neighboors.Add(CVImage.At<byte>(i, j + 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j - 1));
                        neighboors.Add(CVImage.At<byte>(i + 1, j));
                        neighboors.Add(CVImage.At<byte>(i + 1, j + 1));
                        neighboors.Sort();
                        newImage.Set<byte>(i, j, (byte)neighboors[0]);
                    }
                }
                Cv2.ImShow("Adaptive Filter (Min)", newImage);
                AdaptiveButtons = false;
            }
        }
    }
}

