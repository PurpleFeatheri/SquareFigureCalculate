using System;

namespace SquareFigureCalculate
{
    public class Triangle : IFigure
    {
        private double Side1 { get; set; }
        private double Side2 { get; set; }
        private double Side3 { get; set; }

        public double Area
        {
            get
            {
                var halfPerim = (Side1 + Side2 + Side3) / 2;
                var s = Math.Sqrt(halfPerim * (halfPerim - Side1) * (halfPerim - Side2) * (halfPerim - Side3));

                return s;
            }
        }

        public bool IsRightTriangle()
        {
            var angle1 = Math.Acos((Side1 * Side1 + Side2 * Side2 - Side3 * Side3) / (2 * Side1 * Side2)) * 180 / Math.PI;
            var angle2 = Math.Acos((Side1 * Side1 + Side3 * Side3 - Side2 * Side2) / (2 * Side1 * Side3)) * 180 / Math.PI;
            var angle3 = Math.Acos((Side3 * Side3 + Side2 * Side2 - Side1 * Side1) / (2 * Side3 * Side2)) * 180 / Math.PI;

            return angle1 == 90 || angle2 == 90 || angle3 == 90;
        }


        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
    }
}
