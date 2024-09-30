using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetapp
{
    class Transaction
    {
        public decimal Amount { get; }
        public string Type { get; }
        public string Description { get; }

        public DateTime Date { get; }


        public Transaction(decimal amount, string type, string description, DateTime date)
        {
            Amount = amount;
            Type = type;
            Description = description;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Type}: {Description} ({Amount:C})";
        }
    }
}
