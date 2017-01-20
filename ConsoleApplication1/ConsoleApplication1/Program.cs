using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(80, 25);
            WriteWelcomeGame();
        }

        static void TheGame()
        {
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point pS = new Point(10, 8, '@');
            Snake snake = new Snake(pS, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '*');
            Point food = foodCreator.CreateFood();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            food.PointDraw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    food.PointDraw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Нажмите любую клавишу.", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Console.ReadKey();
            Console.Clear();
            TheGame();
        }

        static void WriteWelcomeGame()
        {
            int xOffset = 20;
            int yOffset = 6;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("===============================", xOffset, yOffset++);
            WriteText("С У Х О П У Т Н А Я   З М Е Я", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Правила игры:", xOffset + 2, yOffset++);
            WriteText("а) Есть;", xOffset + 2, yOffset++);
            WriteText("б) Не падать в воду.", xOffset + 2, yOffset++);
            yOffset++;
            WriteText("Нажмите любую клавишу.", xOffset + 2, yOffset++);
            WriteText("===============================", xOffset, yOffset++);
            yOffset++;
            WriteText("Автор: Дмитрий Тэлэри", xOffset + 2, yOffset++);
            Console.ReadKey();
            Console.Clear();
            TheGame();
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
