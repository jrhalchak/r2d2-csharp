using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2D2
{
    class Grid
    {
        public readonly int Width = 100;
        public readonly int Height = 100;
        public readonly Position ObiWanPosition;
        public Position CharacterPosition;

        public bool HasLanded
        {
            get
            {
                return CharacterPosition != null;
            }
        }
        // win check
        public bool PositionsMatch
        {
            get {
                return HasLanded && CharacterPosition?.X == ObiWanPosition.X && CharacterPosition?.Y == ObiWanPosition.Y;
            }
        }


        public Grid()
        {
            ObiWanPosition = new Position(Width, Height);
            CharacterPosition = null;
        }

        // returns landing successful
        public void Land()
        {
            if (!HasLanded)
            {
                CharacterPosition = new Position(Width, Height);
            }
        }

        // returns bool for validation of still being on board
        public bool UpdateCharacterPosition(int amount, Directions direction)
        {
            var x = CharacterPosition.X;
            var y = CharacterPosition.Y;

            switch (direction)
            {
                case Directions.North:
                    y += amount;
                    break;
                case Directions.East:
                    x += amount;
                    break;
                case Directions.South:
                    y -= amount;
                    break;
                case Directions.West:
                    x -= amount;
                    break;
                default:
                    break;
            }

            if (x > Width || x < 0 || y > Height || y < 0)
            {
                return false;
            }

            CharacterPosition.UpdatePosition(x, y);
            return true;
        }
    }
}
