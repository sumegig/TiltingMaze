using TiltingMaze.Model;
using TiltingMaze.Persistence;

namespace TiltingMaze
{
    public partial class Form1 : Form
    {
        #region Fileds
        private GameModel _model;
        private PictureBox[,] _gridControls = null!;

        #endregion

        public Form1()
        {
            InitializeComponent();

            IMazeDataAccess dataAccess = new MazeFileDataAccess();
            _model = new GameModel(dataAccess);

            _model.GameCreated += Model_GameCreated;
            _model.FieldChanged += Model_FieldChanged;
            _model.TimeAdvanced += Model_TimeAdvanced;
            _model.GameOver += Model_GameOver;

            _ = _model.NewGameAsync(1);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_model.IsGameOver) { return; }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    _model.Tilt(Direction.Up);
                    break;

                case Keys.Down:
                    _model.Tilt(Direction.Down);
                    break;

                case Keys.Left:
                    _model.Tilt(Direction.Left);
                    break;

                case Keys.Right:
                    _model.Tilt(Direction.Right);
                    break;
            }
            stepLabel.Text = $"Steps: {_model.TiltCount}";
        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _model.Undo();
            stepLabel.Text = $"Steps: {_model.TiltCount}";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //model esemenyei

        private void Model_GameCreated(object? sender, EventArgs e)
        {
            BuildTable();
            stepLabel.Text = $"Steps: {_model.TiltCount}";
        }

        private void Model_TimeAdvanced(object? sender, int e)
        {
            BeginInvoke(new Action(() => { timeLabel.Text = $"Time: {e}s"; }));
        }

        private void Model_FieldChanged(object? sender, (int x, int y) e)
        {
            UpdateTileAppearance(e.x, e.y);
        }

        private void Model_GameOver(object? sender, bool isWon)
        {
            string msg = isWon ? $"nyertel: {_model.TiltCount} lepesbol" : "vesztettel";
            MessageBox.Show(msg, "Game Over", MessageBoxButtons.OK, isWon ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        //palyaepites

        private void BuildTable()
        {
            int size = _model.BoardSize;

            gridPanel.SuspendLayout();
            gridPanel.Controls.Clear();
            gridPanel.RowStyles.Clear();
            gridPanel.ColumnStyles.Clear();

            gridPanel.RowCount = size;
            gridPanel.ColumnCount = size;
            _gridControls = new PictureBox[size, size];

            for (int i = 0; i < size; i++)
            {
                gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
                gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    gridPanel.Controls.Add(pb, j, i);
                    _gridControls[i, j] = pb;
                    UpdateTileAppearance(i, j);
                }
            }
            gridPanel.ResumeLayout();
        }

        private void UpdateTileAppearance(int x, int y)
        {
            PictureBox pb = _gridControls[x, y];
            TileType tile = _model[x, y];

            Color tileColor = tile switch
            {
                TileType.Wall => Color.DarkGray,
                TileType.RedHole => Color.DarkRed,
                TileType.BlueHole => Color.DarkBlue,
                _ => Color.White
            };

            /*
            if (pb.Image != null)
            {
                pb.Image.Dispose();
            }
            pb.Image = null;

            foreach (var ball in _model.Balls)
            {
                if (ball.IsActive && ball.X == x && ball.Y == y)
                {
                    Bitmap bmp = new Bitmap(200, 200);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        Brush brush = ball.Color == BallColor.Red ? Brushes.Red : Brushes.Blue;
                        g.FillEllipse(brush, 10, 10, 180, 180);
                    }
                    pb.Image = bmp;
                    break;
                }
            }
            */

            foreach (var ball in _model.Balls)
            {
                if (ball.IsActive && ball.X == x && ball.Y == y)
                {
                    tileColor = ball.Color == BallColor.Red ? Color.Red : Color.Blue;
                    break;
                }
            }
            pb.BackColor = tileColor;
            pb.Image = null;

        }
        private async void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           await _model.NewGameAsync(1);
        }

        private async void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _model.NewGameAsync(2);
        }

        private async void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _model.NewGameAsync(3);
        }
    }
}
