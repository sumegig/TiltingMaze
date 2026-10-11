using System;
using System.Collections.Generic;
using System.Text;

namespace TiltingMaze.Model
{
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public BallColor Color { get; set; }
        public bool IsActive { get; set; }

        public Ball(int x, int y, BallColor color, bool isActive)
        {
            X = x;
            Y = y;
            Color = color;
            IsActive = isActive;
        }

        public void MoveTo(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public Ball Clone()
        {
            return new Ball(X, Y, Color, IsActive);
        }
    }
}
