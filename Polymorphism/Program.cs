using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        /*  X and Y coordinate make a vertex
            2 vertices make a line
            line is a shape
        */
        static void Main()
        {
            Vertex v = new Vertex(1, 1);
            Console.WriteLine("X,Y Coordinates of first vertex: {0},{1}", v.XCoord, v.YCoord);
            Line l = new Line(10,2,2,4,"red");
            Console.WriteLine(l.ToString());
            l.Translate(v);                     //translate the line by the amount in vertex v
                                                //in this case, move all points by 1 x and 1 y
            Console.WriteLine(l.ToString());
            Console.ReadLine();
        }
    }
    class Vertex
    {
        public int XCoord { get; set; }   //default get set, no validation needed
        public int YCoord { get; set; }
        
        public Vertex(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;

        }
    }

    abstract class Shape
    {
        public string Color { get; set; }
        public Shape(string color)
        {
            Color = color;
        }
        public override string ToString()
        {
            return "Shape color: " + Color;
        }
        public abstract void Translate(Vertex toTranslate);

    }
    class Line : Shape
    {
        private Vertex point1, point2;
        public Vertex Point1
        {
            get
            {
                return point1;
            }
            set                   //when setting, add value x and y coords to existing coords
            {
                point1.XCoord = point1.XCoord + value.XCoord;
                point1.YCoord = point1.YCoord + value.YCoord;
            }
        }
        public Vertex Point2 {
            get
            {
                return point2;
            }
            set
            {
                point2.XCoord = point2.XCoord + value.XCoord;
                point2.YCoord = point2.YCoord + value.YCoord;
            }
        }

        public Line(int vertex1X, int vertex1Y, int vertex2X, int vertex2Y, string color)
            : base(color)
        {
            point1 = new Vertex(vertex1X, vertex1Y);
            point2 = new Vertex(vertex2X, vertex2Y);
        }
        public override void Translate(Vertex toTranslate)
        {
            Point1 = toTranslate;       //using property to translate point/vertex by amount
            Point2 = toTranslate;
        }
        public override string ToString()
        {
            return "Shape type: Line\n" + base.ToString() + "\nPoint 1: " + Point1.XCoord
                + "," + Point1.YCoord + "\nPoint 2: " + Point2.XCoord + "," + Point2.YCoord;
        }
    }
}
