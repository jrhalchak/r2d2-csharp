using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2D2
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            var r2 = new Character();

            CommandLine.ReportLocation(r2.Direction, grid);

            while (!grid.PositionsMatch)
            {
                CommandLine.AcceptCommand(grid, r2);
            }

            CommandLine.LogWin();
        }
    }
}
