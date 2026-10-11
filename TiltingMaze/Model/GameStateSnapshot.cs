using System;
using System.Collections.Generic;
using System.Text;

namespace TiltingMaze.Model
{
    public class GameStateSnapshot
    {
        public List<Ball> BallState;
        public int TiltCount;
        public int GameTime;

        public GameStateSnapshot(IEnumerable<Ball> balls, int tilts, int time) 
        {
            BallState = balls.Select(b => b.Clone()).ToList();
            TiltCount = tilts;
            GameTime = time;
        }
    }
}
