using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Bank bankAuthority = new Bank();
      Customer customer = new Customer();
      ATM ATMInterface = new ATM(bankAuthority, customer);
      customer.atm = ATMInterface;
      Application.Run(ATMInterface);
    }
  }
}
