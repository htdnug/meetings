using System;

namespace UnitTesting
{
    public class Circle
    {
        public double CalculatePerimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public double CalculateArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double CalculateDiameter(double radius)
        {
            return radius * 2;
        }
    }
}
