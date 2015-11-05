using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab1.Models
{
    public enum EngineType
    {
        Petrol,Diesel,Hybrid
    }
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double EngineSize { get; set; }
        public EngineType Enginetype { get; set; }

        public Car(string make, string model, double engineSize, EngineType engineType)
        {
            Make = make;
            Model = model;
            EngineSize = engineSize;
            Enginetype = engineType;
        }
    }
}
