using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swarm_Robotics_Assign_2
{

    class Vector
    {
        public double x = 0;
        public double y = 0;

        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }
        /*public Vector2(Vector R)
        {
                r = R.r;
        }*/
        public Vector(Vector V)
        {
            x = V.x;
            y = V.y;
        }
    }
    abstract class Region
    {
        public abstract bool contains(Vector V);
        public abstract double area();
        public abstract void translate(Vector P);
        public abstract double magnitude(Vector V);
    }
    class Circle : Region
    {
        Vector Q;
        double a, b;
        public Circle(Vector centre, double inner_r, double outer_r)
        {
            Q = centre;
            a = inner_r;
            b = outer_r;
        }
        public override bool contains(Vector V)
        {
            double t1 = (magnitude(V) * magnitude(V)) - (a * a);
            double t2 = (magnitude(V) * magnitude(V)) - (b * b);
            if (t1 >= 0 && t2 <= 0) { return true; } else { return false; }
        }
        public override double area()
        {
            return Math.PI * (b * b - a * a);
        }
        public override double magnitude(Vector V)
        {
            return Math.Sqrt((V.x - Q.x) * (V.x - Q.x) + (V.y - Q.y) * (V.y - Q.y));
        }
        public override void translate(Vector P)
        {
            Q.x += P.x;
            Q.y += P.y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector(0, 0);
            //Vector R1 = new Vector(10);
            //Vector R2 = new Vector(5);
            double R1 = 10;
            double R2 = 5;
            Circle C = new Circle(V1, R2, R1);

            Console.WriteLine("Area = " + C.area());                                 //area of Annular region
            Console.WriteLine("Magnitude initial = " + C.magnitude(new Vector(4, 7))); //magnitude from origin V1
            Console.WriteLine("Contained = " + C.contains(new Vector(4, 7)));
            C.translate(new Vector(2, 5));                                           // origin V1 is translated
            Console.WriteLine("Magnitude after translation of centre = " + C.magnitude(new Vector(4, 7))); //magnitude from new origin V1
            Console.WriteLine("Contained = " + C.contains(new Vector(4, 7)));
            Console.ReadKey();
        }
    }
}
