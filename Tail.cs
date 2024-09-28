using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Tail : Snake
    {
        public Body Front { get; private set; }
        public Tail(int x, int y) : base(x, y) { }
        public Tail(Snake copy) : base(copy.X, copy.Y) { }
        public override void Move(int y, int x)
        {
            int tempX = this.X;
            int tempY = this.Y;
            base.Move(y, x);
            MapFunctions.Map[tempY][tempX] = new None(tempX, tempY);
        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "[o]";
        }
    }
}
