using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2D2
{
    class CommandLine
    {
        // unecessary as an array but leftover from ideas, now used in a string below
        // private static readonly string[] Commands = { "LAND", "MOVE", "LEFT", "RIGHT", "REPORT" };

        private static void LogCommandError(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err);
        }

        public static void ReportLocation(Directions direction, Grid grid)
        {
            if (grid.HasLanded)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("R2D2 is facing {0} at:", Enum.GetName(typeof(Directions), direction));
                Console.WriteLine("| X: {0} | Y: {1} |", grid.CharacterPosition.X, grid.CharacterPosition.Y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Obi Wan is at:");
                Console.WriteLine("| X: {0} | Y: {1} |", grid.ObiWanPosition.X, grid.ObiWanPosition.Y);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("*beepboop* Still floating in outer space. Type LAND to land.");
            }
        }

        public static void AcceptCommand(Grid grid, Character r2)
        {
            Console.ForegroundColor = ConsoleColor.White;

            var cmd = Console.ReadLine();
            var cmdArr = cmd.Split(' ');

            switch (cmdArr[0])
            {
                case "LAND":
                    if (!grid.HasLanded) {
                        grid.Land();
                        ReportLocation(r2.Direction, grid);
                    }
                    break;
                case "REPORT":
                    ReportLocation(r2.Direction, grid);
                    break;
                case "LEFT":
                case "RIGHT":
                    r2.Turn(cmdArr[0]);
                    break;
                case "MOVE":
                    try
                    {
                        var amount = Convert.ToInt32(cmdArr[1]);
                        var updated = grid.UpdateCharacterPosition(amount, r2.Direction);
                        if (!updated)
                        {
                            LogCommandError("*beepbeepboop* That would make me fall off");
                        }
                    } catch
                    {
                        LogCommandError("I didn't understand how far you want to move *beepboop*");
                    }
                    break;
                default:
                    LogCommandError("Please enter a valid command like: 'LAND', 'MOVE', 'LEFT', 'RIGHT', 'REPORT'");
                    break;
            }
        }

        public static void LogWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** Congratulations!  You helped R2D2 find Obi Wan! ***");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
