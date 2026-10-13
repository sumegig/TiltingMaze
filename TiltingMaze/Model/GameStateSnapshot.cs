using System;
using System.Collections.Generic;
using System.Text;

namespace TiltingMaze.Model
{
    public class GameStateSnapshot
    {
        private List<Ball> BallState { get;  set; }
        private int TiltCount { get; set; }
        private int GameTime { get; set; }  

        public GameStateSnapshot(IEnumerable<Ball> balls, int tilts, int time) 
        {
            BallState = balls.Select(b => b.Clone()).ToList();
            TiltCount = tilts;
            GameTime = time;
        }

        public List<Ball> GetBallState()
        {
            return BallState;
        }

        public int GetTiltCount()
        {
            return TiltCount;
        }

        public int GetGameTime()
        {
            return GameTime;
        }

    }
}
