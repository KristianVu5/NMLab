namespace NMLab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            txtVectors = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(84, 780);
            button1.Name = "button1";
            button1.Size = new Size(319, 72);
            button1.TabIndex = 0;
            button1.Text = "OpenFile";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnChooseImage_Click;
            // 
            // button2
            // 
            button2.Location = new Point(84, 884);
            button2.Name = "button2";
            button2.Size = new Size(319, 72);
            button2.TabIndex = 1;
            button2.Text = "LoadImageColor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnGrayscale_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(39, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1142, 594);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(1221, 57);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1142, 594);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // txtVectors
            // 
            txtVectors.Location = new Point(550, 780);
            txtVectors.Multiline = true;
            txtVectors.Name = "txtVectors";
            txtVectors.ScrollBars = ScrollBars.Vertical;
            txtVectors.Size = new Size(1759, 252);
            txtVectors.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2408, 1171);
            Controls.Add(txtVectors);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox txtVectors;
    }
}
