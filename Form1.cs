using GameboardGUI;
using Newtonsoft.Json;
using System.Speech.Synthesis;


namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        GameboardImageArray _gameboardGui;

        private const int rows = 8, columns = 8;
        private int[,] boardData;
        private int gameMoves = 0; // implement this in the GUI
        private int numOfBlack, numOfWhite;
        private int player = 1;
        int onOff = 0;
        int speakOnOff = 0;

        private string imagepaths = $"{Environment.CurrentDirectory}\\resources\\";
        private string winner;  // implement this in the GUI
        private string playerOneName;
        private string playerTwoName;
        private string gameName = DateTime.Now.ToString();

        private bool speak;
        private bool showInfoPanel;

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        private List<GameState> savedGames = new List<GameState>();

        private int[,] MakeBoardArray()
        {
            int[,] StartArray = new int[rows, columns];

            StartArray[3, 3] = 2;
            StartArray[4, 4] = 2;
            StartArray[3, 4] = 1;
            StartArray[4, 3] = 1;
            return StartArray;
        }
        // On start setup board data.

        public Form1()
        {

            Point top = new Point(10, 30); // setting up the form size
            Point bottom = new Point(10, 170);
            InitializeComponent();

            boardData = this.MakeBoardArray();  // gets the values of board size

            try
            {
                _gameboardGui = new GameboardImageArray(this, boardData, top, bottom, 3, imagepaths); // sets up the board on top of the form
                _gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameboardGui.UpdateBoardGui(boardData);

                pictureBoxBlkToMove.Visible = true;
                pictureBoxWhtToMove.Visible = false;

                CheckNumPieces();                                     // sets the GUI by checking the pieces held by each player
                lblBlack.Text = $"Counters: {numOfBlack}";
                lblWhite.Text = $"Counters: {numOfWhite}";            // displays number of pieces held by each player

                lblGameMoves.Text = $"Game Moves: {gameMoves}";

            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Board Size Too Small! ");  // checks for excpetion
                this.Close();
            }
            AddOutline();
        }
        // CLick Listener 


        private bool IsAnyMoveValid(int rowClicked, int columnClicked, int player)
        {
            if (boardData[rowClicked, columnClicked] != 0)
            {
                return false; // If the tile is not empty, it's not a valid move
            }

            int opponent = 3 - player; // Opponent's color

            (int x, int y)[] OFFSETS =
            {
                (1, 0), (1, 1),
                (0, 1), (-1, 0),               // offsets for the algorithm to check if a valid move is there
                (0, -1), (1, -1),
                (-1, 1), (-1, -1)              // N, S, E W, NE, SE, NW, SW
            };

            bool isAnyMovePossible = false;

            foreach (var offset in OFFSETS)   // loopo through offset values and check
            {
                int changeInRow = offset.x;
                int changeInCol = offset.y;

                int row = rowClicked + changeInRow;
                int col = columnClicked + changeInCol;

                bool validDirection = false;   // initial bool is false, must be proven to be true, not other way around

                while (row >= 0 && row < rows && col >= 0 && col < columns)
                {
                    if (boardData[row, col] == player)   
                    {
                        validDirection = true;
                        break;
                    }
                    else if (boardData[row, col] == 0 || boardData[row, col] == 3) // 3 represents valid moves
                    {
                        break;
                    }

                    row += changeInRow;
                    col += changeInCol;
                }

                if (validDirection)
                {
                    // Check if the opponent's counters can be flanked

                    row -= changeInRow;
                    col -= changeInCol;

                    while (row != rowClicked || col != columnClicked)
                    {
                        if (boardData[row, col] == opponent)
                        {
                            isAnyMovePossible = true;
                            break;
                        }

                        row -= changeInRow;
                        col -= changeInCol;
                    }

                    if (isAnyMovePossible)
                    {
                        break; // Break out if any direction is valid
                    }
                }
            }

            return isAnyMovePossible;
        }

        public void GameEnded()
        {
            bool hasLegalMoves = false;

            // Check for any empty spaces and legal moves
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (_gameboardGui.GetTile(row, col).ImageLocation.EndsWith("3.PNG"))    // set counter as a valid move
                    {
                        hasLegalMoves = true;    // game not to be ended
                        break;
                    }
                }
            }

            // Game end conditions
            if (hasLegalMoves)
            {
                return;
            }
            else
            {
                // Calculate the number of black and white pieces
                CheckNumPieces();

                if (numOfBlack > numOfWhite)
                {
                    winner = "Black";
                    MessageBox.Show("Black Wins! with " + numOfBlack + " counters!");
                    if (speak)
                    {
                        synthesizer.Speak("Black Wins! with " + numOfBlack + " counters!");   // win dialogue / message to be displayed
                    }
                }
                else if (numOfBlack < numOfWhite)
                {
                    winner = "White";
                    MessageBox.Show("White Wins! with " + numOfWhite + " counters!");
                }
                else
                {
                    winner = "Draw";
                    MessageBox.Show("Draw!");
                }
            }
        }


        public void AddOutline()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (IsAnyMoveValid(row, col, player))
                    {
                        _gameboardGui.SetTile(row, col, 3.ToString());   // loiops through board, when a move is 'valid' it sets it as the appropriate image
                    }
                }
            }
        }

        public void FlipValidCounters(int row, int col, int player)
        {
            (int x, int y)[] OFFSETS =
            {
                (1, 0), (1, 1),            // offsets same as IsAnyMoveValid
                (0, 1), (-1, 0),
                (0, -1), (1, -1),
                (-1, 1), (-1, -1)
            };

            int opponent = 3 - player; // Assuming 1 for black, 2 for white

            foreach (var offset in OFFSETS)
            {
                int changeInRow = offset.x;
                int changeInCol = offset.y;

                int r = row + changeInRow;
                int c = col + changeInCol;

                bool flipped = false;

                while (r >= 0 && r < rows && c >= 0 && c < columns && boardData[r, c] == opponent)
                {
                    r += changeInRow;
                    c += changeInCol;
                    flipped = true;
                }

                if (flipped && r >= 0 && r < rows && c >= 0 && c < columns && boardData[r, c] == player)  // conditional for flip
                {
                    // Flip the opponent's tiles
                    int flipR = row + changeInRow;
                    int flipC = col + changeInCol;

                    while (flipR != r || flipC != c)
                    {
                        boardData[flipR, flipC] = player;
                        flipR += changeInRow;
                        flipC += changeInCol;
                    }
                }
            }
        }

        public void ClearPreviousLegalMoves()
        {
            for (int row = 0; row < 8; row++)  // loops through the board
            {
                for (int col = 0; col < 8; col++)
                {
                    if (boardData[row, col] == 3)
                    {
                        _gameboardGui.SetTile(row, col, 0.ToString());  // removes all legal moves from the board once a move has been made
                    }
                }                                                       // so opponants legal moves are not still shown as legal moves
            }
        }

        public void CheckNumPieces()   // loops through the board and checks the pieces that are black (1.png) and whiye (2.png)
        {
            numOfBlack = 0;
            numOfWhite = 0;                    // sets to 0 so it does not keep adding on each click
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (_gameboardGui.GetTile(row, col).ImageLocation.EndsWith("1.PNG"))
                    {
                        numOfBlack += 1;
                    }
                    if (_gameboardGui.GetTile(row, col).ImageLocation.EndsWith("2.PNG"))
                    {
                        numOfWhite += 1;
                    }
                }
            }
        }

        public void GameTileClicked(object sender, EventArgs e)
        {
            if (speak)
            {
               // TODO stop it
            }
            int RowClicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);    //gets the tile clicked

            if (richTextBoxPlayerTwo.Text == "")
            {
                richTextBoxPlayerTwo.Text = "Player #2";
                playerOneName = richTextBoxPlayerTwo.Text;   // if no name is selected it defualts to 'Player #1' or 'Player #2'
            }
            if (richTextBoxPlayerOne.Text == "")
            {
                richTextBoxPlayerOne.Text = "Player #1";
                playerTwoName = richTextBoxPlayerOne.Text;
            }

            richTextBoxPlayerTwo.Enabled = false;
            richTextBoxPlayerOne.Enabled = false;

            // Clear previous legal moves
            ClearPreviousLegalMoves();

            // Check if the clicked tile is a valid move for the current player
            if (IsAnyMoveValid(RowClicked, ColumnClicked, player))
            { 
                gameMoves += 1;

                // Update the board with the player's move
                boardData[RowClicked, ColumnClicked] = player;

                // Flip counters
                FlipValidCounters(RowClicked, ColumnClicked, player);

                _gameboardGui.UpdateBoardGui(boardData);

                // Switch players
                player = 3 - player; // 2 for black, 1 for white

                if (onOff % 2 == 0)      // only can be displayed when game info panel has not beem hidden 
                {
                    if (player == 1)
                    {
                        pictureBoxBlkToMove.Visible = true;
                        pictureBoxWhtToMove.Visible = false;
                    }
                    if (player == 2)                            // Add outlines for valid moves for the next player
                    {
                        pictureBoxWhtToMove.Visible = true;
                        pictureBoxBlkToMove.Visible = false;
                    }
                }

                CheckNumPieces();
                lblBlack.Text = $"Counters: {numOfBlack}";
                lblWhite.Text = $"Counters: {numOfWhite}";

                lblGameMoves.Text = $"Game Moves: {gameMoves}";

                if (speak)
                {
                    SpeakPlayer();
                }
            }
            AddOutline();
            GameEnded();
        }

        // Method triggered when the user clicks a "Load Game" button
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            GameState loadSavedGameState = LoadGameState();
            boardData = loadSavedGameState.boardData;
            playerOneName = loadSavedGameState.playerOneName;
            playerTwoName = loadSavedGameState.playerTwoName;
            numOfBlack = loadSavedGameState.numOfBlack;  
            numOfWhite = loadSavedGameState.numOfWhite;
            player = loadSavedGameState.player;
            gameMoves = loadSavedGameState.gameMoves;

            _gameboardGui.UpdateBoardGui(boardData);
            AddOutline();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boardData = new int[rows, columns];

            boardData[3, 3] = 2;
            boardData[4, 4] = 2;         // initialise new game board with needed variables
            boardData[3, 4] = 1;
            boardData[4, 3] = 1;

            gameMoves = 0;
            numOfBlack = 2;
            numOfWhite = 2;
            player = 1;

            winner = string.Empty; // resets winner string

            _gameboardGui.UpdateBoardGui(boardData);   // sync board and array

            lblGameMoves.Text = $"Game Moves: {gameMoves}";

            CheckNumPieces();

            lblBlack.Text = $"Counters: {numOfBlack}";
            lblWhite.Text = $"Counters: {numOfWhite}";
            lblGameMoves.Text = $"Game Moves: {gameMoves}";       // all data here is reset to origional values to keep info accurate

            richTextBoxPlayerTwo.Text = string.Empty;
            richTextBoxPlayerOne.Text = string.Empty;

            richTextBoxPlayerTwo.Enabled = true;
            richTextBoxPlayerOne.Enabled = true;

            AddOutline();  //need to be added again when new game initialises
        }

        private void helpPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 helpForm = new Form2();
            helpForm.Show();

        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Assume you have a gameState object representing the current state
            GameState gameState = new GameState(boardData, playerOneName, playerTwoName, numOfBlack, numOfWhite, player, gameMoves, gameName);
            SaveGameForm save = new SaveGameForm(gameState);
            save.Show();
        }

        private GameState LoadGameState()
        {

            string filePath = "GameData/Game_Data.JSON";

            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(filePath));

            foreach (GameState gameState in data.Games)
            {
                //Add to list box
            }
            return data.Games[0];


    //        return data.Games[] //use the index from the listbox 

            
        
        }
        private void HideGameInfoPanelProperties()
        {
            pictureBoxBlkToMove.Visible = false;
            pictureBoxWhtToMove.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;            // disables visibility of each icon
            lblGameMoves.Visible = false;
            lblBlack.Visible = false;               // need to do this because of the way the form is divided to stop the squares taking up the whole screen
            lblWhite.Visible = false;
            richTextBoxPlayerTwo.Visible = false;
            richTextBoxPlayerOne.Visible = false;

        }
        private void ShowGameInfoPanelProperties()
        {
            pictureBoxBlkToMove.Visible = true;
            pictureBoxWhtToMove.Visible = true;
            pictureBox1.Visible = true;             // enables visibility when 'show' clicked again
            pictureBox2.Visible = true;
            lblGameMoves.Visible = true;
            lblWhite.Visible = true;
            richTextBoxPlayerTwo.Visible = true;
            lblBlack.Visible = true;
            richTextBoxPlayerOne.Visible = true;

        }

        private void hideGameInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onOff += 1;
            if (onOff % 2 != 0)             // when clicked / unclicked it enables / disables the game information panel function 
            {
                hideGameInfoToolStripMenuItem.Text = "Hide Game Info";
                HideGameInfoPanelProperties();
            }
            else
            {
                hideGameInfoToolStripMenuItem.Text = "Show Game Info";   // changes the button text to fit the action
                ShowGameInfoPanelProperties();
            }
        }

        private void SpeakPlayer()
        {
            string speakPlayerTurn;

            if (player == 1)
            {
                speakPlayerTurn = $"{richTextBoxPlayerOne.Text} to move";  // speak dialogue set
            }  
            else
            {
                speakPlayerTurn = $"{richTextBoxPlayerTwo.Text} to move";
            }

            synthesizer.SpeakAsync(speakPlayerTurn);  // speak triggered
        }

        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speakOnOff++;
            if (speakOnOff % 2 != 0)   // when clicked / unclicked it enables / disables the speak function
            {
                speak = true;
            }
            else
            {
                speak = false;
            }
        }
    }
}
