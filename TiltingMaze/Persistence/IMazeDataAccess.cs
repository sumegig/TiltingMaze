using System;
using System.Collections.Generic;
using System.Text;

namespace TiltingMaze.Persistence
{
    public interface IMazeDataAccess
    {
        public Task<(int size, int[,] gridData)> LoadLevelAsync(int levelIndex);
        public Task<Dictionary<int, int>> LoadHighScoreAsync();
        public Task SaveHighScoreAsync(int levelIndex, int steps);
    }
}
