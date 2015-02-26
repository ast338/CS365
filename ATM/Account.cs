namespace ATM
{
  public class Account
  {
    private string name_;
    private decimal balance_;

    public Account()
    {
      name_ = "";
      balance_ = 0;
    }

    public string Name
    {
      get
      {
        return name_;
      }
      set
      {
        name_ = value;
      }
    }
    public decimal Balance
    {
      get
      {
        return balance_;
      }
      set
      {
        balance_ = value;
      }
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      Account rhs = obj as Account;
      if ((System.Object) rhs == null)
        return false;

      return (Name == rhs.Name &&
         (Balance > (rhs.Balance - .000000001M)) && (Balance < (rhs.Balance + .000000001M)));
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static bool operator ==(Account lhs, Account rhs)
    {
      return (lhs.Name == rhs.Name &&
         (lhs.Balance > (rhs.Balance - .000000001M)) && (lhs.Balance < (rhs.Balance + .000000001M)));
    }

    public static bool operator !=(Account lhs, Account rhs)
    {
      return (!(lhs.Name == rhs.Name &&
         (lhs.Balance > (rhs.Balance - .000000001M)) && (lhs.Balance < (rhs.Balance + .000000001M))));
    }

    public override string ToString()
    {
      string Format = name_.ToString() + "\n" + balance_.ToString();
      return Format;
    }
  }
}
