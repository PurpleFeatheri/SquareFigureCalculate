using System;

namespace SquareFigureCalculate
{
    public class Circle : IFigure
    {
        private double Radius { get; set; }

        public double Area =>
             Math.PI * Math.Pow(Radius, 2);

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
}
