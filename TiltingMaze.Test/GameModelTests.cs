using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using TiltingMaze.Model;

namespace TiltingMaze.Test
{
    [TestClass]
    public class GameModelTests
    {
        private GameModel _model = null!;
        private MockMazeDataAccess _mockDataAccess = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new MockMazeDataAccess();
            _model = new GameModel(_mockDataAccess);
        }

        [TestMethod]
        public async Task NewGameAsync_ShouldInitializeCorrectly()
        {

            await _model.NewGameAsync(1);

            Assert.AreEqual(3, _model.BoardSize);
            Assert.AreEqual(0, _model.GameTime);
            Assert.AreEqual(0, _model.TiltCount);
            Assert.IsFalse(_model.IsGameOver);
            Assert.HasCount(1, _model.Balls);
            Assert.AreEqual(BallColor.Red, _model.Balls[0].Color);
        }

        [TestMethod]
        public async Task AdvanceTime_ShouldIncrementTimeAndFireEvent()
        {

            await _model.NewGameAsync(1);
            int eventFiredWithTime = -1;
            _model.TimeAdvanced += (sender, time) => eventFiredWithTime = time;

            _model.AdvanceTime();
            _model.AdvanceTime();

            Assert.AreEqual(2, _model.GameTime);
            Assert.AreEqual(2, eventFiredWithTime);
        }

        [TestMethod]
        public async Task Tilt_IntoCorrectHole_ShouldWinGame()
        {

            await _model.NewGameAsync(1); // Level 1 
            bool isWon = false;
            bool gameOverFired = false;

            _model.GameOver += (sender, won) =>
            {
                gameOverFired = true;
                isWon = won;
            };

            _model.Tilt(Direction.Right);

            Assert.IsTrue(gameOverFired);
            Assert.IsTrue(isWon);
            Assert.IsTrue(_model.IsGameOver);
        }

        [TestMethod]
        public async Task Tilt_IntoWrongHole_ShouldLoseGame()
        {

            await _model.NewGameAsync(2); // Level2
            bool isWon = true;
            bool gameOverFired = false;

            _model.GameOver += (sender, won) =>
            {
                gameOverFired = true;
                isWon = won;
            };

            _model.Tilt(Direction.Right);

            Assert.IsTrue(gameOverFired);
            Assert.IsFalse(isWon);
            Assert.IsTrue(_model.IsGameOver);
        }

        [TestMethod]
        public async Task Undo_ShouldRestorePreviousStateAndIncrementSteps()
        {
            await _model.NewGameAsync(3); // 4x4 level
            _model.AdvanceTime(); // time = 1

            var redBall = _model.Balls.First(b => b.Color == BallColor.Red);
            int originalX = redBall.X;
            int originalY = redBall.Y;

            _model.Tilt(Direction.Down);

            Assert.AreEqual(2, redBall.X);
            Assert.AreEqual(1, _model.TiltCount);


            _model.Undo();

            var restoredRedBall = _model.Balls.First(b => b.Color == BallColor.Red);
            Assert.AreEqual(originalX, restoredRedBall.X);
            Assert.AreEqual(originalY, restoredRedBall.Y);

            Assert.AreEqual(2, _model.TiltCount);
            Assert.AreEqual(1, _model.GameTime);
        }
    }
}