using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using crowdlib;

namespace crowdlib
{
    public class Person
    {
        private World world;
        private Thread thread;


        public Point Pos { get { return CurrentCell.Pos; } }
        public Cell CurrentCell { get; private set; }
        public int ID { get; private set; }


        public Thread Thread
        {
            get { return thread; }
            private set { thread = value; }
        }

        public Person(Cell startingCell, int iD, World world)
        {
            ID = iD;
            this.world = world;
            CurrentCell = startingCell;
            Thread = new Thread(new ThreadStart(Go));
            Thread.IsBackground = true;
            Thread.Name = $"thread{ID}";
            //Thread.Start();


        }
        public void Start()
        {
            Thread.Start();
        }
        private void Go()
        {
            Monitor.Enter(CurrentCell);
            while (CurrentCell != world.ExitCell)
            {
                var nextCell = SelectCell();
                MoveTo(nextCell);
                Thread.Sleep(1000);
            }
            Monitor.Pulse(CurrentCell);
            Monitor.Exit(CurrentCell);
            ExitReached(this, new ExitReachedEventArgs(this));
        }
        private void MoveTo(Cell cell)
        {
            Monitor.Enter(cell);

            if (CurrentCell != null)
            {
                CurrentCell.Person = null;
                Monitor.Pulse(CurrentCell);
                Monitor.Exit(CurrentCell);
                CurrentCell = null;
            }

            //Monitor.Enter(cell);
            cell.Person = this;
            CurrentCell = cell;
        }
        private Cell SelectCell()
        {
            int nextX = Pos.X, nextY = Pos.Y;
            int targetX = world.ExitCell.Pos.X;
            int targetY = world.ExitCell.Pos.Y;

            if (Pos.X > targetX)
            {
                --nextX;
            }

            else if (Pos.X < targetX)
            {
                ++nextX;
            }

            if (Pos.Y > targetY)
            {
                --nextY;
            }

            else if (Pos.Y < targetY)
            {
                ++nextY;
            }

            //

            return world.Cells[nextX, nextY];
        }


        public delegate void ExitReachedHandler(object sender, ExitReachedEventArgs e);
        public event ExitReachedHandler ExitReached;
    }


}

public class ExitReachedEventArgs : EventArgs
{
    public Person Person { get; set; }
    public ExitReachedEventArgs(Person p)
    {
        Person = p;
    }


}