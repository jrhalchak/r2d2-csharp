using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2D2
{
    class Character
    {
        public Directions Direction;

        public Character()
        {
            Array directions = Enum.GetValues(typeof(Directions));
            Random random = new Random();

            // randomly select a direction
            Direction = (Directions)directions.GetValue(random.Next(directions.Length));
        }

        public void Turn(string dir)
        {
            var isLeft = dir == "LEFT";
            
            switch (Direction)
            {
                case Directions.North:
                    Direction = isLeft ? Directions.West : Directions.East;
                    break;
                case Directions.East:
                    Direction = isLeft ? Directions.North : Directions.South;
                    break;
                case Directions.South:
                    Direction = isLeft ? Directions.East : Directions.West;
                    break;
                case Directions.West:
                    Direction = isLeft ? Directions.South : Directions.North;
                    break;
                default:
                    break;
            }

        }
    }
}
