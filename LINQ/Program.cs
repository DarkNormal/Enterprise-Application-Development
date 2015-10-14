using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Car a = new Car("Ford", "Focus", "01-D-1234", 1600);
            Car b = new Car("Ford", "Mondeo", "07-C-29493", 1900);
            Car c = new Car("Aston", "Martin", "15-WW-392", 3200);
            Car d = new Car("Mazda", "MX-3", "15-W-39245", 1600);
            Car e = new Car("Nissan", "X-Trail", "12-D-30311", 1900);
            Car f = new Car("Volkswagen", "Golf", "141-D-20155", 1800);
            Car g = new Car("Mazda", "Speed", "05-L-392", 1400);
            Car h = new Car("Mercedes Benz", "SLS", "12-KE-34224", 3600);
            List<Car>fleet = new List<Car>();
            //add all car objects to Fleet list
            fleet.Add(a);
            fleet.Add(b);
            fleet.Add(c);
            fleet.Add(a);
            fleet.Add(d);
            fleet.Add(e);
            fleet.Add(f);
            fleet.Add(g);
            fleet.Add(h);

            //ascending order of cars by registration
            var ascending = from v in fleet orderby v.Registration select v;
            foreach(var v in ascending)
            {
                Console.WriteLine(v);
            }
            //all cars that are Mazdas
            var mazda = from z in fleet where z.Make == "Mazda" select z;
            foreach (var z in mazda)
            {
                Console.WriteLine(z);
            }
            //descending order of engine size of all cars
            var descendingCC = from v in fleet orderby v.EngineSize descending select v;
            foreach (var v in descendingCC)
            {
                Console.WriteLine(v);
            }
            //only cars which have an engine size of 1600
            var greaterThan1600 = from v in fleet where v.EngineSize == 1600 select v;
            foreach (var v in greaterThan1600)
            {
                Console.WriteLine(v);
            }
            //the count of cars which have an engine cc less than 1600
            var lessThan1600 = from v in fleet where v.EngineSize < 1600 select v;
            Console.WriteLine(lessThan1600.Count());

            Console.ReadLine();
        }
    }
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int EngineSize { get; set; }

        public Car()
        {

        }
        public Car(string make, string model, string registration, int engineSize)
        {
            Make = make;
            Model = model;
            Registration = registration;
            EngineSize = engineSize;
        }
        public override string ToString()
        {
            return "Make: " + Make + "\nModel: " + Model + "\nRegistration: " + Registration + "\nEngine size (cc): " + EngineSize;
        }
    }

    
}
