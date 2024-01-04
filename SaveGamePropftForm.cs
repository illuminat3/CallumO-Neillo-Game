using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oneillo_2
{
    public partial class SaveGamePromptForm : Form
    {
        public SaveGamePromptForm()
        {
            InitializeComponent();
        }

        public void buttonYesSavePropt_Click(object sender, EventArgs e)
        {
            //    SaveGame();
        }

        private void buttonCancelSavePrompt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNoSavePrompt_Click(object sender, EventArgs e)
        {
            // 
        }
    }
}
