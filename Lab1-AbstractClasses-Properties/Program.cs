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
        private readonly string shapeType;                       //readonly type, can only be set in constructor or initializer
        public string ShapeType                                  //public getter for shapeType
        {
            get
            {
                return shapeType;
            }
        }
        private const double pi = 3.14159;                      //PI should not be altered from the set value during execution
        public double Pi { get;}
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
            return "Shape type: " + ShapeType;
        }
    }

    class Sphere : ThreeDShape
    {
        private readonly double radius;
        public double Radius
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
            return Pi * (radius * radius * radius);
        }
        public override string ToString()
        {
            return base.ToString() + "\nRadius: " + Radius + "\nVolume: " + CalculateVolume() ;  //appends extra shape information to base.ToString() from ThreeDShape
        }
    }
}
