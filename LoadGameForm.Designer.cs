namespace Oneillo_2
{
    partial class LoadGameForm
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
            comboBox1 = new ComboBox();
            buttonLoadSavedGame = new Button();
            labelLoadSavedGames = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(75, 103);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(269, 23);
            comboBox1.TabIndex = 0;
            // 
            // buttonLoadSavedGame
            // 
            buttonLoadSavedGame.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoadSavedGame.Location = new Point(132, 228);
            buttonLoadSavedGame.Name = "buttonLoadSavedGame";
            buttonLoadSavedGame.Size = new Size(131, 65);
            buttonLoadSavedGame.TabIndex = 1;
            buttonLoadSavedGame.Text = "Load";
            buttonLoadSavedGame.UseVisualStyleBackColor = true;
            buttonLoadSavedGame.Click += buttonLoadSavedGame_Click;
            // 
            // labelLoadSavedGames
            // 
            labelLoadSavedGames.AutoEllipsis = true;
            labelLoadSavedGames.AutoSize = true;
            labelLoadSavedGames.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoadSavedGames.Location = new Point(107, 42);
            labelLoadSavedGames.Name = "labelLoadSavedGames";
            labelLoadSavedGames.Size = new Size(201, 23);
            labelLoadSavedGames.TabIndex = 2;
            labelLoadSavedGames.Text = "Load Saved Game";
            // 
            // LoadGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 390);
            Controls.Add(labelLoadSavedGames);
            Controls.Add(buttonLoadSavedGame);
            Controls.Add(comboBox1);
            Name = "LoadGameForm";
            Text = "LoadGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button buttonLoadSavedGame;
        private Label labelLoadSavedGames;
    }
}