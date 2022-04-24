using System;
using System.ComponentModel.DataAnnotations;

namespace Resume.WASM.MoneyForcaster.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public bool isActive { get; set; } = true;
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? BeginDate { get; set; } = DateTime.Today;
        [Required]
        public DateTime? EndDate { get; set; } = DateTime.Today.AddYears(1);
        public int DayOfMonth { get; set; }

        [Range(1.0, 100000, ErrorMessage = "Amount must be greater than 0!")]
        public float Amount { get; set; }
        public int OccuranceDays { get; set; } = 30;
        public string Notes { get; set; }
    }
}
