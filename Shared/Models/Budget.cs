using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
    }
}
