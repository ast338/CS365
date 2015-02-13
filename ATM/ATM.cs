using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
  public partial class ATM : Form
  {
    private Account currentAccount;
    private Bank centralBank;
    private Customer currentCustomer;

    // Construct an ATM interface which takes in the Bank and Customer that want to communicate.
    public ATM(Bank bank, Customer customer)
    {
      InitializeComponent();
      centralBank = bank;
      currentCustomer = customer;
    }

    // Withdraw money from this account.
    public bool Withdraw(float Money)
    {
      return centralBank.Withdraw(currentAccount, Money);
    }

    // Deposit money into the account.
    public void Deposit(float Money)
    {
      centralBank.Deposit(currentAccount, Money);
    }

    // Check this account's balance.
    public float CheckBalance()
    {
      return centralBank.GetBalance(currentAccount);
    }

    // Transfer money from this account into another given account.
    public bool TransferMoney(float Money, string Account)
    {
      return centralBank.AccountTransfer(currentAccount, Account, Money);
    }

    // Attempt authentication for user's given input (account name and password).
    // Bank will do the authentication process using hashing?
    public bool AuthenticationRequest(string accountAttempt, string passwordAttempt)
    {
      currentAccount.Name = accountAttempt;
      currentAccount.Balance = 0;
      return centralBank.AuthenticateUser(accountAttempt, passwordAttempt);
    }

    // Print a receipt after ATM activities.
    public void PrintReceipt()
    {

    }
  }
}
