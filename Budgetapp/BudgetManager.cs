using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetapp
{
    class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);

            Console.WriteLine($"Transaktionen '{transaction.Description} har lagts till'");
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var transaction in transactions)
                {
                    writer.Write($"{transaction.Amount}, {transaction.Type}, {transaction.Description}, {transaction.Date:yyyy-MM-ddTHH:mm:ss}");
                }
            }
            Console.WriteLine("Alla transaktioner har sparats till fil.");
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        decimal amount = decimal.Parse(parts[0]);
                        string type = parts[1];
                        string description = parts[2];
                        DateTime date = DateTime.ParseExact(parts[3].Trim(),"yyyy-MM-ddTHH:mm:ss", null);

                        Transaction transaction = new Transaction(amount, type, description, date);
                        transactions.Add(transaction);
                    }
                }
                Console.WriteLine("Transaktionerna har laddats från fil.");
            }
        }

        public void ShowTransactionByMonth(int month, int year)
        {
            var filteredTransactions = transactions.Where(t => t.Date.Month == month &&  t.Date.Year == year).ToList();

            if (filteredTransactions.Count == 0)
            {
                Console.WriteLine($"Inga transaktioner hittades för {month/year}");

            }
            else
            {
                Console.WriteLine($"Transaktioner för {month/year} :");
                foreach (var transaction in filteredTransactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }

        public void ShowAllTransactions()
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("Inga transaktioner har lagts till ännu.");
            }
            else
            {
                Console.WriteLine("Alla transaktioner:");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }

        public decimal GetTotalIncome()
        {
            return transactions.Where(t => t.Type == "Inkomst").Sum(t => t.Amount);


        }

        public decimal GetTotalExpense()
        {
            return transactions.Where(t => t.Type == "Utgift").Sum(t => t.Amount);

        }

        public decimal GetBalance()
        {
            return GetTotalIncome() - GetTotalExpense();

        }

        public void ShowReport()
        {
            Console.WriteLine($"Total inkomst: {GetTotalIncome():C}");
            Console.WriteLine($"Total utgift: {GetTotalExpense():C}");
            Console.WriteLine($"Aktuellt saldo: {GetBalance():C}");
        }
    }
}
