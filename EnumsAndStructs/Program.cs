using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsAndStructs
{
    class Program
    {
        static void Main()
        {
            try {
                Money mon = new Money(1000, "Euro");
                Money monTwo = new Money(500, "Dollars");
                Console.WriteLine(mon.MoneyAmount + " " + mon.CurrencyUnit);
                mon.Conversion(mon.MoneyAmount, "Euro", "Yen");
                Console.WriteLine(mon.MoneyAmount + " " + mon.CurrencyUnit);

                Money added = mon.CurrencyAddition(mon, monTwo);
                Console.WriteLine(added.MoneyAmount + " " + added.CurrencyUnit);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Console.ReadLine();
        }
    }
    public struct Money
    {
        public double MoneyAmount { get; set; }
        public string CurrencyUnit { get; set; }
        static double DollarToEuro { get { return 0.893; } }
        static double DollarToYen { get { return 120.66; } }
        static double EuroToDollar { get { return 1.119721; } }
        static double EuroToYen { get { return 135.10; } }
        static double YenToEuro { get { return 0.007401; } }
        static double YenToDollar { get { return 0.008288; } }

        public Money(double money, string unit) :this()
        {
            MoneyAmount = money;
            if(unit.ToLower(CultureInfo.CurrentCulture).Equals("euro") || unit.ToLower(CultureInfo.CurrentCulture).Equals("dollars") ||
                unit.ToLower(CultureInfo.CurrentCulture).Equals("yen"))
            {
                CurrencyUnit = unit;
            }
            else
            {
                throw new ArgumentException("Invalid currency type entered. Enter Euro, Dollars or Yen");
            }
            
        }
        public double Conversion(double money, string currentUnit, string conversionUnit)
        {
            double convertedAmt = money;
            if (currentUnit.ToLower(CultureInfo.CurrentCulture).Equals("dollars"))
            {
                if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("euro"))
                {
                    convertedAmt = money * DollarToEuro;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("yen"))
                {
                    convertedAmt = money * DollarToYen;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("dollars"))
                {
                    return money;
                }
                else
                {
                    throw new ArgumentException("Invalid currency type entered. Enter Euro, Dollars or Yen");
                }
            }
            else if (currentUnit.ToLower(CultureInfo.CurrentCulture).Equals("euro"))
            {
                if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("dollars"))
                {
                    convertedAmt = money * EuroToDollar;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("yen"))
                {
                    convertedAmt = money * EuroToYen;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("euro"))
                {
                    return money;
                }
                else
                {
                    throw new ArgumentException("Invalid currency type entered. Enter Euro, Dollars or Yen");
                }
            }
            else if (currentUnit.ToLower(CultureInfo.CurrentCulture).Equals("yen"))
            {
                if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("dollars"))
                {
                    convertedAmt = money * YenToDollar;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("euro"))
                {
                    convertedAmt = money * YenToEuro;
                    CurrencyUnit = conversionUnit;
                }
                else if (conversionUnit.ToLower(CultureInfo.CurrentCulture).Equals("yen"))
                {
                    return money;
                }
                else
                {
                    throw new ArgumentException("Invalid currency type entered. Enter Euro, Dollars or Yen");
                }
            }
            else
            {
                throw new ArgumentException("Invalid currency type entered. Enter Euro, Dollars or Yen");
            }
            MoneyAmount = convertedAmt;
            return convertedAmt;
        }

        public Money CurrencyAddition(Money baseMoney, Money toAdd)
        {
            Money converted = new Money(0, baseMoney.CurrencyUnit);
            double total = converted.Conversion(toAdd.MoneyAmount, toAdd.CurrencyUnit, baseMoney.CurrencyUnit) + baseMoney.MoneyAmount;
            converted.MoneyAmount = total;
            return converted;
        }
    }
}
