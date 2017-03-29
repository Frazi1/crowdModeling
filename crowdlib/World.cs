using System;
using System.Collections.Generic;

namespace crowdlib
{
    public class World
    {
        private const int SIZE = 10;
        private int personCounter = 0;
        private int freeCells = SIZE * SIZE;

        public Cell[,] Cells = new Cell[SIZE, SIZE];
        public Cell ExitCell { get; private set; }

        public List<Person> People = new List<Person>();

        public World(int n)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Cells[i, j] = new Cell(i,j);
                }
            }
            GenerateExit();

            for (int i = 0; i < n; i++)
            {
                SpawnRandomPerson();
            }
        }

        public bool SpawnPerson(int x, int y)
        {
            if (Cells[x, y].IsEmpty)
            {
                Person p = new Person(Cells[x, y], ++personCounter, this);
                p.ExitReached += P_ExitReached;
                --freeCells;
                Cells[x, y].Person = p;
                People.Add(p);
                return true;
            }
            return false;
        }

        private void P_ExitReached(object sender, ExitReachedEventArgs e)
        {
            People.Remove(e.Person);
            e.Person.CurrentCell.Person = null;
            e.Person.ExitReached -= P_ExitReached;
        }

        public void SpawnRandomPerson()
        {
            Random rnd = new Random();
            bool success = false;
            if (freeCells > 0)
            {
                while (!success)
                {
                    int x = rnd.Next(SIZE);
                    int y = rnd.Next(SIZE);
                    if(Cells[x,y].IsEmpty && !Cells[x,y].IsExit)
                    {
                        SpawnPerson(x, y);
                        success = true;
                    }
                }
            }
        }
        private void GenerateExit()
        {
            Random rnd = new Random();
            int seed = rnd.Next() % 2;
            int x, y;
            if (seed == 0)
            {
                x = 0;
                y = rnd.Next(0, SIZE);
            }
            else
            {
                y = 0;
                x = rnd.Next(0, SIZE);
            }
            Cells[x, y].IsExit = true;
            ExitCell = Cells[x, y];
        }
    }
}