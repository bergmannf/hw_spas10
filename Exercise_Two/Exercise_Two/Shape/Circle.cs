using System;
using System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_Two.Shape
{
    class Circle: Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double Area()
        {
            double area = Math.PI * Math.Pow(this.Radius, 2);
            return area;
        }
    }
}
