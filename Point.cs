//A structure (struct) to do the following:
//Create a structure named “Point” and 2 data members: X and Y coordinate for graphs.

using System;

namespace StructPractice
{
   struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x,float y)
        {
            this.X = x; 
            this.Y = y;
        }
    }
}
