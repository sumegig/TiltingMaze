using System;
using System.Collections.Generic;
using System.Text;

namespace TiltingMaze.Persistence
{

    public class MazeFileDataAccess : IMazeDataAccess
    {
        private readonly string _highScoreFilePath = "highscores.txt";

        /*
            0 = padlo
            1 = fal
            2 = piros lyuk
            3 = kek lyuk
            4 = piros golyo a padlon
            5 = kek golyo a padlon
        */
        public async Task<(int size, int[,] gridData)> LoadLevelAsync(int levelIndex)
        {
            // pl "level1.txt"
            string filePath = $"level{levelIndex}.txt";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Level file not found: {filePath}");
            }

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return await LoadLevelAsync(stream);
        }

        public async Task<(int size, int[,] gridData)> LoadLevelAsync(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
            var lines = new List<string>();

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line);
                }
            }

            if (lines.Count == 0)
            {
                throw new InvalidDataException("Level data is empty.");
            }

            //elso sor a tabla merete
            int size = int.Parse(lines[0]);
            int[,] gridData = new int[size, size];

            //maradek szoveg a tabla felepitese
            for (int i = 0; i < size; i++)
            {
                string[] darab = lines[i + 1].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size; j++)
                {
                    gridData[i, j] = int.Parse(darab[j]);
                }
            }

            return (size, gridData);
        }

        public async Task<Dictionary<int, int>> LoadHighScoreAsync()
        {
            //kulcs a szint, ertek a lepesek
            var highScores = new Dictionary<int, int>();

            if (!File.Exists(_highScoreFilePath)) //ha nincs fajl, pl korrupt vagy elso jatek
            {
                return highScores;
            }

            using FileStream stream = new FileStream(_highScoreFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return await LoadHighScoreAsync(stream);
        }

        public async Task<Dictionary<int, int>> LoadHighScoreAsync(Stream stream)
        {
            var highScores = new Dictionary<int, int>();
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] darabok = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //"kulcs ertek"
                if (darabok.Length >= 2 &&
                    int.TryParse(darabok[0], out int level) &&
                    int.TryParse(darabok[1], out int steps))
                {
                    highScores[level] = steps;
                }
            }

            return highScores;
        }

        public async Task SaveHighScoreAsync(int levelIndex, int steps)
        {
            var currentScores = await LoadHighScoreAsync();

            if (!currentScores.ContainsKey(levelIndex) ||
                currentScores[levelIndex] > steps)
            {
                currentScores[levelIndex] = steps;
            }

            using FileStream stream = new FileStream(_highScoreFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await SaveHighScoreAsync(stream, currentScores);
        }

        public async Task SaveHighScoreAsync(Stream stream, Dictionary<int, int> scores)
        {
            using var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
            foreach (var kvp in scores)
            {
                await writer.WriteLineAsync($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}
