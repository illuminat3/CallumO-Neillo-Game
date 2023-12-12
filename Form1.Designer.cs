namespace Oneillo_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblBlack = new Label();
            lblWhite = new Label();
            lblGameMoves = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1;
            pictureBox1.Location = new Point(12, 674);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 112);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._2;
            pictureBox2.Location = new Point(655, 671);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 112);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // lblBlack
            // 
            lblBlack.AutoSize = true;
            lblBlack.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblBlack.ForeColor = SystemColors.ControlLightLight;
            lblBlack.Location = new Point(146, 725);
            lblBlack.Name = "lblBlack";
            lblBlack.Size = new Size(84, 25);
            lblBlack.TabIndex = 2;
            lblBlack.Text = "label1";
            lblBlack.Click += label1_Click;
            // 
            // lblWhite
            // 
            lblWhite.AutoSize = true;
            lblWhite.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblWhite.ForeColor = SystemColors.ControlLightLight;
            lblWhite.Location = new Point(510, 725);
            lblWhite.Name = "lblWhite";
            lblWhite.Size = new Size(84, 25);
            lblWhite.TabIndex = 3;
            lblWhite.Text = "label2";
            // 
            // lblGameMoves
            // 
            lblGameMoves.AutoSize = true;
            lblGameMoves.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameMoves.ForeColor = Color.Pink;
            lblGameMoves.Location = new Point(335, 773);
            lblGameMoves.Name = "lblGameMoves";
            lblGameMoves.Size = new Size(60, 18);
            lblGameMoves.TabIndex = 4;
            lblGameMoves.Text = "label3";
            lblGameMoves.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(792, 795);
            Controls.Add(lblGameMoves);
            Controls.Add(lblWhite);
            Controls.Add(lblBlack);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblBlack;
        private Label lblWhite;
        private Label lblGameMoves;
    }
}