using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers.Models
{
    public class Bank
    {
        private readonly Dictionary<string, Customer> _customers;
        private readonly Dictionary<string, BankAccount> _accounts;
        private readonly Dictionary<string, List<Transaction>> _accountTransactions;
        private readonly Dictionary<string, string> _accountToCustomerMap;

        public Bank()
        {
            _customers = new();
            _accounts = new();
            _accountTransactions = new();
            _accountToCustomerMap = new();
        }


        // Одномерный индексатор
        public Customer this[string customerId]
        {
            get
            {
                if (_customers.TryGetValue(customerId, out var customer))
                {
                    return customer;
                }
                throw new KeyNotFoundException($"Клиент с таким ИД ({customerId}) не найден.");
            }
            set
            {
                _customers[customerId] = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        // Двумеррный индексатор
        public BankAccount this[string customerId, string accountType]
        {
            get
            {
                var customerAccounts = GetCustomerAccounts(customerId);

                var account = customerAccounts.FirstOrDefault(a => a.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase));

                return account ?? throw new KeyNotFoundException($"Аккаунт типа ({accountType}) не найден для пользователя {customerId}");
            }
        }

        // Многомерный индексатор
        public BankAccount this[string customerId, string accountType, string currency]
        {
            get
            {
                var customerAccounts = GetCustomerAccounts(customerId);

                var account = customerAccounts.FirstOrDefault(a =>
                    a.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase) &&
                    a.Currency.Equals(currency, StringComparison.OrdinalIgnoreCase)
                    );

                return account ?? throw new KeyNotFoundException($"({accountType}) аккаунт в валюте {currency} не найден для пользователя {customerId}");
            }
        }


        public IEnumerable<Transaction> this[string accountNumber, DateTime startDate, DateTime endDate]
        {
            get
            {
                if (!_accountTransactions.TryGetValue(accountNumber, out var transactions))
                    throw new KeyNotFoundException($"Нет транзакций для аккаунта {accountNumber}");

                return transactions.Where(t => t.Date >= startDate && t.Date <= endDate).OrderBy(t => t.Date);
            }
        }


        public IEnumerable<BankAccount> this[string customerId, bool getByCurrency, string currency]
        {
            get
            {
                return GetCustomerAccounts(customerId).Where(a => a.Currency.Equals(currency, StringComparison.OrdinalIgnoreCase));
            }
        }

        //Вспомогательные функции

        public void AddCustomer(Customer customer)
        {
            _customers[customer.CustomerId] = customer;
        }

        public void AddAccount(string customerId, BankAccount account)
        {
            _accounts[account.AccountNumber] = account;
            _accountToCustomerMap[account.AccountNumber] = customerId;
            _accountTransactions[account.AccountNumber] = new List<Transaction>();

        }

        public void AddTransaction(string accountNumber, Transaction transaction)
        {
            if (!_accountTransactions.ContainsKey(accountNumber))
                throw new KeyNotFoundException($"Аккаунт {accountNumber} не найден.");

            _accountTransactions[accountNumber].Add(transaction);

            var account = _accounts[accountNumber];
            if (transaction.Type == "Deposit")
            {
                account.Deposit(transaction.Amount);
            }
            else if (transaction.Type == "Withdrawal")
            {
                account.Withdraw(transaction.Amount);
            }
        }

        private IEnumerable<BankAccount> GetCustomerAccounts(string customerId)
        {
            var customerAccounts = _accountToCustomerMap
                .Where(kvp => kvp.Value == customerId)
                .Select(kvp => _accounts[kvp.Key])
                .ToList();


            if (!customerAccounts.Any())
                throw new KeyNotFoundException($"Ни одного аккаунта не было найдено для клиента ({customerId})");

            return customerAccounts;
        }

        public IEnumerable<Transaction> GetAccountTransactions(string accountNumber)
        {
            return _accountTransactions.TryGetValue(accountNumber, out var transaction) ? transaction : Enumerable.Empty<Transaction>();
        }


    }
}
