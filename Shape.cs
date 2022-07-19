//This is a separate class file that needs to be included in the same project as the "CircleAndSquareAreaCalculator" file on this Git repository

using System;

namespace CircleAndSquareAreaCalculator
{
    /// <summary>
    /// An abstract base class for mathematical shapes that can be used by individual shapes that derive from it
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// A variable that holds shape ID: 1 is for Circle, and 2 is for Square
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A variable that holds the name of the shape, such as Circle and Square
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A variable that holds the color of the shape
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// a method that calculates the area of the shape
        /// </summary>
        /// <returns>Area of shape as a double type value</returns>
        public virtual double CalculateArea()
        {
            //This is a virtual method that returns a default zero value.
            //Thus it will be overridden for each shape type that derives from it.
            //Actual functionality for calculation of area for each shape will be written
            //in the derived classs based on the different formulas for calculation of area
            //of each shape
            return 0;
        }
    }

    /// <summary>
    /// A class to represent a Circle. It is derived from the Shape base class
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// A double type variable that holds the radius of a circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// a method that calculates the area of a circle
        /// </summary>
        /// <returns>Area of circle as a double type value</returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }

    /// <summary>
    /// A class to represent a Square. It is derived from the Shape base class
    /// </summary>
    class Square : Shape
    {
        /// <summary>
        /// A double type variable that holds the side of a square
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// a method that calculates the area of a square
        /// </summary>
        /// <returns>Area of square as a double type value</returns>
        public override double CalculateArea()
        {
            return Side*Side;
        }
    }
}
