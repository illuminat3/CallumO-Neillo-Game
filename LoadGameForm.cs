using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oneillo_2
{
    public partial class LoadGameForm : Form
    {
        public LoadGameForm()
        {
            InitializeComponent();
        }

        private void buttonLoadSavedGame_Click(object sender, EventArgs e)
        {
            private GameData data;
            int selectedIndex = comboBox1.SelectedIndex;
            GameState loadGameState = data.games[selectedIndex];
        }
    }
}
