using GameboardGUI;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        const int rows = 8, columns = 8;
        int gameMoves = 0;
        GameboardImageArray _gameboardGui;
        string imagepaths = "C:\\Users\\CallumCunningham\\source\\repos\\Oneillo_2\\resources\\";
        bool black = true;
        string player;
        int[,] boardData;
        // On start setup board data.
        private int[,] MakeBoardArray()
        {
            int[,] StartArray = new int[rows, columns];

            StartArray[3, 3] = 1;
            StartArray[4, 4] = 1;
            StartArray[3, 4] = 2;
            StartArray[4, 3] = 2;
            return StartArray;
        }

        public Form1()
        {

            Point top = new Point(10, 10); // setting up the form size
            Point bottom = new Point(10, 10);
            InitializeComponent();
            boardData = this.MakeBoardArray();  // gets the values of board size

            try
            {
                _gameboardGui = new GameboardImageArray(this, boardData, top, bottom, 0, imagepaths); // sets up the board on top of the form
                _gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameboardGui.UpdateBoardGui(boardData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Board Size Too Small! ");  // checks for excpetion
                this.Close();
            }

        }
        // CLick Listener 
        public void GameTileClicked(object sender, EventArgs e)
        {
            gameMoves++;
            int RowCLicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);
            if (boardData[RowCLicked, ColumnClicked] == 0)
            {
                if (gameMoves % 2 == 0)
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 2.ToString());
                    player = "Black";
                }
                else
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 1.ToString());
                    player = "Orange";

                }
            }
        }
        private bool PossibleMoves(int row, int col, string player)
        {
            return true;        }
    }
}