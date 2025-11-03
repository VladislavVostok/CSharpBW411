using Indexers.Models;

namespace Indexers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();

            var customer1 = new Customer("CUST001", "John", "Doe", "john.doe@email.com");
            var customer2 = new Customer("CUST002", "Jane", "Smith", "jane.smith@email.com");

            bank.AddCustomer(customer1);
            bank.AddCustomer(customer2);

            var account1 = new BankAccount("ACC001", "Debet", 1000m, "USD");
            var account2 = new BankAccount("ACC002", "Savings", 5000m, "USD");
            var account3 = new BankAccount("ACC003", "Savings", 2000m, "EUR");
            var account4 = new BankAccount("ACC004", "Credit", -500m, "USD");

            bank.AddAccount("CUST001", account1);
            bank.AddAccount("CUST001", account2);
            bank.AddAccount("CUST002", account3);
            bank.AddAccount("CUST002", account4);


            bank.AddTransaction("ACC001", new Transaction("T001", 500m, "Salary", "Deposit"));
            bank.AddTransaction("ACC001", new Transaction("T002", -100m, "Beer", "Withdrawal"));
            bank.AddTransaction("ACC002", new Transaction("T003", 1000m, "Investment", "Deposit"));


            Console.WriteLine($"Клиент: {bank["CUST001"]}");
            Console.WriteLine($"Проверка аккаунта: {bank["CUST001", "Savings"]}");
            Console.WriteLine($"EUR Savings: {bank["CUST001", "Savings", "EUR"]}");


            var lastWeekTransactions = bank["ACC001", DateTime.Now.AddDays(-7), DateTime.Now];

            foreach ( var transaction in lastWeekTransactions ) { 
                Console.WriteLine(transaction.ToString()); 
            }


            var usdAccount = bank["CUST001", true, "USD"];
            foreach (var account in usdAccount)
            {
                Console.WriteLine(account.ToString());
            }


            try
            {
                var invalidAccount = bank["CKJGFKJDHKJ", "Investing"];

            }
            catch (KeyNotFoundException ex) {
                Console.WriteLine($"/nError: {ex.Message}");
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
