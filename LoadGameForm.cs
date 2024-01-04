using Newtonsoft.Json;
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
        private GameData data;
        private const string filePath = "GameData/Game_Data.JSON";

        public LoadGameForm()
        {
            InitializeComponent();
            LoadGameData();
        }

        private void LoadGameData()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<GameData>(jsonData);
            }

            comboBox1.Items.Clear();
            foreach (var game in data.games)
            {
                comboBox1.Items.Add(game.gameName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void buttonLoadSavedGame_Click(object sender, EventArgs e)
        { 
            int selectedIndex = comboBox1.SelectedIndex;
            GameState loadGameState = data.games[selectedIndex];
            
        }
    }
}
