using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IHasVolume
    {

        double Volume();
    }

    class Program
    {
        static void Main()
        {
            //ThreeDShape shape = new ThreeDShape();            //results in build error when trying to instantiate abstract class
            IHasVolume i = new Sphere(12.34);
            Console.WriteLine(i.ToString());

            IHasVolume[] shapeCollection = { new Sphere(10),
                                              new Sphere(5.6)};
            foreach (Sphere shape in shapeCollection)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.ReadLine();

        }
    }
    

    class Sphere : IHasVolume
    {
        private const double pi = 3.14159;
        public double Pi { get
            {
                return pi;
            }
            }
        private readonly double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
        }
        public Sphere(double radius)   //pass shapeType to ThreeDShape
        {
            this.radius = radius;
        }
        public override string ToString()
        {
            return base.ToString() + "\nRadius: " + Radius + "\nVolume: " + Volume();  //appends extra shape information to base.ToString() from ThreeDShape
        }

        public double Volume()
        {
            return Pi * (Radius * Radius * Radius); 
        }
    }
}
