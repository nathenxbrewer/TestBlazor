using BlazorApp.Shared.Models;

namespace BlazorApp.Client.Services
{
    public class TransactionService
    {

        public ForcastedBalance CalculateBalance(List<Income> incomes, List<Bill> bills, List<Budget> budgets, float startingBalance, DateTime date, bool includeBudgets)
        {
            var forcastedBalance = new ForcastedBalance()
            {
                ForcastedDate = date,
                Transactions = GetTransactions(incomes, bills, budgets, date, includeBudgets).ToList(),
            };
            forcastedBalance.Amount = GetForcastedAmount(startingBalance, forcastedBalance.Transactions, date);
            return forcastedBalance;
        }

        public IEnumerable<Transaction> GetTransactions(List<Income> incomes, List<Bill> bills, List<Budget> budgets, DateTime date, bool includeBudgets)
        {

            var ForcastedTransactions = new List<Transaction>();
            foreach (var income in incomes)
            {
                if (!income.isOneTime)
                {
                    //only forcast if reoccuring
                    for (DateTime i = income.BeginDate.Value; i <= date; i = i.AddDays(income.OccuranceDays))
                    {
                        if (i > DateTime.Today)
                        {
                            ForcastedTransactions.Add(new Transaction()
                            {
                                Description = income.Name,
                                Amount = income.Amount,
                                Scheduled = i,
                                Type = TransactionType.Income

                            });

                        }
                    }
                }
            }

            foreach (var bill in bills)
            {
                if (bill.OccuranceDays > 0 && bill.BeginDate <= DateTime.Today)
                {
                    var firstOccuranceDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, bill.DayOfMonth);
                    //only forcast if reoccuring
                    for (DateTime i = firstOccuranceDay; i <= date; i = i.AddMonths(1))
                    {
                        if (i > DateTime.Today)
                        {
                            ForcastedTransactions.Add(new Transaction()
                            {
                                Description = bill.Name,
                                Amount = bill.Amount * -1, //making it negative since it's a bill
                                Scheduled = i,
                                Type = TransactionType.Bill
                            });
                        }
                    }
                }
            }

            if (includeBudgets)
                foreach (var budget in budgets)
                {
                    //Don't assume which day of the month, rather, budgets will be deduced from final forcast.
                    var monthCount = GetMonthsBetween(DateTime.Today, date);
                    for (int i = 0; i < monthCount; i++)
                    {
                        ForcastedTransactions.Add(new Transaction()
                        {
                            Description = budget.Name,
                            Amount = budget.High * -1, //making it negative since it's a bill
                            Scheduled = DateTime.MaxValue,
                            Type = TransactionType.Budget
                        });
                    }

                }

            return ForcastedTransactions.Where(x => x.Scheduled <= date && x.Scheduled >= DateTime.Today || x.Scheduled == DateTime.MaxValue);
        }

        public double GetForcastedAmount(double startingBalance, List<Transaction> transactions, DateTime forcastedDate)
        {
            foreach (var transaction in transactions.Where(x => x.Scheduled <= forcastedDate && x.Scheduled >= DateTime.Today))
            {
                startingBalance += transaction.Amount;
            }

            return startingBalance;
        }

        public static int GetMonthsBetween(DateTime from, DateTime to)
        {
            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }
    }
}
