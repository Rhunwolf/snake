using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class LineH : Figure
    {
        public LineH(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new SnakeGame.Point(x, y, sym);
                pList.Add(p);
            }
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.Draw();
        }
    }
}
