using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UserAccount
    {
        // Private fields
        private string _password;
        private decimal _balance;

        // 1. AccountId (Read freely, can only be set during creation via constructor)
        public string AccountId { get; private set; }

        // 2. Username (Auto-Implemented Property)
        public string Username { get; set; }

        // 3. Write-Only Property
        public string Password
        {
            set
            {
                _password = "[ENCRYPTED]_" + value;
            }
        }

        // 4. Full Property with Validation
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: Balance cannot be negative!");
                }
                else
                {
                    _balance = value;
                }
            }
        }

        // 5. Computed Read-Only Property
        public bool IsVIP
        {
            get
            {
                return Balance >= 10000m;
            }
        }

        // 6. Get-Only Auto Property
        public DateTime CreatedDate { get; }

        // Constructor to initialize AccountId and CreatedDate
        public UserAccount(string accountId)
        {
            AccountId = accountId;
            CreatedDate = DateTime.Now;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create account (Passing AccountId into constructor)
            UserAccount user = new UserAccount("ACC-99201")
            {
                Username = "Alice_Code",
                Password = "SuperSecretPassword123"
            };

            Console.WriteLine("Account ID: " + user.AccountId);
            Console.WriteLine("Username: " + user.Username);
            Console.WriteLine("Account Created: " + user.CreatedDate);

            // 2. Test Balance validation
            Console.WriteLine("\n--- Testing Balance Updates ---");
            user.Balance = 5000m;
            Console.WriteLine("Current Balance: " + user.Balance.ToString("C"));

            user.Balance = -200m;
            Console.WriteLine("Current Balance after invalid attempt: " + user.Balance.ToString("C"));

            // 3. Test IsVIP logic
            Console.WriteLine("\nIs VIP? " + user.IsVIP);

            user.Balance = 15000m;
            Console.WriteLine("Updated Balance: " + user.Balance.ToString("C"));
            Console.WriteLine("Is VIP now? " + user.IsVIP);
        }
    }
}