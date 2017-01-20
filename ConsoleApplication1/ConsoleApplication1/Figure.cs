using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Figure
    {
        protected List<Point> pList;

        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.PointDraw();
            }
        }

        internal bool IsHit(Figure figure) // принимаю в качестве аргумента фигуру
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point) // принимаю в качестве аргумента точку
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
