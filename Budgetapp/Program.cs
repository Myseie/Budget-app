using Budgetapp;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        BudgetManager manager = new BudgetManager();
        string filePath = "transactions.txt";

        manager.LoadFromFile(filePath);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1.Lägg till inkomst");
            Console.WriteLine("2.Lägg till utgift");
            Console.WriteLine("3.Visa alla transaktioner");
            Console.WriteLine("4.Visa budgetrapport");
            Console.WriteLine("5.Visa transaktioner för en viss månad.");
            Console.WriteLine("6. Spara till fil");
            Console.WriteLine("7.Avsluta");

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Write("Ange ett inkomstbelopp:");
                    decimal incomeAmount = decimal.Parse(Console.ReadLine());

                    Console.Write("Ange beskrivning:");
                    string incomeDescription = Console.ReadLine();

                    Transaction income = new Transaction(incomeAmount, "Inkomst", incomeDescription, DateTime.Now);
                    manager.AddTransaction(income);
                    break;

                case "2":
                    Console.Write("Ange utgiftsbelopp:");
                    decimal expenseAmount = decimal.Parse(Console.ReadLine());

                    Console.Write("Ange beskrivning:");
                    string expenseDescription = Console.ReadLine();

                    Transaction expense = new Transaction(expenseAmount, "Utgift", expenseDescription, DateTime.Now);
                    manager.AddTransaction(expense);
                    break;

                case "3":
                    manager.ShowAllTransactions();
                    break;

                case "4":
                    manager.ShowReport();
                    break;

                case "5":
                    Console.Write("Ange månad (1-12):");
                    int month = int.Parse(Console.ReadLine());
                    Console.Write("Ange år (yyyy):");
                    int year = int.Parse(Console.ReadLine());

                    manager.ShowTransactionByMonth(month, year);
                    break;

                case "6":
                    manager.SaveToFile(filePath);
                    break;

                case "7":
                    manager.SaveToFile(filePath);
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Ogiltligt val, försök igen.");
                    break;


            }
        }
    }
}