namespace ATM
{
  public class Bank
  {
    private Account[] accountDatabase;

    public Bank()
    {

    }

    public bool Withdraw(Account accountName, float Money)
    {
      return false;
    }

    public void Deposit(Account accountName, float Money)
    {

    }

    public float GetBalance(Account accountName)
    {
      return 0;
    }

    public bool AccountTransfer(Account senderAccount, string receiverAccount, float Money)
    {
      return false;
    }

    public bool AuthenticateUser(string accountAttempt, string passwordAttempt)
    {
      return false;
    }
  }
}