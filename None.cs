using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class None : Grid
    {
        public None(int x, int y) : base(x, y) { }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return "   ";
        }
    }
}
