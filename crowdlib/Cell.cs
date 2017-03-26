using System.Drawing;
namespace crowdlib
{
    public class Cell
    {
        private Point pos;


        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public bool IsExit { get; set; }

        public Person Person { get; set; }
        public bool IsEmpty { get { return Person == null; } }

        public Cell(Point pos)
        {
            Pos = pos;
        }

        public Cell(int x, int y)
        {
            Pos = new Point(x, y);
        }

    }
}