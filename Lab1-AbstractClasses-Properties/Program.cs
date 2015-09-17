using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1AbstractClassesProperties
{
    class Program
    {
        static void Main()
        {
            //ThreeDShape shape = new ThreeDShape();            //results in build error when trying to instantiate abstract class
            Sphere sphereShape = new Sphere("Sphere", 12.34);
            Console.WriteLine(sphereShape.ToString());
            Console.ReadLine();

        }
    }
    public abstract class ThreeDShape
    {
        public readonly string shapeType;                       //readonly type, can only be set in constructor or initializer
        public string GetShape                                  //public getter for shapeType
        {
            get
            {
                return shapeType;
            }
        }
        private const double pi = 3.14159;                      //PI should not be altered from the set value during execution
        public double GetPi                                     //public getter for PI
        {
            get
            {
                return pi;
            }
        }
        protected ThreeDShape(string shapeType)                 //protected constructor for abstract class as public access is not required
        {
            this.shapeType = shapeType;
        }
        protected ThreeDShape()
            : this("")
        {
        }
        public abstract double CalculateVolume();

        public override string ToString()
        {
            return "Shape type: " + GetShape;
        }
    }

    class Sphere : ThreeDShape
    {
        public readonly double radius;
        public double getRadius
        {
            get
            {
                return radius;
            }
        }
        public Sphere(string shapeType, double radius) : base(shapeType)    //pass shapeType to ThreeDShape
        {
            this.radius = radius;
        }

        public override double CalculateVolume()
        {
            return GetPi * (radius * radius * radius);
        }
        public override string ToString()
        {
            return base.ToString() + "\nRadius: " + getRadius + "\nVolume: " + CalculateVolume() ;  //appends extra shape information to base.ToString() from ThreeDShape
        }
    }
}
