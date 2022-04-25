using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Scheduled { get; set; }
        public TransactionType Type { get; set; }

    }

    public enum TransactionType
    {
        Bill, Income, Budget
    }
}
