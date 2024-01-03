namespace Oneillo_2
{
    partial class SaveGameForm
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
            labelSavedGames = new Label();
            buttonSaveGame = new Button();
            textBoxGameName = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(105, 88);
            comboBox1.MaxDropDownItems = 5;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 23);
            comboBox1.TabIndex = 0;
            // 
            // labelSavedGames
            // 
            labelSavedGames.AutoSize = true;
            labelSavedGames.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelSavedGames.Location = new Point(150, 39);
            labelSavedGames.Name = "labelSavedGames";
            labelSavedGames.Size = new Size(154, 23);
            labelSavedGames.TabIndex = 1;
            labelSavedGames.Text = "Saved Games";
            // 
            // buttonSaveGame
            // 
            buttonSaveGame.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSaveGame.Location = new Point(150, 325);
            buttonSaveGame.Name = "buttonSaveGame";
            buttonSaveGame.Size = new Size(154, 67);
            buttonSaveGame.TabIndex = 2;
            buttonSaveGame.Text = "Save Game";
            buttonSaveGame.UseVisualStyleBackColor = true;
            buttonSaveGame.Click += buttonSaveGame_Click;
            // 
            // textBoxGameName
            // 
            textBoxGameName.Location = new Point(105, 225);
            textBoxGameName.Name = "textBoxGameName";
            textBoxGameName.Size = new Size(245, 23);
            textBoxGameName.TabIndex = 3;
            // 
            // SaveGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 413);
            Controls.Add(textBoxGameName);
            Controls.Add(buttonSaveGame);
            Controls.Add(labelSavedGames);
            Controls.Add(comboBox1);
            Name = "SaveGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private string filePath;
        private dynamic data;

        private ComboBox comboBox1;
        private Label labelSavedGames;
        private Button buttonSaveGame;
        private TextBox textBoxGameName;
    }
}