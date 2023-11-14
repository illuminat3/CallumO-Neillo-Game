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
            PlayerOnePieceLbl = new Label();
            PlayerTwoPieceLbl = new Label();
            PlayerOneName = new TextBox();
            PlayerTwoName = new TextBox();
            SuspendLayout();
            // 
            // PlayerOnePieceLbl
            // 
            PlayerOnePieceLbl.AutoSize = true;
            PlayerOnePieceLbl.Location = new Point(136, 740);
            PlayerOnePieceLbl.Name = "PlayerOnePieceLbl";
            PlayerOnePieceLbl.Size = new Size(38, 15);
            PlayerOnePieceLbl.TabIndex = 0;
            PlayerOnePieceLbl.Text = "label1";
            // 
            // PlayerTwoPieceLbl
            // 
            PlayerTwoPieceLbl.AutoSize = true;
            PlayerTwoPieceLbl.Location = new Point(359, 740);
            PlayerTwoPieceLbl.Name = "PlayerTwoPieceLbl";
            PlayerTwoPieceLbl.Size = new Size(38, 15);
            PlayerTwoPieceLbl.TabIndex = 1;
            PlayerTwoPieceLbl.Text = "label1";
            // 
            // PlayerOneName
            // 
            PlayerOneName.Location = new Point(12, 737);
            PlayerOneName.Name = "PlayerOneName";
            PlayerOneName.Size = new Size(100, 23);
            PlayerOneName.TabIndex = 2;
            // 
            // PlayerTwoName
            // 
            PlayerTwoName.Location = new Point(235, 737);
            PlayerTwoName.Name = "PlayerTwoName";
            PlayerTwoName.Size = new Size(100, 23);
            PlayerTwoName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(792, 769);
            Controls.Add(PlayerTwoName);
            Controls.Add(PlayerOneName);
            Controls.Add(PlayerTwoPieceLbl);
            Controls.Add(PlayerOnePieceLbl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlayerOnePieceLbl;
        private Label PlayerTwoPieceLbl;
        private TextBox PlayerOneName;
        private TextBox PlayerTwoName;
    }
}