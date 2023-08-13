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
    public partial class Form2 : Form
    {
        public static Form2 Form2Data;
        public Form2()
        {
            InitializeComponent();
            Form2Data = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Value1.Text != "" && Value2.Text != "" && Value3.Text != "" && Value4.Text != "" && Value5.Text != "" && Value6.Text != "" && Value7.Text != "" && Value8.Text != "" && Value9.Text != "")
            {
                Form1.Form1Data.InputKernel.Set<int>(0, 0, Convert.ToInt32(Value1.Text));
                Form1.Form1Data.InputKernel.Set<int>(0, 1, Convert.ToInt32(Value2.Text));
                Form1.Form1Data.InputKernel.Set<int>(0, 2, Convert.ToInt32(Value3.Text));
                Form1.Form1Data.InputKernel.Set<int>(1, 0, Convert.ToInt32(Value4.Text));
                Form1.Form1Data.InputKernel.Set<int>(1, 1, Convert.ToInt32(Value5.Text));
                Form1.Form1Data.InputKernel.Set<int>(1, 2, Convert.ToInt32(Value6.Text));
                Form1.Form1Data.InputKernel.Set<int>(2, 0, Convert.ToInt32(Value7.Text));
                Form1.Form1Data.InputKernel.Set<int>(2, 1, Convert.ToInt32(Value8.Text));
                Form1.Form1Data.InputKernel.Set<int>(2, 2, Convert.ToInt32(Value9.Text));
            }
            this.Hide();
        }

        private void Value1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
