using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class Snake : Grid
    {
        public Snake(int x, int y) : base(x, y) { }
        public virtual void Move(int y, int x)
        {
            int tempX = this.X;
            int tempY = this.Y;
            this.Y = y;
            this.X = x;
            MapFunctions.Map[y][x] = this;
        }
    }
}
