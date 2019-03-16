using System;

namespace R2D2
{
    class Position
    {
        private int _x;
        private int _y;
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }

        // shared static instance so random numbers are different
        private static readonly Random Random = new Random();

        public Position(int maxWidth, int maxHeight)
        {
            var rand = new Random();

            _x = Random.Next(0, maxWidth);
            _y = Random.Next(0, maxHeight);
        }

        public void UpdatePosition(int nextX, int nextY)
        {
            _x = nextX;
            _y = nextY;
        }
    }
}
