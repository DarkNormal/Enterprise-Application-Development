using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertex v = new Vertex(10, 5);
            Console.WriteLine("X,Y Coordinates of first vertex: {0},{1}", v.GetXCoord, v.GetYCoord);
            Console.ReadLine();
        }
    }
    class Vertex
    {
        private int xCoord, yCoord;
        public int GetXCoord
        {
            get
            {
                return xCoord;
            }
        }
        public int GetYCoord
        {
            get
            {
                return yCoord;
            }
        }
        public Vertex(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;

        }
    }

    class Shape
    {
        private string color;
       
    }
}
