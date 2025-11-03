using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers.Models
{
    public class Transaction
    {
        public string TransactionID { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Desctiption { get; }
        public string Type { get; }

        public Transaction(string transactionID, decimal amount, string desctiption, string type)
        {
            TransactionID = transactionID;
            Date = DateTime.Now;
            Amount = amount;
            Desctiption = desctiption;
            Type = type;
        }

        public override string ToString() => $"{Date:yyyy-MM-dd HH:mm} {Type} : ({Amount:C}) - {Desctiption}";
    }
}
