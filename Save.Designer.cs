using Newtonsoft.Json;

namespace Oneillo_2
{
    partial class Save
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxSavedGameList = new ComboBox();
            labelSavedGames = new Label();
            SuspendLayout();
            // 
            // comboBoxSavedGameList
            // 
            comboBoxSavedGameList.Enabled = false;
            comboBoxSavedGameList.FormattingEnabled = true;
            comboBoxSavedGameList.Location = new Point(105, 88);
            comboBoxSavedGameList.Name = "comboBoxSavedGameList";
            comboBoxSavedGameList.Size = new Size(245, 23);
            comboBoxSavedGameList.TabIndex = 0;
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
            // Save
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelSavedGames);
            Controls.Add(comboBoxSavedGameList);
            Name = "Save";
            Size = new Size(462, 452);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private string filePath;
        private dynamic data;

        private ComboBox comboBoxSavedGameList;
        private Label labelSavedGames;
    }
}
