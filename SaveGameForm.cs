using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Oneillo_2
{
    public partial class SaveGameForm : Form
    {
        private GameState gameState;
        public SaveGameForm(GameState currentGameState)
        {

            gameState = currentGameState;

            InitializeComponent();

            filePath = "GameData/Game_Data.JSON";

            data = JsonConvert.DeserializeObject(File.ReadAllText(filePath));

            if (data.Games == null)
            {
                // No games exist, create a list to avoid errors
                data.Games = new List<GameState>();
            }
            else
            {
                // Games exist, add them to the combobox
                for (int i = 0; i < data.Games.Count; i++)
                {
                    comboBox1.Items[i] = data.Games[i].gameName;
                }
            }

            textBoxGameName.Text = gameState.gameName;
        }

        public void SaveGame()
        {
            int gameCounter = data.Games.Count;


            //Checks whether to override a gamestate or to add the gamestate
            if (comboBox1.SelectedIndex == gameCounter)
            {
                data.Games.Add(gameState);
            }
            else
            {
                data.Games[comboBox1.SelectedIndex] = gameState;
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
