using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnitTesting
{
    public class BankAccount
    {
        private string sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> transactionHistory;

        public string SortCode { get { return sortCode; } }
        public string AccountNumber { get { return accountNumber; } }
        public double OverdraftLimit { get { return overdraftLimit; } }
        public double Balance { get { return balance; } }
        public List<double> TransactionHistory { get { return transactionHistory; } }

        public BankAccount(string sortCode, string accountNum, double overdraftLimit)
        {
            this.sortCode = sortCode;
            this.accountNumber = accountNum;
            this.overdraftLimit = overdraftLimit;
            this.balance = 0;
            transactionHistory = new List<double>();
        }
        public BankAccount(string sortCode, string accountNum)
        {
            this.sortCode = sortCode;
            this.accountNumber = accountNum;
            this.overdraftLimit = 0;
            this.balance = 0;
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                transactionHistory.Add(amount);
                Console.WriteLine(amount + " deposited");
            }
            else
            {
                throw new ArgumentException("Amount must be greater than zero");
            }


        }
        public void Withdraw(double amount)
        {

            if (amount > 0)
            {
                if ((balance + overdraftLimit) > amount)
                {
                    balance -= amount;
                    transactionHistory.Add(amount * -1);
                    Console.WriteLine(amount + " withdrawn");
                }
                else
                {
                    throw new ArgumentException("Insufficient funds");
                }
            }
            else
            {
                throw new ArgumentException("Amount must be greater than zero");
            }
        }


        public override string ToString()
        {
            string returnString = "Bank Account Details: \nAccount Number: " + AccountNumber + "\nSort Code: " + SortCode
                + "\nOverdraft Limit: " + OverdraftLimit + "\nBalance: " + Balance + "\nTransaction History: \n";
            foreach (double amt in transactionHistory)
            {
                returnString += amt + "\n";
            }

            return returnString;
        }
    }
}

