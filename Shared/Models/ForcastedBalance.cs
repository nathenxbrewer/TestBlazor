using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class ForcastedBalance
    {
        public List<Transaction> Transactions { get; set; }
        public DateTime ForcastedDate { get; set; }
        public double Amount { get; set; }
    }
}
