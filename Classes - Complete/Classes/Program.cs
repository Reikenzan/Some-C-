//DEBORA URRUTIA
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Program
    {
        static void doWork()
        {
            Point origin = new Point();// default constructor
            Point bottomRight = new Point(1366, 768); // a setted point
            Point NewP = new Point();// new random point
            double distance = origin.DistanceTo(bottomRight);//Distance from point 1(origin) to point 2(bottomRight)
            Console.WriteLine("Distance is: {0}", distance); //Print the distance for the 2 setted points
            //Print the number of point objects
            Console.WriteLine("Number of Point objects: {0}", Point.ObjectCount()); 
            //-----------------//
            double distance2 = bottomRight.DistanceTo(NewP);//print the distance from Point2(bottomRight) to Point 3(NewP)
            Console.WriteLine("Distance is: {0}", distance2); //Print the distance
            //-----------------//
        }

        static void Main(string[] args)//Main function that loads(run) the all functions
        {
            try //throw a exception
            {
                doWork();
            }
            catch (Exception ex) //catch the exception
            {
                Console.WriteLine(ex.Message);
            }

            return;
        }
    }
}
