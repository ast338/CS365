namespace ATM
{
  public class Customer
  {
    private ATM ATMInterface;

    public Customer()
    {

    }

    public ATM atm
    {
      get
      {
        return ATMInterface;
      }
      set
      {
        ATMInterface = value;
      }
    }

    //TODO: Add GUI/user trigger functionality and logic for performing ATM operations.
  }
}
