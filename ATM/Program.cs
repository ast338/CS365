using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ATM
{
  static class Program
  {
    [DllImport("kernel32.dll")]
    static extern bool AttachConsole(int dwProcessId);
    private const int ATTACH_PARENT_PROCESS = -1;
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string [] args)
    {
      AttachConsole(ATTACH_PARENT_PROCESS);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Customer customer = new Customer();
      Bank centralBank = new Bank();
      ATM ATMInterface = new ATM(centralBank, customer);
      customer.atm = ATMInterface;
      Application.Run(ATMInterface);
    }
  }
}
