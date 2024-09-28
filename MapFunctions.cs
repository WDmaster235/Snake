using System;
using System.Drawing;
using System.Threading;
namespace Snake
{
    public static class MapFunctions
    {
        public static Grid[][] Map { get; private set; }
        public static Head SnakeHead { get; private set; } = new Head(0, 0);
        public static Tail SnakeTail { get; private set; } = new Tail(0, 0);
        public static int Score { get; private set; } = 0;

        public static void SetMap(int length)
        {
            Map = new Grid[length][];
            for (int i = 0; i < length; i++)
            {
                Map[i] = new Grid[length];
                for (int j = 0; j < Map[i].Length; j++)
                    Map[i][j] = new None(i, j);
            }
            GenerateApple();
        }

        public static void Move(ConsoleKeyInfo keyInfo)
        {
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    SnakeHead.MoveHead(Direction.Up);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    SnakeHead.MoveHead(Direction.Down);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    SnakeHead.MoveHead(Direction.Left);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    SnakeHead.MoveHead(Direction.Right);
                    break;
                default:
                    Console.WriteLine("Invalid key pressed");
                    break;
            }
        }

        public static void GenerateMap()
        {
            SnakeHead.X = Map.Length / 2;
            SnakeHead.Y = Map.Length / 2;
            SnakeTail.X = Map.Length / 2;
            SnakeTail.Y = Map.Length / 2 + 2;
            var body = new Body(Map.Length / 2, Map.Length / 2 + 1);
            body.Back = SnakeTail;
            Map[Map.Length / 2][Map.Length / 2] = SnakeHead;
            Map[Map.Length / 2 + 1][Map.Length / 2] = body;
            Map[Map.Length / 2 + 2][Map.Length / 2] = SnakeTail;
            DisplayMap();
            SnakeHead.Back = body;
            
        }

        public static void JustAteAnApple(Direction direction)
        {
            Score++;
            SnakeHead.GenerateTail(direction);
            GenerateApple();
        }

        public static void GenerateApple()
        {
            Random random = new Random();
            while (true)
            {
                int randX = random.Next(0, Map.Length);
                int randY = random.Next(0, Map.Length);

                if (Map[randX][randY] is None)
                {
                    Map[randX][randY] = new Apple(randX, randY);
                    break;
                }
                bool win = true;
                for(int i = 0; i < Map.Length; i++)
                {
                    for(int j = 0; j < Map.Length; j++)
                    {
                        if (Map[i][j] is not None)
                            win = false;
                    }
                }
                if (win)
                    Win();
            }
        }

        public static void DisplayMap()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < Map.Length; i++)
                Console.Write("---");
            Console.WriteLine("--");

            for (int i = 0; i < Map.Length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Map[i].Length; j++)
                {
                    Console.Write(Map[i][j].ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("|");
            }
            for (int i = 0; i < Map.Length; i++)
                Console.Write("---");
            Console.Write("--");
            Console.WriteLine($"\nScore: {Score}");
        }


        public static void GameOver()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Game Over! Your score is: " + Score);
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
        public static void Win()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("You Won! Your Score is: "  + Score + 1);
        }
    }
}
