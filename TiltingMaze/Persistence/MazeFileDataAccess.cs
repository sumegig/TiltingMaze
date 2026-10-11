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

            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Level file not found: {filePath}");
            }

            string[] lines = await File.ReadAllLinesAsync(filePath);

            if(lines.Length == 0)
            {
                throw new InvalidDataException($"Level file is empty: {filePath}");
            }

            //elso sor a tabla merete
            int size = int.Parse(lines[0]);
            int[,] gridData = new int[size, size];

            //maradek szoveg a tabla felepitese
            for(int i = 0; i < size; i++)
            {
                string[] darab = lines[i+1].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                
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

            string[] sorok = await File.ReadAllLinesAsync(_highScoreFilePath);

            foreach (var s in sorok)
            {
                string[] darabok = await File.ReadAllLinesAsync(_highScoreFilePath);
                
                //"kulcs ertek"
                if (darabok.Length == 0 &&
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

            if(!currentScores.ContainsKey(levelIndex) ||
                currentScores[levelIndex] > steps)
            {
                currentScores[levelIndex] = steps;
            }

            //felulirni az egesz fajlt uj ertekekkel
            using (StreamWriter writer = new StreamWriter(_highScoreFilePath, false)) //false = overwrite
            {
                foreach (var kvp in currentScores)
                {
                    await writer.WriteLineAsync($"{kvp.Key} {kvp.Value}");
                }
            }
        }
    }
}
