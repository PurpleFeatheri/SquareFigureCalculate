using System.Collections.Generic;
using System.Drawing;

namespace SquareFigureCalculate
{
    public class Shape : IFigure
    {
        private List<Point> Points { get; set; }

        public double Area
        {
            get
            {
                int i, j;
                double square = 0;

                for (i = 0; i < Points.Count; i++)
                {
                    j = (i + 1) % Points.Count;

                    square += Points[i].X * Points[j].Y;
                    square -= Points[i].Y * Points[j].X;
                }

                square /= 2;
                return (square < 0 ? -square : square);
            }
        }

        public Shape(List<Point> points)
        {
            Points = points;            
        }
    }
}
