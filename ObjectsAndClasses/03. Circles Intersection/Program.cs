using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circles_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstParameters = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToArray();

            Point pointOne = new Point
            {
                X = firstParameters[0],
                Y = firstParameters[1]

            };

            int[] secondParameters = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToArray();

            Point pointTwo = new Point
            {
                X = secondParameters[0],
                Y = secondParameters[1]

            };

            bool Intersect = false;

            double distance = GetDistance(pointOne, pointTwo);

            if (distance <= firstParameters[2] + secondParameters[2] )
            {
                Intersect = true;
                Console.WriteLine("Yes");
            }
            else
            {
                Intersect = false;
                Console.WriteLine("Yes");
            }



        }


        

        public static double GetDistance(Point point1, Point point2)
        {
            var sideA = point1.X - point2.X;
            var sideB = point1.Y - point2.Y;

            var distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;


        }

        
    }

    class Circle
    {
        public int Center { get; set; }

        public int Radius { get; set; }
    }

    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}
