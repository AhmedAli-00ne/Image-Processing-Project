namespace Image_Project
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
            this.button1 = new System.Windows.Forms.Button();
            this.MenuBut = new System.Windows.Forms.Button();
            this.MedianFBut = new System.Windows.Forms.Button();
            this.AdaptiveFBut = new System.Windows.Forms.Button();
            this.AvergFBut = new System.Windows.Forms.Button();
            this.GaussFBut = new System.Windows.Forms.Button();
            this.InputMask = new System.Windows.Forms.Button();
            this.HistoEqBut = new System.Windows.Forms.Button();
            this.InterpBut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(505, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select an Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuBut
            // 
            this.MenuBut.Location = new System.Drawing.Point(12, 12);
            this.MenuBut.Name = "MenuBut";
            this.MenuBut.Size = new System.Drawing.Size(265, 81);
            this.MenuBut.TabIndex = 2;
            this.MenuBut.Text = "Menu";
            this.MenuBut.UseVisualStyleBackColor = true;
            this.MenuBut.Click += new System.EventHandler(this.MenuBut_Click);
            // 
            // MedianFBut
            // 
            this.MedianFBut.Location = new System.Drawing.Point(12, 99);
            this.MedianFBut.Name = "MedianFBut";
            this.MedianFBut.Size = new System.Drawing.Size(265, 34);
            this.MedianFBut.TabIndex = 3;
            this.MedianFBut.Text = "Median Filter";
            this.MedianFBut.UseVisualStyleBackColor = true;
            this.MedianFBut.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdaptiveFBut
            // 
            this.AdaptiveFBut.Location = new System.Drawing.Point(12, 139);
            this.AdaptiveFBut.Name = "AdaptiveFBut";
            this.AdaptiveFBut.Size = new System.Drawing.Size(265, 34);
            this.AdaptiveFBut.TabIndex = 4;
            this.AdaptiveFBut.Text = "Adaptive Filter";
            this.AdaptiveFBut.UseVisualStyleBackColor = true;
            // 
            // AvergFBut
            // 
            this.AvergFBut.Location = new System.Drawing.Point(12, 179);
            this.AvergFBut.Name = "AvergFBut";
            this.AvergFBut.Size = new System.Drawing.Size(265, 34);
            this.AvergFBut.TabIndex = 5;
            this.AvergFBut.Text = "Averaging Filter";
            this.AvergFBut.UseVisualStyleBackColor = true;
            // 
            // GaussFBut
            // 
            this.GaussFBut.Location = new System.Drawing.Point(12, 219);
            this.GaussFBut.Name = "GaussFBut";
            this.GaussFBut.Size = new System.Drawing.Size(265, 34);
            this.GaussFBut.TabIndex = 6;
            this.GaussFBut.Text = "Gaussian Filter";
            this.GaussFBut.UseVisualStyleBackColor = true;
            // 
            // InputMask
            // 
            this.InputMask.Location = new System.Drawing.Point(12, 259);
            this.InputMask.Name = "InputMask";
            this.InputMask.Size = new System.Drawing.Size(265, 34);
            this.InputMask.TabIndex = 7;
            this.InputMask.Text = "Input Your Mask";
            this.InputMask.UseVisualStyleBackColor = true;
            // 
            // HistoEqBut
            // 
            this.HistoEqBut.Location = new System.Drawing.Point(12, 299);
            this.HistoEqBut.Name = "HistoEqBut";
            this.HistoEqBut.Size = new System.Drawing.Size(265, 34);
            this.HistoEqBut.TabIndex = 8;
            this.HistoEqBut.Text = "Histogram Equalization";
            this.HistoEqBut.UseVisualStyleBackColor = true;
            // 
            // InterpBut
            // 
            this.InterpBut.Location = new System.Drawing.Point(12, 339);
            this.InterpBut.Name = "InterpBut";
            this.InterpBut.Size = new System.Drawing.Size(265, 34);
            this.InterpBut.TabIndex = 9;
            this.InterpBut.Text = "Interpolation";
            this.InterpBut.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox1.Location = new System.Drawing.Point(283, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 378);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InterpBut);
            this.Controls.Add(this.HistoEqBut);
            this.Controls.Add(this.InputMask);
            this.Controls.Add(this.GaussFBut);
            this.Controls.Add(this.AvergFBut);
            this.Controls.Add(this.AdaptiveFBut);
            this.Controls.Add(this.MedianFBut);
            this.Controls.Add(this.MenuBut);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button MenuBut;
        private System.Windows.Forms.Button MedianFBut;
        private System.Windows.Forms.Button AdaptiveFBut;
        private System.Windows.Forms.Button AvergFBut;
        private System.Windows.Forms.Button GaussFBut;
        private System.Windows.Forms.Button InputMask;
        private System.Windows.Forms.Button HistoEqBut;
        private System.Windows.Forms.Button InterpBut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

