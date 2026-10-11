using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using TiltingMaze.Persistence;

namespace TiltingMaze.Model
{
    public class GameModel
    {
        #region Fields
        private IMazeDataAccess _dataAccess;
        private int _boardSize;
        private TileType[,] _board;
        private List<Ball> _balls;
        private Stack<GameStateSnapshot> _undoStack;
        private int _currentLevelIndex;

        private System.Timers.Timer _timer;

        private int _gameTime;
        private int _tiltCount;
        private bool _isGameOver;

        #endregion

        #region Properties
        public int BoardSize { get { return _boardSize; } }

        public int GameTime { get { return _gameTime; } }
        public int TiltCount { get { return _tiltCount; } }
        public bool IsGameOver { get { return _isGameOver; } }

        public TileType this[int row, int col] { get { return _board[row, col]; } }
        public IReadOnlyList<Ball> Balls { get { return _balls.AsReadOnly(); } }

        #endregion

        #region Events
        public event EventHandler? GameCreated;
        public event EventHandler<(bool isWon, bool isNewRecord)>? GameOver;
        public event EventHandler<int>? TimeAdvanced;
        public event EventHandler<(int, int)>? FieldChanged;

        #endregion

        #region Constructors
        public GameModel(IMazeDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            _undoStack = new Stack<GameStateSnapshot>();
            _balls = new List<Ball>();
            _board = new TileType[0, 0];

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
        }

        #endregion

        #region Public methods
        public async Task NewGameAsync(int levelIndex)
        {
            _currentLevelIndex = levelIndex;
            // TODO: Call _dataAccess to load the level -- kesz
            // TODO: Reset _gameTime, _tiltCount, _isGameOver, _undoStack -- kesz

            _timer.Stop();

            var levelData = await _dataAccess.LoadLevelAsync(levelIndex);

            _boardSize = levelData.size;
            _board = new TileType[_boardSize, _boardSize];

            _balls.Clear();
            _undoStack.Clear();
            _gameTime = 0;
            _tiltCount = 0;
            _isGameOver = false;

            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    int tileCode = levelData.gridData[i, j];

                    switch (tileCode)
                    {
                        case 1:
                            _board[i, j] = TileType.Wall;
                            break;

                        case 2:
                            _board[i, j] = TileType.RedHole;
                            break;

                        case 3:
                            _board[i, j] = TileType.BlueHole;
                            break;

                        case 4:
                            _board[i, j] = TileType.Floor;
                            _balls.Add(new Ball(i, j, BallColor.Red, true));
                            break;

                        case 5:
                            _board[i, j] = TileType.Floor;
                            _balls.Add(new Ball(i, j, BallColor.Blue, true));
                            break;

                        default:
                            _board[i, j] = TileType.Floor;
                            break;
                    }
                }
            }
            //uzenet viewnak hogy kesz az uj tabla
            GameCreated?.Invoke(this, EventArgs.Empty);

