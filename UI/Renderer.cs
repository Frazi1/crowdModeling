using crowdlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace UI
{
    public class Renderer
    {
        public void DrawCells(Canvas c, Cell[] cells)
        {
            int cell_number = cells.GetLength(0);
            double cell_size = 50;

            for (int i = 0; i < cell_number; i++)
            {
                Rectangle r = new Rectangle();
                r.Width = cell_size;
                r.Height = cell_size;
                r.Stroke = 
            }
        }
    }
}
