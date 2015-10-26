using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSampleExam1
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        CurrentAccount c = new CurrentAccount("KXAVAEGM1234", 2000);
    //        c.MakeDeposit(5000);
    //        c.MakeWithdrawal(6000);
    //        c.MakeWithdrawal(10000);
    //        Console.WriteLine(c.ToString());
    //        Console.ReadLine();
    //    }
    //}

    public abstract class BankAccount
    {
        private string accountNumber;
        private double accountBalance;

        public string AccountNumber { get { return accountNumber; } }
        public double AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance += value; }
        }

        public BankAccount(string accountNumber)
        {
            this.accountNumber = accountNumber;
            this.accountBalance = 0;
        }

        public abstract void MakeDeposit(double amount);
        public abstract void MakeWithdrawal(double amount);
    }

    public class CurrentAccount : BankAccount
    {
        private double overdraftLimit;
        public double OverdraftLimit { get { return overdraftLimit; } }
        public List<AccountTransaction> transactionHistory;
        public CurrentAccount(string accountNumber, double overdraftLimit) : base(accountNumber)
        {
            this.overdraftLimit = overdraftLimit;
            transactionHistory = new List<AccountTransaction>();
        }
        public override void MakeDeposit(double amount)
        {
            if(amount > 0)
            {
                AccountBalance = amount;
                AccountTransaction transact = new AccountTransaction(TransactionType.Deposit, amount);
                transactionHistory.Add(transact);
            }
            else{ throw new ArgumentException("Cannot be a negative value"); }
        }

        public override void MakeWithdrawal(double amount)
        {
            if(amount > 0)
            {
                if(AccountBalance + OverdraftLimit > amount)
                {
                    AccountBalance = (amount * -1);
                    AccountTransaction transact = new AccountTransaction(TransactionType.Withdrawal, amount);
                    transactionHistory.Add(transact);
                }
                else
                {
                    throw new ArgumentException("Overdraft limit reached");
                }
            }
            else
            {
                throw new ArgumentException("cannot be a negative number");
            }
        }
        public override string ToString()
        {
            string accountDetails = "Account number: " + AccountNumber + "\nAccount balance: " + AccountBalance
                + "\nOverdraft limit: " + OverdraftLimit + "\nTransaction history:";
            foreach(AccountTransaction t in transactionHistory){
                accountDetails += t.ToString();
            }
            return accountDetails;
        }
    }
    public enum TransactionType
    {
        Deposit, Withdrawal
    }
    public class AccountTransaction
    {
        private TransactionType type;
        private double amount;

        public AccountTransaction(TransactionType type, double amount)
        {
            this.type = type;
            this.amount = amount;
        }
        public override string ToString()
        {
            return "\nTransaction type: " + type + " Amount: " + amount; 
        }
    }
}
