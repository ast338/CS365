using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Linq;
using System;

namespace ATM
{
  public class Bank
  {
    private static List<Account> accountDatabase;
    private static Dictionary<string, string> accountHashes;

    public Bank()
    {
      accountDatabase = new List<Account>();
      accountHashes = new Dictionary<string, string>();
    }

    public static byte[] GetHash(string input)
    {
      HashAlgorithm algorithm = MD5.Create();
      return algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
    }

    public void MoneyRefill(decimal Money)
    {
      Money += 1000000;
    }

    public void PaperRefill(int Paper)
    {
      Paper += 1000;
    }

    public bool Withdraw(Account accountName, decimal Money)
    {
      Account account = GetAccount(accountName);

      // Account balance must be more than the money specified.
      if (decimal.Round(Money, 2) > account.Balance)
        return false;

      // Withdraw the amount from the account.
      account.Balance -= decimal.Round(Money, 2);
      return true;
    }

    public void Deposit(Account accountName, decimal Money)
    {
      Account account = GetAccount(accountName);
      account.Balance += decimal.Round(Money, 2);
    }

    public decimal GetBalance(Account accountName)
    {
      Account account = GetAccount(accountName);
      return account.Balance;
    }

    public bool AccountTransfer(Account senderAccount, string receiverAccount, decimal Money)
    {
      // Get sender and receiving accounts.
      Account sendAccount = GetAccount(senderAccount);
      Account recAccount = GetAccount(receiverAccount);

      // Balance must have more than the money specified.
      if (sendAccount.Balance < decimal.Round(Money, 2))
        return false;

      // Give money to receiving account, take it away from sending account.
      sendAccount.Balance -= decimal.Round(Money, 2);
      recAccount.Balance += decimal.Round(Money, 2);
      return true;
    }

    public bool AuthenticateUser(string accountAttempt, string passwordAttempt, Account accountATM)
    {
      // Search for account. If it's not in the database, account does not exist.
      Account account = GetAccount(accountAttempt);
      if (account.Name == "" && account.Balance == 0)
        return false;

      // Hash the password attempt and compare it with the stored hash.
      // If the two match, the user is authenticated.
      byte[] hashAttempt = GetHash(passwordAttempt);
      string hashString = Encoding.UTF8.GetString(hashAttempt);
      if (accountHashes[account.Name] == hashString)
      {
        accountATM = account;
        return true;
      }

      return false;
    }

    private Account GetAccount(Account accountName)
    {
      foreach (Account account in accountDatabase)
      {
        if (account == accountName)
          return account;
      }

      Account emptyAccount = new Account();
      return emptyAccount;
    }

    private Account GetAccount(string accountName)
    {
      foreach (Account account in accountDatabase)
      {
        if (account.Name == accountName)
          return account;
      }

      Account emptyAccount = new Account();
      return emptyAccount;
    }

    public void ReadDatabaseFile(string Filename)
    {
      try
      {
        using (StreamReader file = new StreamReader(Filename))
        {
          while (file.Peek() >= 0)
          {
            string AccountName = file.ReadLine();
            string AccountHash = file.ReadLine();
            string AccountBalance = file.ReadLine();

            Account account = new Account();
            account.Name = AccountName;
            account.Balance = Convert.ToDecimal(AccountBalance);
            accountDatabase.Add(account);
            accountHashes.Add(AccountName, AccountHash);
          }
        }
      }
      catch (Exception e)
      {

      }
    }

    public void WriteDatabaseFile(string Filename)
    {
      try
      {
        using (StreamWriter file = new StreamWriter(Filename))
        {
          int hashIndex = 0;
          foreach (Account account in accountDatabase)
          {
            file.WriteLine(account.ToString());
            var hash = accountHashes.ElementAt(hashIndex);
            file.WriteLine(hash);
            ++hashIndex;
          }
        }
      }
      catch (Exception e)
      {
        
      }
    }
  }
}