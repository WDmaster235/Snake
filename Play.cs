using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Play
    {
        public static void PlayGame(int speed)
        {
            Console.Write("Enter board size: ");
            int length = int.Parse(Console.ReadLine());
            MapFunctions.SetMap(length);
            MapFunctions.GenerateMap();

            Direction currentDirection = Direction.Right;
            Console.CursorVisible = false;
            while (true)
            {
                MoveInDirection(currentDirection);
                MapFunctions.DisplayMap();

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            currentDirection = Direction.Up;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            currentDirection = Direction.Down;
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            currentDirection = Direction.Left;
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            currentDirection = Direction.Right;
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        
        public static void MoveInDirection(Direction direction)
        {
            MapFunctions.SnakeHead.MoveHead(direction);
        }
    }
}
