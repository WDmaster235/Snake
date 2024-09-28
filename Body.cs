using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Body : Snake
    {
        public Snake Back {  get; set; }
        public Body(int x, int y) : base(x, y) { }

        public override void Move(int y, int x)
        {

            int tempX = this.X;
            int tempY = this.Y;
            base.Move(y, x);
            this.Back.Move(tempY, tempX);
            
        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "[O]";
        }
    }
}
