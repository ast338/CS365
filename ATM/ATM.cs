using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATM
{
  public partial class ATM : Form
  {
    private Account currentAccount;
    private Bank centralBank;
    private Customer currentCustomer;
    private int paperAmount;
    private decimal moneyAmount;

    // Construct an ATM interface which takes in the Bank and Customer that want to communicate.
    public ATM(Bank bank, Customer customer)
    {
      InitializeComponent();
      currentAccount = new Account();
      centralBank = bank;
      currentCustomer = customer;
      paperAmount = 1000;
      moneyAmount = 1000000.00M;
    }

    // Withdraw money from this account.
    public bool Withdraw(decimal Money)
    {
      if (moneyAmount < Money)
        centralBank.MoneyRefill(moneyAmount);
      moneyAmount -= Money;
      return centralBank.Withdraw(currentAccount, Money);
    }

    // Deposit money into the account.
    public void Deposit(decimal Money)
    {
      moneyAmount += Money;
      centralBank.Deposit(currentAccount, Money);
    }

    // Check this account's balance.
    public decimal CheckBalance()
    {
      return centralBank.GetBalance(currentAccount);
    }

    // Transfer money from this account into another given account.
    public bool TransferMoney(decimal Money, string Account)
    {
      return centralBank.AccountTransfer(currentAccount, Account, Money);
    }

    // Attempt authentication for user's given input (account name and password).
    // Bank will do the authentication process using hashing?
    public bool AuthenticationRequest(string accountAttempt, string passwordAttempt)
    {
      // If user is authenticated, we set our current user to their information.
      return centralBank.AuthenticateUser(accountAttempt, passwordAttempt, currentAccount);
    }

    // Print a receipt after ATM activities.
    public void PrintReceipt(string transaction, string filename)
    {
      if (paperAmount <= 0)
        centralBank.PaperRefill(paperAmount);

      Console.WriteLine(transaction);
      using (StreamWriter file = new StreamWriter(filename))
      {
        file.WriteLine(transaction);
      }
      paperAmount--;
    }
  }
}
