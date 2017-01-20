using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
           wallList = new List<Figure>();

           LineH lineTop = new LineH(1, mapWidth - 2, 1, '+');
           LineH lineBottom = new LineH(1, mapWidth - 2, mapHeight - 2, '+');
           LineV lineLeft = new LineV(1, 1, mapHeight - 2, '+');
           LineV lineRight = new LineV(mapWidth - 2, 1, mapHeight - 2, '+');

           wallList.Add( lineTop );
           wallList.Add( lineBottom );
           wallList.Add( lineLeft );
           wallList.Add( lineRight );

        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
