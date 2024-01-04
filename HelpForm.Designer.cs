namespace Oneillo_2
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            pictureBox1 = new PictureBox();
            labelOneilloHelp = new Label();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            labelCopyRight = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(313, 107);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(542, 565);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelOneilloHelp
            // 
            labelOneilloHelp.AutoSize = true;
            labelOneilloHelp.BackColor = Color.Transparent;
            labelOneilloHelp.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelOneilloHelp.ForeColor = Color.Navy;
            labelOneilloHelp.Location = new Point(223, 19);
            labelOneilloHelp.Name = "labelOneilloHelp";
            labelOneilloHelp.Size = new Size(381, 42);
            labelOneilloHelp.TabIndex = 1;
            labelOneilloHelp.Text = "O'Neillo Help Page";
            labelOneilloHelp.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 93);
            label1.Name = "label1";
            label1.Size = new Size(286, 29);
            label1.TabIndex = 2;
            label1.Text = "How to Play O'Neillo";
            label1.Click += label1_Click_1;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Beige;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.EnableAutoDragDrop = true;
            richTextBox1.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.Location = new Point(12, 162);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(269, 523);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // labelCopyRight
            // 
            labelCopyRight.AutoSize = true;
            labelCopyRight.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelCopyRight.ForeColor = SystemColors.ButtonShadow;
            labelCopyRight.Location = new Point(619, 698);
            labelCopyRight.Name = "labelCopyRight";
            labelCopyRight.Size = new Size(224, 14);
            labelCopyRight.TabIndex = 4;
            labelCopyRight.Text = "CopyRight Callum Cunningham ©";
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(855, 721);
            Controls.Add(labelCopyRight);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(labelOneilloHelp);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelOneilloHelp;
        private Label label1;
        private RichTextBox richTextBox1;
        private Label labelCopyRight;
    }
}