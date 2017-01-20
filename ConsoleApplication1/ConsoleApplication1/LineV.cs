using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class LineV : Figure
    {
        public LineV(int x, int yUp, int yDown, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
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
