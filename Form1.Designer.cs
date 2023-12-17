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
            pictureBoxBlkToMove = new PictureBox();
            pictureBoxWhtToMove = new PictureBox();
            richTextBoxPlayerOne = new RichTextBox();
            richTextBoxPlayerTwo = new RichTextBox();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButtonGame = new ToolStripDropDownButton();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSave = new ToolStripLabel();
            toolStripHelp = new ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBlkToMove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhtToMove).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1;
            pictureBox1.Location = new Point(16, 709);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 112);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._2;
            pictureBox2.Location = new Point(657, 706);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(123, 115);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // lblBlack
            // 
            lblBlack.AutoSize = true;
            lblBlack.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblBlack.ForeColor = SystemColors.ControlLightLight;
            lblBlack.Location = new Point(142, 771);
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
            lblWhite.Location = new Point(463, 771);
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
            lblGameMoves.Location = new Point(332, 844);
            lblGameMoves.Name = "lblGameMoves";
            lblGameMoves.Size = new Size(60, 18);
            lblGameMoves.TabIndex = 4;
            lblGameMoves.Text = "label3";
            lblGameMoves.Click += label3_Click;
            // 
            // pictureBoxBlkToMove
            // 
            pictureBoxBlkToMove.Image = (Image)resources.GetObject("pictureBoxBlkToMove.Image");
            pictureBoxBlkToMove.InitialImage = (Image)resources.GetObject("pictureBoxBlkToMove.InitialImage");
            pictureBoxBlkToMove.Location = new Point(12, 706);
            pictureBoxBlkToMove.Name = "pictureBoxBlkToMove";
            pictureBoxBlkToMove.Size = new Size(132, 115);
            pictureBoxBlkToMove.TabIndex = 5;
            pictureBoxBlkToMove.TabStop = false;
            // 
            // pictureBoxWhtToMove
            // 
            pictureBoxWhtToMove.AccessibleRole = AccessibleRole.None;
            pictureBoxWhtToMove.Image = (Image)resources.GetObject("pictureBoxWhtToMove.Image");
            pictureBoxWhtToMove.Location = new Point(657, 704);
            pictureBoxWhtToMove.Name = "pictureBoxWhtToMove";
            pictureBoxWhtToMove.Size = new Size(123, 117);
            pictureBoxWhtToMove.TabIndex = 6;
            pictureBoxWhtToMove.TabStop = false;
            // 
            // richTextBoxPlayerOne
            // 
            richTextBoxPlayerOne.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBoxPlayerOne.Location = new Point(530, 836);
            richTextBoxPlayerOne.Name = "richTextBoxPlayerOne";
            richTextBoxPlayerOne.Size = new Size(250, 26);
            richTextBoxPlayerOne.TabIndex = 7;
            richTextBoxPlayerOne.Text = "";
            // 
            // richTextBoxPlayerTwo
            // 
            richTextBoxPlayerTwo.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBoxPlayerTwo.Location = new Point(16, 836);
            richTextBoxPlayerTwo.Name = "richTextBoxPlayerTwo";
            richTextBoxPlayerTwo.Size = new Size(250, 26);
            richTextBoxPlayerTwo.TabIndex = 8;
            richTextBoxPlayerTwo.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.LightSteelBlue;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButtonGame, toolStripSave, toolStripHelp });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(792, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonGame
            // 
            toolStripDropDownButtonGame.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonGame.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem });
            toolStripDropDownButtonGame.Image = (Image)resources.GetObject("toolStripDropDownButtonGame.Image");
            toolStripDropDownButtonGame.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonGame.Name = "toolStripDropDownButtonGame";
            toolStripDropDownButtonGame.Size = new Size(51, 22);
            toolStripDropDownButtonGame.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(132, 22);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // toolStripSave
            // 
            toolStripSave.Name = "toolStripSave";
            toolStripSave.Size = new Size(31, 22);
            toolStripSave.Text = "Save";
            toolStripSave.Click += toolStripLabel1_Click;
            // 
            // toolStripHelp
            // 
            toolStripHelp.Name = "toolStripHelp";
            toolStripHelp.Size = new Size(32, 22);
            toolStripHelp.Text = "Help";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(792, 874);
            Controls.Add(toolStrip1);
            Controls.Add(richTextBoxPlayerTwo);
            Controls.Add(richTextBoxPlayerOne);
            Controls.Add(pictureBoxWhtToMove);
            Controls.Add(pictureBoxBlkToMove);
            Controls.Add(lblGameMoves);
            Controls.Add(lblWhite);
            Controls.Add(lblBlack);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBlkToMove).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhtToMove).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblBlack;
        private Label lblWhite;
        private Label lblGameMoves;
        private PictureBox pictureBoxBlkToMove;
        private PictureBox pictureBoxWhtToMove;
        private RichTextBox richTextBoxPlayerOne;
        private RichTextBox richTextBoxPlayerTwo;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripSave;
        private ToolStripLabel toolStripHelp;
        private ToolStripDropDownButton toolStripDropDownButtonGame;
        private ToolStripMenuItem newGameToolStripMenuItem;
    }
}