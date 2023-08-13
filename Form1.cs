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
        public static Form1 Form1Data;
        public Mat InputKernel = new Mat(3, 3, 0);
        Bitmap OriginalImage;
        Mat CVImage;
        bool ImageLoaded = false;
        bool MenuToggle = false;
        bool AdaptiveButtons = false;
        bool InputMaskStart = false;
        bool Interpolation = false;
        public Form1()
        {
            InitializeComponent();
            Form1Data = this;
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
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
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
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
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
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
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
            else if(InputMaskStart)
            {
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 1; i < newImage.Rows - 1; i++)
                {
                    for (int j = 1; j < newImage.Cols - 1; j++)
                    {

                        int sum = 0;
                        sum += CVImage.At<byte>(i - 1, j - 1) * InputKernel.At<byte>(0, 0);
                        sum += CVImage.At<byte>(i - 1, j) * InputKernel.At<byte>(0, 1);
                        sum += CVImage.At<byte>(i - 1, j + 1) * InputKernel.At<byte>(0, 2);
                        sum += CVImage.At<byte>(i, j - 1) * InputKernel.At<byte>(1, 0);
                        sum += CVImage.At<byte>(i, j) * InputKernel.At<byte>(1, 1);
                        sum += CVImage.At<byte>(i, j + 1) * InputKernel.At<byte>(1, 2);
                        sum += CVImage.At<byte>(i + 1, j - 1) * InputKernel.At<byte>(2, 0);
                        sum += CVImage.At<byte>(i + 1, j) * InputKernel.At<byte>(2, 1);
                        sum += CVImage.At<byte>(i + 1, j + 1) * InputKernel.At<byte>(2, 2);
                        newImage.Set<byte>(i, j, (byte)sum);
                    }
                }
                Cv2.ImShow("Input Mask", newImage);
                InputMaskStart = false;
            }
            else if(Interpolation)
            {
                Mat newImage = new Mat(CVImage.Rows * 2, CVImage.Cols * 2, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
                    {
                        int x = (int)Math.Floor((double)i / 2);
                        int y = (int)Math.Floor((double)j / 2);
                        int x1 = x + 1;
                        int y1 = y + 1;
                        if (x1 >= CVImage.Rows)
                        {
                            x1 = x;
                        }
                        if (y1 >= CVImage.Cols)
                        {
                            y1 = y;
                        }
                        double a = (double)i / 2 - x;
                        double b = (double)j / 2 - y;
                        double aMinus = 1 - a;
                        double bMinus = 1 - b;
                        double p00 = CVImage.At<byte>(x, y);
                        double p01 = CVImage.At<byte>(x, y1);
                        double p10 = CVImage.At<byte>(x1, y);
                        double p11 = CVImage.At<byte>(x1, y1);
                        double newPixel = aMinus * bMinus * p00 + aMinus * b * p01 + a * bMinus * p10 + a * b * p11;
                        newImage.Set<byte>(i, j, (byte)newPixel);
                    }
                }
                Cv2.ImShow("Interpolation", newImage);
                Interpolation = false;
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            if (AdaptiveButtons)
            {
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
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
            else if(Interpolation)
            {
                Mat newImage = new Mat(CVImage.Rows * 2, CVImage.Cols * 2, 0);
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
                    {
                        int x = (int)Math.Floor((double)i / 2);
                        int y = (int)Math.Floor((double)j / 2);
                        newImage.Set<byte>(i, j, CVImage.At<byte>(x, y));
                    }
                }
                Cv2.ImShow("Interpolation", newImage);
                Interpolation = false;
            }
        }

        private void GaussFBut_Click(object sender, EventArgs e)
        {
            if (ImageLoaded)
            {
                double[,] kernel = new double[3, 3];
                kernel[0, 0] = 1;
                kernel[0, 1] = 2;
                kernel[0, 2] = 1;
                kernel[1, 0] = 2;
                kernel[1, 1] = 4;
                kernel[1, 2] = 2;
                kernel[2, 0] = 1;
                kernel[2, 1] = 2;
                kernel[2, 2] = 1;
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                for (int i = 1; i < newImage.Rows - 1; i++)
                {
                    for (int j = 1; j < newImage.Cols - 1; j++)
                    {
                        double sum = 0;
                        sum += CVImage.At<byte>(i - 1, j - 1) * kernel[0, 0];
                        sum += CVImage.At<byte>(i - 1, j) * kernel[0, 1];
                        sum += CVImage.At<byte>(i - 1, j + 1) * kernel[0, 2];
                        sum += CVImage.At<byte>(i, j - 1) * kernel[1, 0];
                        sum += CVImage.At<byte>(i, j) * kernel[1, 1];
                        sum += CVImage.At<byte>(i, j + 1) * kernel[1, 2];
                        sum += CVImage.At<byte>(i + 1, j - 1) * kernel[2, 0];
                        sum += CVImage.At<byte>(i + 1, j) * kernel[2, 1];
                        sum += CVImage.At<byte>(i + 1, j + 1) * kernel[2, 2];
                        sum /= 16;
                        newImage.Set<byte>(i, j, (byte)sum);
                    }
                }
                Cv2.ImShow("Gauss Filter", newImage);
            }
        }

        private void InputMask_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            button2.Text = "Start";
            button2.Show();
            InputMaskStart = true;
        }

        private void InterpBut_Click(object sender, EventArgs e)
        {
            if (ImageLoaded)
            {
                button2.Text = "Bilinear";
                button3.Text = "Nearest";
                button2.Show();
                button3.Show();
                MessageBox.Show("Choose the Type of the Interpolation");
                Interpolation = true;
            }
        }

        private void HistoEqBut_Click(object sender, EventArgs e)
        {
            if (ImageLoaded)
            {
                //apply histogram equalization on the grayscale image CVImage
                Mat newImage = new Mat(CVImage.Rows, CVImage.Cols, 0);
                int[] hist = new int[256];
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
                    {
                        hist[CVImage.At<byte>(i, j)]++;
                    }
                }
                int[] histEqual = new int[256];
                histEqual[0] = hist[0];
                for (int i = 1; i < 256; i++)
                {
                    histEqual[i] = histEqual[i - 1] + hist[i];
                }
                for (int i = 0; i < newImage.Rows; i++)
                {
                    for (int j = 0; j < newImage.Cols; j++)
                    {
                        double value = (double)histEqual[CVImage.At<byte>(i, j)] / (newImage.Rows * newImage.Cols) * 255;
                        newImage.Set<byte>(i, j, (byte)value);
                    }
                }
                Cv2.ImShow("Histogram Equalization", newImage);
            }
        }
    }
}