            _timer.Start();
            TimeAdvanced?.Invoke(this, _gameTime); // visszaallitja 0ra
        }

        public void Pause()
        {
            if (!_isGameOver) _timer.Stop();
        }

        public void Resume()
        {
            if (!_isGameOver) _timer.Start();
        }


        public void Tilt(Direction direction)
        {
            if (_isGameOver)
                return;

            // TODO: Create a snapshot and push it to _undoStack -- kesz
            // TODO: Increment _tiltCount -- kesz
            // TODO: Implement rolling logic -- kesz

            //snapshotba mentes
            _undoStack.Push(new GameStateSnapshot(_balls, _tiltCount, _gameTime));

            _tiltCount++;

            var sortedBalls = new List<Ball>(_balls);
            switch (direction)
            {
                case Direction.Up:
                    sortedBalls.Sort((a, b) => a.X.CompareTo(b.X));
                    break;

                case Direction.Down:
                    sortedBalls.Sort((a, b) => b.X.CompareTo(a.X));
                    break;

                case Direction.Left:
                    sortedBalls.Sort((a, b) => a.Y.CompareTo(b.Y));
                    break;

                case Direction.Right:
                    sortedBalls.Sort((a, b) => b.Y.CompareTo(a.Y));
                    break;
            }

            int dx = 0, dy = 0;

            switch (direction)
            {
                case Direction.Up: dx = -1; break;

                case Direction.Down: dx = 1; break;

                case Direction.Left: dy = -1; break;

                case Direction.Right: dy = 1; break;
            }

            foreach (var ball in sortedBalls)
            {
                if(!ball.IsActive) continue;

                int oldX = ball.X;
                int oldY = ball.Y;

                while (true)
                {
                    int nextX = ball.X + dx;
                    int nextY = ball.Y + dy;

                    if(nextX < 0 || nextX >= _boardSize || nextY < 0 || nextY >= _boardSize)
                        break;

                    if (_board[nextX, nextY] == TileType.Wall)
                        break;

                    bool isBlocked = false;

                    foreach(var otherBall in _balls)
                    {
                        if(otherBall.IsActive 
                            && otherBall != ball 
                            && otherBall.X == nextX
                            && otherBall.Y == nextY)
                        {
                            isBlocked = true;
                            break;
                        }
                    }
                    if (isBlocked)
                        break;

                    ball.MoveTo(nextX, nextY);

                    TileType currentTile = _board[nextX, nextY];

                    
                    if (currentTile == TileType.RedHole || currentTile == TileType.BlueHole)
                    {
                        if ((currentTile == TileType.RedHole && ball.Color == BallColor.Red) ||
                            (currentTile == TileType.BlueHole && ball.Color == BallColor.Blue))
                        {
                            // jo helyre esett be 
                            ball.IsActive = false;
                        }
                        else
                        {
                            // rossz helyre esett
                            ball.IsActive = false;
                            OnFieldChanged(oldX, oldY);
                            OnFieldChanged(ball.X, ball.Y);
                            OnGameOver(false); // isWon = false
                            return;
                        }
                        break; 
                    }
                }

                if(oldX != ball.X || oldY != ball.Y)
                {
                    OnFieldChanged(oldX, oldY);// toroljuk a labdat
                    OnFieldChanged(ball.X, ball.Y); // uj helyere rajzoljuk
                }
            }

            CheckWinCondition();

        }

        public void AdvanceTime()
        {
            if (IsGameOver)
                return;

            _gameTime++;
            TimeAdvanced?.Invoke(this, _gameTime);

        }
        public void Undo()
        {
            if (_undoStack.Count == 0 || _isGameOver)
                return;

            // TODO: Pop from _undoStack and restore state
            // Note: Undo also counts as a step according to the requirements!

            var prevState = _undoStack.Pop();

            //leszedjuk az osszes mostani labdat
            var positionsToClear = new List<(int X, int Y)>();
            foreach (var ball in _balls)
            {
                if (ball.IsActive)
                {
                    positionsToClear.Add((ball.X, ball.Y));
                }
            }

            //vissza a regi
            _balls = prevState.BallState;

            _gameTime = prevState.GameTime;
            TimeAdvanced?.Invoke(this, _gameTime);

            _tiltCount++;

            //regi visszarajzolas
            foreach (var pos in positionsToClear)
            {
                OnFieldChanged(pos.X, pos.Y);
            }

            foreach (var ball in _balls)
            {
                if (ball.IsActive)
                {
                    OnFieldChanged(ball.X, ball.Y);
                }
            }
        }

        #endregion

        #region Private methods

        private void CheckWinCondition()
        {
            

            bool isWon = true;
            foreach (var ball in _balls)
            {
                if (ball.IsActive)
                {
                    isWon = false;
                    break;
                }
            }
            if (isWon)
            {
                OnGameOver(true);
            }
        }


        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            AdvanceTime();
        }
        #endregion

        #region Private event methods
        public async void OnGameOver(bool isWon)
        {
            _isGameOver = true;
            bool isNewRecord = false;

            if (isWon)
            {
                var highScores = await _dataAccess.LoadHighScoreAsync();

                if(!highScores.ContainsKey(_currentLevelIndex) ||_tiltCount < highScores[_currentLevelIndex])
                {
                    isNewRecord = true;
                    await _dataAccess.SaveHighScoreAsync(_currentLevelIndex, _tiltCount);
                }
            }

            GameOver?.Invoke(this, (isWon, isNewRecord));
        }
        private void OnFieldChanged(int x, int y)
        {
            FieldChanged?.Invoke(this, (x, y));
        }

        #endregion
    }
}
