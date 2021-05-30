using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Vector
    {
        public double x = 0;
        public double y = 0;

        //constructor
        public Vector (double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Vector(Vector V)
        {
            x = V.x;
            y = V.y;
        }

        //add
        public static Vector operator+ (Vector V1, Vector V2)
        {
            Vector V = new Vector(V1);
            V.x += V2.x;
            V.y += V2.y;
            return V;
        }

        //sub
        public static Vector operator- (Vector V1, Vector V2)
        {
            Vector V = new Vector(V1);
            V.x -= V2.x;
            V.y -= V2.y;
            return V;
        }

        //scaler multiplication
        public static Vector operator* (Vector V, double d)
        {
            V.x = V.x * d;
            V.y = V.y * d;
            return V;
        }

        //dot product
        public double dot(Vector V)
        {
            return x * V.x + y * V.y;
        }

        //cross product
        public double cross(Vector V)
        {
            return x * V.y - y * V.x;
        }

        //magnitude
        public double mag()
        {
            return Math.Sqrt((x * x + y * y));
        }

        //rotate about origin
        public void rotate(double theta)
        {
            Vector Temp = new Vector(x, y);
            x = Temp.x * Math.Cos(theta) - Temp.y * Math.Sin(theta);
            y = Temp.y * Math.Cos(theta) + Temp.x * Math.Sin(theta);
        }

        //rotate about point
        public void rotate(Vector axis, double theta)
        {
            Vector vector  = new Vector(x, y);
            vector = vector - axis;
            vector.rotate(theta);
            vector = vector + axis;
            x = vector.x;
            y = vector.y;
        }
    }

    //class point : Vector
    //{
    //    //public point(double X, double Y)
    //    //{
    //    //    x = X;
    //    //    y = Y;
    //    //}
    //    public void rotate()
    //    {
    //        rotate(Math.PI /2);
    //    }
    //}

    abstract class Region
    {
        // Check if a point belongs to the region (including its boundary/perimeter)
        public abstract bool contains(Vector V);

        // translate the region by (x,y) units: x unit on X-axis and y units on Y-axis
        public abstract void translate(Vector D);

        // find the centoid for the region
        public abstract Vector centroid();

        // rotate the region by an angle θ (in radians)
        public abstract void rotate(Vector Axis,double angle);
        public void rotate(double angle)
        {
            rotate(centroid(), angle);
        }

        // find the area of a region
        public abstract double area();
    }

    class Triangle : Region
    {
        Vector P1, P2, P3;
        
        public Triangle(Vector Point1, Vector Point2, Vector Point3)
        {
            P1 = Point1;
            P2 = Point2;
            P3 = Point3;
        }

        // Check if a point belongs to the region (including its boundary/perimeter)
        public override bool contains(Vector V)
        {
            double t1 = (V - P1).cross(P2 - P1) * (P2 + P3 - P1 - P1).cross(P2 - P1);
            double t2 = (V - P2).cross(P3 - P2) * (P3 + P1 - P2 - P2).cross(P3 - P2);
            double t3 = (V - P3).cross(P1 - P3) * (P1 + P2 - P3 - P3).cross(P1 - P3);

            if (t1 >= 0 & t2 >= 0 & t3 >= 0) { return true; } else { return false; }
        }

        // translate the region by (x,y) units: x unit on X-axis and y units on Y-axis
        public override void translate(Vector D)
        {
            P1 = P1 + D;
            P2 = P2 + D;
            P3 = P3 + D;
        }

        // find the centoid for the region
        public override Vector centroid()
        {
            return (P1 + P2 + P3) * (1.0 / 3.0);
        }

        // rotate the region by an angle θ (in radians)
        public override void rotate(Vector Axis, double angle)
        {
            P1.rotate(Axis, angle);
            P2.rotate(Axis, angle);
            P3.rotate(Axis, angle);
        }

        // find the area of a region
        public override double area()
        {
            return (P1 - P3).cross(P2 - P3)/2.0;
        }
    } 
}
