using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Oneillo_2
{
    public partial class SaveGameForm : Form
    {
        private GameState gameState;
        private GameData data;
        private const int maxGames = 5;
        private string filePath = "GameData/Game_Data.JSON";


        public SaveGameForm(GameState currentGameState)
        {
            InitializeComponent();

            gameState = currentGameState;
            LoadGameData();
            textBoxGameName.Text = gameState.gameName;
        }


        private void LoadGameData()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<GameData>(jsonData);
            }
            else
            {
                data = new GameData(new List<GameState>());
            }

            comboBox1.Items.Clear();
            foreach (var game in data.games)
            {
                comboBox1.Items.Add(game.gameName);
            }
        }


        private void SaveGame()
        {
            int selectedIndex = comboBox1.SelectedIndex;

            if (textBoxGameName.Text != null || textBoxGameName.Text != "")
            {
                gameState.gameName = textBoxGameName.Text;
            }
            else
            {
                gameState.gameName = DateTime.Now.ToString();
            }

            if (selectedIndex >= 0 && selectedIndex < data.games.Count)
            {

                data.games[selectedIndex] = gameState;
            }
            else if (data.games.Count < maxGames)
            {
                // If the selected index is out of range (implying a new game),
                // and the total number of games is less than MaxGames, add the new game
                data.games.Add(gameState);
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
        }

        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            SaveGame();
            Close();
        }
    }
}
