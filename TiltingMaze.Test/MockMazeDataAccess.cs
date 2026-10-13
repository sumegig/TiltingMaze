using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiltingMaze.Model;
using TiltingMaze.Persistence;

namespace TiltingMaze.Test
{
    public class MockMazeDataAccess : IMazeDataAccess
    {
        public Task<(int size, int[,] gridData)> LoadLevelAsync(int levelIndex)
        {
            int size;
            int[,] grid;

            switch (levelIndex)
            {
                case 1:
                    // Level 1: Win (3x3
                    size = 3;
                    grid = new int[,]
                    {
                        { 1, 1, 1 },
                        { 1, 4, 2 },
                        { 1, 1, 1 }
                    };
                    break;

                case 2:
                    // Level 2: Loss (3x3)
                    size = 3;
                    grid = new int[,]
                    {
                        { 1, 1, 1 },
                        { 1, 4, 3 },
                        { 1, 1, 1 }
                    };
                    break;

                case 3:
                    // Level 3: Collision, Undo(4x4)
                    size = 4;
                    grid = new int[,]
                    {
                        { 1, 1, 1, 1 },
                        { 1, 4, 5, 1 },
                        { 1, 0, 0, 1 },
                        { 1, 1, 1, 1 }
                    };
                    break;

                default:
                    throw new ArgumentException("Unknown level index for testing.");
            }

            return Task.FromResult((size, grid));
        }

        public Task<(int size, int[,] gridData)> LoadLevelAsync(Stream stream)
        {
            return Task.FromResult((0, new int[0, 0]));
        }

        public Task<Dictionary<int, int>> LoadHighScoreAsync()
        {
            return Task.FromResult(new Dictionary<int, int>());
        }

        public Task<Dictionary<int, int>> LoadHighScoreAsync(Stream stream)
        {
            return Task.FromResult(new Dictionary<int, int>());
        }

        public Task SaveHighScoreAsync(int levelIndex, int steps)
        {
            return Task.CompletedTask;
        }

        public Task SaveHighScoreAsync(Stream stream, Dictionary<int, int> scores)
        {
            return Task.CompletedTask;
        }
    }
}