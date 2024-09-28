using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Apple : Grid
    {
        public Apple(int x, int y) : base(x, y) { }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "[$]";
        }
    }
}
