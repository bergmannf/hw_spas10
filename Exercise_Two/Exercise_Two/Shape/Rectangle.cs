using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_Two.Shape
{
    class Rectangle: Shape
    {
        public Point coordinateOne {get; set;}

        public Point coordinateTwo {get; set;}

        public Rectangle(Point coordOne, Point coordTwo)
        {
            this.coordinateOne = coordOne;
            this.coordinateTwo = coordTwo;
        }

        public override double Area()
        {
            double area;
            double xLength = this.coordinateTwo.X - this.coordinateOne.X;
            double yLength = this.coordinateTwo.Y - this.coordinateOne.Y;

            xLength = (xLength < 0) ? xLength * (-1) : xLength;
            yLength = (yLength < 0) ? yLength * (-1) : yLength;

            area = xLength * yLength;
            return area;
        }
    }
}
