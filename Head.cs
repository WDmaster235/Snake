using System;

namespace Snake
{
    public class Head : Snake
    {
        public Snake Back { get; set; }

        public Head(int x, int y) : base(x, y) { }

        public void MoveHead(Direction direction)
        {
            int prevX = this.X, prevY = this.Y;

            switch (direction)
            {
                case Direction.Up: Y--; break;
                case Direction.Down: Y++; break;
                case Direction.Left: X--; break;
                case Direction.Right: X++; break;
            }

            if (X < 0 || Y < 0 || X >= MapFunctions.Map.Length || Y >= MapFunctions.Map.Length || MapFunctions.Map[Y][X] is Snake)
            {
                MapFunctions.GameOver();
            }
            else if (MapFunctions.Map[Y][X] is Apple)
            {
                MapFunctions.JustAteAnApple(direction);
            }
            else
            {
                MapFunctions.Map[Y][X] = this;
            }

            Back.Move(prevY, prevX);
        }

        public void GenerateTail(Direction direction)
        {
            MapFunctions.Map[this.Y][this.X] = this;
            int prevX = this.X, prevY = this.Y;
            Body body = new Body(prevX, prevY);
            body.Back = this.Back;
            this.Back = body;
            MapFunctions.Map[prevY][prevX] = body;
            
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "[0]";
        }
    }
}
