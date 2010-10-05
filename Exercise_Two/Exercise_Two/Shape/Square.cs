using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_Two.Shape
{
    class Square: Rectangle
    {
        public Square(Point coordOne, Point coordTwo): base(coordOne, coordTwo)
        {
            if (!isSquare(coordOne, coordTwo))
            {
                throw new ArgumentException("No coordinates for a square");
            }
        }

        private bool isSquare(Point coordOne, Point coordTwo)
        {
            double xLength = this.coordinateTwo.X - this.coordinateOne.X;
            double yLength = this.coordinateTwo.Y - this.coordinateOne.Y;
            if (xLength != yLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
