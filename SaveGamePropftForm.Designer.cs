namespace Oneillo_2
{
    partial class SaveGamePromptForm
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
            labelSaveGamePropt = new Label();
            buttonYesSavePropt = new Button();
            buttonNoSavePrompt = new Button();
            buttonCancelSavePrompt = new Button();
            SuspendLayout();
            // 
            // labelSaveGamePropt
            // 
            labelSaveGamePropt.AutoSize = true;
            labelSaveGamePropt.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelSaveGamePropt.Location = new Point(188, 44);
            labelSaveGamePropt.Name = "labelSaveGamePropt";
            labelSaveGamePropt.Size = new Size(143, 25);
            labelSaveGamePropt.TabIndex = 0;
            labelSaveGamePropt.Text = "Save Game";
            // 
            // buttonYesSavePropt
            // 
            buttonYesSavePropt.BackColor = Color.Chartreuse;
            buttonYesSavePropt.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonYesSavePropt.Location = new Point(45, 175);
            buttonYesSavePropt.Name = "buttonYesSavePropt";
            buttonYesSavePropt.Size = new Size(146, 53);
            buttonYesSavePropt.TabIndex = 1;
            buttonYesSavePropt.Text = "Yes";
            buttonYesSavePropt.UseVisualStyleBackColor = false;
            buttonYesSavePropt.Click += buttonYesSavePropt_Click;
            // 
            // buttonNoSavePrompt
            // 
            buttonNoSavePrompt.BackColor = Color.Tomato;
            buttonNoSavePrompt.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNoSavePrompt.Location = new Point(197, 175);
            buttonNoSavePrompt.Name = "buttonNoSavePrompt";
            buttonNoSavePrompt.Size = new Size(145, 53);
            buttonNoSavePrompt.TabIndex = 2;
            buttonNoSavePrompt.Text = "No";
            buttonNoSavePrompt.UseVisualStyleBackColor = false;
            // 
            // buttonCancelSavePrompt
            // 
            buttonCancelSavePrompt.BackColor = SystemColors.AppWorkspace;
            buttonCancelSavePrompt.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCancelSavePrompt.Location = new Point(348, 175);
            buttonCancelSavePrompt.Name = "buttonCancelSavePrompt";
            buttonCancelSavePrompt.Size = new Size(140, 53);
            buttonCancelSavePrompt.TabIndex = 3;
            buttonCancelSavePrompt.Text = "Cancel";
            buttonCancelSavePrompt.UseVisualStyleBackColor = false;
            buttonCancelSavePrompt.Click += buttonCancelSavePrompt_Click;
            // 
            // SaveGamePromptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(548, 269);
            Controls.Add(buttonCancelSavePrompt);
            Controls.Add(buttonNoSavePrompt);
            Controls.Add(buttonYesSavePropt);
            Controls.Add(labelSaveGamePropt);
            Name = "SaveGamePromptForm";
            Text = "SaveGamePropftForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSaveGamePropt;
        private Button buttonYesSavePropt;
        private Button buttonNoSavePrompt;
        private Button buttonCancelSavePrompt;
    }
}