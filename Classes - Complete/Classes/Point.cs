//DEBORA URRUTIA
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Point
    {
        private int x, y;//declare variables
        private static int objectCount = 0;//set the object counter to 0
        Random randomizer = new Random();// initialize random for random points

        public Point()// default constructor
        {
            this.x = -1;
            this.y = -1;
            objectCount++;
        }

        public Point(int x, int y)// constructor
        {
            this.x = x;
            this.y = y;
            objectCount++;
        }

        public Point NewP(int x, int y)//generates a new random number
        {
            //-------------------------------------//
            this.x = randomizer.Next(1,2000);
            this.y = randomizer.Next(1,2000);

            Point otherpoint = new Point(x,y);
            //distance = bottomright.DistanceTo(x,y);
            objectCount++;
            return otherpoint;
            //--------------------------------------//
        }

        //Function used to calculate de distance between points.
        public double DistanceTo(Point other) 
        {
            int xDiff = this.x - other.x;
            int yDiff = this.y - other.y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            return distance;
        }

        public static int ObjectCount()//Function that returns the counted objects
        {            
            return objectCount;
        }
    }
}
