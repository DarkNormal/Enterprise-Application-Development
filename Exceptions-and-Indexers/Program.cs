using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAndIndexers
{
    class Program
    {


        static void Main(
            )
        {
            double x = 0, y = 0;
            Boolean badChar = true;
            Boolean badChar2 = true;

            while (badChar)
            {
                Console.WriteLine("Enter 1st number: ");
                try
                {
                    x = Convert.ToDouble(Console.ReadLine());
                    badChar = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers in integer or decimal format");
                }
            }
            while (badChar2)
            {
                Console.WriteLine("Enter 2nd number: ");
                try
                {
                    y = Convert.ToDouble(Console.ReadLine());
                    badChar2 = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers in integer or decimal format");

                }
            }

            try
            {
                double result = Calculator.divide(x, y);
                Console.WriteLine("Result of {0} / {1} = {2}", x, y, result);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.WriteLine("Press Enter to run the next program (Module CA Results)");
            Console.ReadLine();

            ModuleCAResults ca = new ModuleCAResults("Mark Lordan", "Coding", 10);
            try {
                ca[0] = "A";
                ca[2] = "B";               
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Console.WriteLine(ca.ToString());
            Console.ReadLine();








        }
    }
    class Calculator
    {
        public static double divide(double toDivide, double divider)
        {
            if (divider == 0)
            {
                throw new ArgumentException("Can't divide by zero");
            }
            else
            {
                double result = toDivide / divider;
                return result;
            }
        }

        private Calculator() { }
    }

    public class ModuleCAResults
    {
        public string StudentName { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public string[] percentage = new string[3];

        public ModuleCAResults(string studentName, string moduleName, int credits)
        {
            StudentName = studentName;
            ModuleName = moduleName;
            Credits = credits;
        }

        public string this[int i]
        {
            get {
                if(i >= 0 && i < percentage.Length)
                {
                    return percentage[i];
                }
                else
                {
                    throw new ArgumentException("CA " + i + " does not exist");
                }     
            }
            set {
                bool error = false;
                if(i >= 0)
                {
                    for(int j = 0; j < i; j++)
                    {
                        if(percentage[j] == null)
                        {
                            error = true;
                        }
                    }
                    if (error)
                    {
                        throw new ArgumentException("CA score not in order");
                    }
                    else
                    {
                        percentage[i] = value;
                    }
                    
                }
            }
        }
        



        public override string ToString()
        {
            string CAresults = "";
            for(int i = 0; i < percentage.Length; i++)
            {
                if (percentage[i] == null)
                {
                    CAresults = CAresults + "CA " + (i + 1) + " score not entered\n";
                }
                else
                {
                    CAresults = CAresults + "CA " + (i + 1) + " score: " + percentage[i] + "\n";
                }
            }
            CAresults.Replace("\n", Environment.NewLine);
            return "Module Name: " + ModuleName + "\nStudent Name: "
                + StudentName + "\nCredits for Module: " + Credits
                + "\nContinuous assessment results: \n" + CAresults;
        }
    }
}
