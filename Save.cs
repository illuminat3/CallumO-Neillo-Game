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

namespace Oneillo_2
{
    public partial class Save : UserControl
    {
        private GameState gameState;
        public Save(GameState currentGameState)
        {

            gameState = currentGameState;

            InitializeComponent();

            filePath = "GameData/Game_Data.JSON";

            data = JsonConvert.DeserializeObject(File.ReadAllText(filePath));

            if (data.Games.Count != 0)
            {
                for (int i = 0; i < data.Games.Count; i++)
                {
                    comboBoxSavedGameList.Items[i] = data.Games[i].gameName;
                }
            }
        }

        public void SaveGame(GameState gameState)
        {

            string filePath = "GameData/Game_Data.JSON";

            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(filePath)); // saving game state

            for (int i = 0; i < data.Games.Length; i++)
            {
                comboBoxSavedGameList.Items[i] = data.Games[i].gameName;   
            }

            if (data.Games.Count < 5)
            {
                data.Games.Add(gameState);     //loops and resolves accordingly
            }
            else
            {
                //Logic to overwrite
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));

            // Make sure you have read all data that already exists and add it into the string
            // Make sure that you specify different names for different games

        }
    }
}
