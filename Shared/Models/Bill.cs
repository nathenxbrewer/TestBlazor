using SQLite;
using System;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace BlazorApp.Shared.Models
{
    public class Bill
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool isActive { get; set; } = true;

        [MaxLength(250), Required, Unique]
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
