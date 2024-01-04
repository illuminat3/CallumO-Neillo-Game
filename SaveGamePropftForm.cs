using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oneillo_2
{
    public partial class SaveGamePromptForm : Form
    {
        private GameboardForm form;
        private GameState currentGameState;
        public SaveGamePromptForm(GameboardForm form, int[,] boardData, string playerOneName, string playerTwoName, int numOfBlack, int numOfWhite, int player, int gameMoves, string gameName)
        {
            InitializeComponent();
            this.form = form;
            currentGameState = new GameState(boardData, playerOneName, playerTwoName, numOfBlack, numOfWhite, player, gameMoves, gameName);
        }


        public void buttonYesSavePropt_Click(object sender, EventArgs e)
        {
            SaveGameForm saveGameForm = new SaveGameForm(currentGameState);
            saveGameForm.Show();
            form.NewGame();
            this.Close();
        }

        private void buttonCancelSavePrompt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNoSavePrompt_Click(object sender, EventArgs e)
        {
            form.NewGame();
            this.Close();
        }
    }
}
