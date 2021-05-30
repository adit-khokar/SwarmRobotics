using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector(0, 0);
            Vector V2 = new Vector(10, 0);
            Vector V3 = new Vector(0, 10);

            Vector V4 = V1 + V2;

            Triangle T = new Triangle(V1, V2, V3);

            Console.WriteLine(V4.mag());
            Console.WriteLine(T.area());
            Console.WriteLine(T.contains(new Vector(1, 9)));
            T.translate(new Vector(-1, -5));
            Console.WriteLine(T.contains(new Vector(1, 9)));
            Console.ReadKey();
        }
    }
}
