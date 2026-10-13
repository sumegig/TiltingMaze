using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TiltingMaze.Persistence
{
    public interface IMazeDataAccess
    {
        public Task<(int size, int[,] gridData)> LoadLevelAsync(int levelIndex);
        public Task<(int size, int[,] gridData)> LoadLevelAsync(Stream stream);
        public Task<Dictionary<int, int>> LoadHighScoreAsync();
        public Task<Dictionary<int, int>> LoadHighScoreAsync(Stream stream);
        public Task SaveHighScoreAsync(int levelIndex, int steps);
        public Task SaveHighScoreAsync(Stream stream, Dictionary<int, int> scores);
    }
}
