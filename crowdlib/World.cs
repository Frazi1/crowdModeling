using System;
using System.Collections.Generic;

namespace crowdlib
{
    public class World
    {
        private const int SIZE = 10;
        public Cell[,] Cells = new Cell[SIZE, SIZE];

        public List<Person> People = new List<Person>();
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
        }

    }
}