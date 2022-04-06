using System;

namespace Resume.WASM.MoneyForcaster.Models
{
    public class Bill
    {
        public bool isActive { get; set; } = true;
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayOfMonth { get; set; }
        public float Amount { get; set; }
        public int OccuranceDays { get; set; } = 30;
        public string Notes { get; set; }
    }
}
