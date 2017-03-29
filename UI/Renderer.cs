using crowdlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UI
{
    public class Renderer
    {
        public static void DrawCanvas(Canvas c, Cell[,] cells, List<Person> people)
        {
            double cell_size = 50;

            DrawCells(c,cells, cell_size);
            DrawPeople(c, people, cell_size);

        }
        public static void DrawCells(Canvas c, Cell[,] cells, double cell_size)
        {
            c.Children.Clear();

            int cell_number = cells.GetLength(0);

            for (int i = 0; i < cell_number; i++)
            {
                for (int j = 0; j < cell_number; j++)
                {
                    //Рисуем клетки
                    Rectangle r = new Rectangle();
                    r.Name = $"cell{i}p{j}";
                    r.Width = cell_size;
                    r.Height = cell_size;
                    r.Margin = new System.Windows.Thickness(i * cell_size, j * cell_size, 0, 0);
                    if (cells[j, i].IsExit)
                    {
                        r.Stroke = Brushes.Red;
                        r.StrokeThickness = 5;
                    }
                    else
                    {
                        r.Stroke = Brushes.Black;
                    }
                    c.Children.Add(r);
                }
            }
        }

        private static void DrawPeople(Canvas c, List<Person> people, double cell_size)
        {
            for (int k = 0; k < people.Count; k++)
            {

                var p = people[k];
                if (p.CurrentCell != null)
                {
                    Ellipse e = new Ellipse();
                    //e.Name = $"person{cells[j, i].Person.ID}";
                    e.Width = cell_size - 5;
                    e.Height = e.Width;
                    e.Margin = new System.Windows.Thickness(p.Pos.Y * cell_size, p.Pos.X * cell_size, 0, 0);
                    e.Stroke = Brushes.Blue;
                    e.StrokeThickness = 2;
                    c.Children.Add(e);
                }
            }//}
        }
    }
}
