using Snake;

public abstract class Grid
{
    public int X { get; set; }
    public int Y { get; set; }

    public Grid(int x, int y) 
    {
        this.X = x;
        this.Y = y;
    }
}
