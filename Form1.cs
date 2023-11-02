using GameboardGUI;
namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        const int rows = 8, columns = 8;

        GameboardImageArray _gameboardGui;
        string imagepaths = "C:\\Users\\CallumCunningham\\source\\repos\\Oneillo_2\\resources\\";

        int[,] boardData;
        public Form1()
        {

            Point top = new Point(10, 10);
            Point bottom = new Point(10, 10);
            InitializeComponent();
            boardData = this.MakeBoardArray();

            try
            {
                _gameboardGui = new GameboardImageArray(this, boardData, top, bottom, 0, imagepaths);
                _gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameboardGui.UpdateBoardGui(boardData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Board Size Too Small! ");
                this.Close();
            }

        }

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

        // CLick Listener 
        public void GameTileClicked(object sender, EventArgs e)
        {
            int RowCLicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);

            _gameboardGui.SetTile(RowCLicked, ColumnClicked, 1.ToString());
        }

    }
}