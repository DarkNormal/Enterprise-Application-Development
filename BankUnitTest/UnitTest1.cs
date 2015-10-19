using System;
using BankUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OverdraftLimitReached()
        {
            BankAccount b = new BankAccount("BOI53", "STU38291", 2000);
            b.Deposit(100);
            b.Withdraw(2000);
            b.Withdraw(200);
            Console.WriteLine(b.ToString());
            Assert.AreEqual(b.Balance, -1900);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeDeposit()
        {
            BankAccount b = new BankAccount("BOI53", "STU38291", 2000);
            b.Deposit(-100);
        }
    }
}
