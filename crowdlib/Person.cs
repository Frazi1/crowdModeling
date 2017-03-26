using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace crowdlib
{
    public class Person
    {
        private World world;
        private Thread thread;
        private Cell startingCell;

        public Point Pos { get { return CurrentCell.Pos; } }
        public Cell CurrentCell { get; private set; }
        public int ID { get; private set; }


        public Thread Thread
        {
            get { return thread; }
            private set { thread = value; }
        }

        public Person(Cell currentCell, int iD, World world)
        {
            ID = iD;
            this.world = world;
            Thread = new Thread(new ParameterizedThreadStart(Go));
            Thread.IsBackground = true;
            Thread.Start(currentCell);


        }

        private void Go(object c)
        {
            while (CurrentCell != world.ExitCell)
            {
                Cell cell = (Cell)c;
                if (startingCell == null)
                {
                    startingCell = cell;
                    MoveTo(startingCell);
                }
                else
                {
                    while (CurrentCell != world.ExitCell)
                    {
                        var nextCell = SelectCell();

                        MoveTo(nextCell);
                        Thread.Sleep(500);

                    }
                    CurrentCell.Person = null;
                    Monitor.Exit(CurrentCell);
                    this.CurrentCell = null;
                    return;

                }
            }
        }
        private void MoveTo(object c)
        {
            Cell cell = (Cell)c;
            if (CurrentCell != null)
            {
                CurrentCell.Person = null;
                Monitor.Exit(CurrentCell);
            }

            Monitor.Enter(cell);
            cell.Person = this;
            CurrentCell = cell;
        }
        private Cell SelectCell()
        {
            int nextX = Pos.X, nextY = Pos.Y;
            int targetX = world.ExitCell.Pos.X;
            int targetY = world.ExitCell.Pos.Y;

            if (this.Pos.X > targetX)
            {
                --nextX;
            }
            else if (Pos.X == targetX)
            { }
            else
            {
                ++nextY;
            }

            if (this.Pos.Y > targetY)
            {
                --nextY;
            }
            else if (Pos.Y == targetY)
            { }
            else
            {
                ++nextY;
            }
            return world.Cells[nextX, nextY];
        }
    }
}
