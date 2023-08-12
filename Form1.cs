using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Project
{
    public partial class Form1 : Form
    {
        Bitmap OriginalImage;
        bool ImageLoaded = false;
        bool MenuToggle = false;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                OriginalImage = new Bitmap(open.FileName);
                ImageLoaded = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //apply median filter to the original image without using Filters method
            
            
        }

        private void MenuBut_Click(object sender, EventArgs e)
        {
            MenuToggle = !MenuToggle;
            if(MenuToggle)
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
            }
        }
    }
}
