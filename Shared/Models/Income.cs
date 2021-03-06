using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isOneTime { get; set; }
        public double Amount { get; set; }
        public int OccuranceDays { get; set; }
        public DateTime? BeginDate { get; set; } = DateTime.Today;
        public DateTime? EndDate { get; set; } = DateTime.Today.AddYears(1);
        public string Notes { get; set; }

    }
}
