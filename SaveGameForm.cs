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

            data = JsonConvert.DeserializeObject(File.ReadAllText(filePath));         // json deserialization 

            if (data.Games.Count != 0)
            {
                for (int i = 0; i < data.Games.Count; i++)   // loop through the list
                {
                    comboBox1.Items[i] = data.Games[i].gameName;
                }
            }

            textBoxGameName.Text = gameState.gameName;
        }

        public void SaveGame()
        {
            // Ensure Games collection is initialized
            if (data.Games == null)
            {
                data.Games = new List<string>(); // Assuming data.Games is a list of strings (serialized game states)
            }

            // Check the count
            if (data.Games.Count >= 5)
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < data.Games.Count)
                {
                    data.Games[comboBox1.SelectedIndex] = JsonConvert.SerializeObject(gameState);
                }
                else
                {
                    return;
                }
            }
            else
            {
                // Add serialized gameState to the Games collection
                data.Games.Add(JsonConvert.SerializeObject(gameState));
            }
        }


        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            SaveGame();
            Close();
        }
    }
}
